using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opto22.OptoMMP3;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Opto22_IPconfig
{
    public partial class Form1 : Form
    {
        //Memory Map Addresses
        const long ip_AD = 0xFFFFFFFFF008;
        const long subnet_AD = 0xFFFFFFFFF010;
        const long gateway_AD = 0xFFFFFFFFF018;
        const long dns_AD = 0xFFFFFFFFF020;

        static byte[] query1 = { 0x00, 0x00, 0x04, 0x10, 0x00, 0x00,
            0xff, 0xff, 0xf0, 0x38, 0x00, 0x00, 0x00, 0x04,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };

        static byte[] query2 = { 0x00, 0x00, 0x08, 0x50, 0x00, 0x00,
            0xff, 0xff, 0xf0, 0x30, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00 };

        List<Opto22Device> PACList = new List<Opto22Device>();

        IPEndPoint thisEP;
        UdpClient UDPSender;
        UdpClient UDPListener;
        IPEndPoint PAC_EP;
        BindingSource pacbs = new BindingSource();
        bool timedout = false;

        public Form1()
        {
            InitializeComponent();
        }


        IPAddress getLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                var localIP = endPoint.Address;
                return localIP;
            }
        }

        IPAddress GetBroadcastAddress(IPAddress ip)
        {
            var ipBytes = ip.GetAddressBytes();
            ipBytes[2] = 0;
            ipBytes[3] = 255;
            return new IPAddress(ipBytes);
        }

        void OpenNetworkConnections(IPAddress ip, int port, int timeout)
        {
            UDPSender = new UdpClient();
            UDPSender.EnableBroadcast = true;
            UDPSender.Connect(ip, port);
            UDPSender.Client.ReceiveTimeout = timeout;
            UDPSender.Client.SendTimeout = timeout;
            thisEP = (IPEndPoint)UDPSender.Client.LocalEndPoint;
            UDPListener = new UdpClient(thisEP);
            UDPListener.Client.ReceiveTimeout = timeout;
            UDPListener.Client.SendTimeout = timeout;
            PAC_EP = new IPEndPoint(IPAddress.Any, thisEP.Port);
        }

        void CloseNetworkConnections()
        {
            UDPListener.Close();
            UDPSender.Close();
        }

        async Task BroadcastAsync(byte[] query)
        {
            if (!timedout)
            {

                try
                {
                    await UDPSender.SendAsync(query, query.Length);
                }
                catch { }
            }
        }

        //recieve data and populate pac dict
        async Task RecieveDataAsync()
        {
            byte[] data = new byte[80];
            do
            {
                if (!timedout)
                {
                    try
                    {
                        var result = await UDPListener.ReceiveAsync();
                        Array.Copy(result.Buffer, data, result.Buffer.Length);
                        foreach (byte b in data)
                        {
                            Console.Write(b.ToString("X") + " ");
                        }
                        Console.WriteLine();

                        byte[] ipbytes = new byte[4];
                        byte[] gatewaybytes = new byte[4];
                        byte[] subnetbytes = new byte[4];
                        byte[] macbytes = new byte[6];
                        byte[] firmbytes = new byte[4];
                        byte[] unitbytes = new byte[4];
                        byte[] dnsbytes = new byte[4];

                        Array.Copy(data, Opto22Device.IPindex, ipbytes, 0, 4);
                        Array.Copy(data, Opto22Device.GATEWAYindex, gatewaybytes, 0, 4);
                        Array.Copy(data, Opto22Device.SUBNETindex, subnetbytes, 0, 4);
                        Array.Copy(data, Opto22Device.DNSindex, dnsbytes, 0, 4);
                        Array.Copy(data, Opto22Device.MACindex, macbytes, 0, 6);
                        Array.Copy(data, Opto22Device.FIRMindex, firmbytes, 0, 4);
                        Array.Copy(data, Opto22Device.UNITindex, unitbytes, 0, 4);

                        IPAddress PacIpAddress = new IPAddress(ipbytes);
                        IPAddress PacGateway = new IPAddress(gatewaybytes);
                        IPAddress PacSubnet = new IPAddress(subnetbytes);
                        IPAddress PacDNS = new IPAddress(dnsbytes);

                        Opto22Device pac = new Opto22Device(PacIpAddress, PacSubnet, PacGateway, PacDNS, macbytes, firmbytes, unitbytes);
                        pac.Gateway = PacGateway;
                        pac.Subnet = PacSubnet;
                        pac.Dns = PacDNS;
                        if (!PACList.Exists(x => x.MACAddress == Opto22Device.getMACAddressString(macbytes)))
                        {
                            PACList.Add(pac);
                            pacbs.ResetBindings(false);
                        }
                    }
                    catch
                    {
                        //MessageBox.Show(e.ToString());
                    }
                }

            } while (UDPListener.Available > 0 || !timedout);
        }

        //Recieve data but do nothing
        async Task RecieveAndDiscardAsync()
        {
            byte[] data = new byte[100];
            Thread.Sleep(500);
            do
            {
                if (!timedout)
                {
                    try
                    {
                        var result = await UDPListener.ReceiveAsync();
                        Array.Copy(result.Buffer, data, result.Buffer.Length);
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show("No PACs Found!");
                    }
                    catch
                    {
                        //MessageBox.Show(e.ToString());
                    }
                }
            } while (UDPListener.Available > 0 && !timedout);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIP.Text = getLocalIPAddress().ToString();
            ipAddressControl1.IPAddress = IPAddress.Parse("192.168.0.255");
            pacbs.DataSource = PACList;
            PACGrid.DataSource = pacbs;
            configureDataGrid();
        }

        private void configureDataGrid()
        {
            PACGrid.Columns[0].Width = 115;
            PACGrid.Columns[1].Width = 85;
            PACGrid.Columns[2].Width = 85;
            PACGrid.Columns[3].Width = 85;
            PACGrid.Columns[4].Width = 85;
            PACGrid.Columns[5].Width = 85;
            PACGrid.Columns[6].Width = 150;
            PACGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Text = "Searching...";
            timedout = false;
            PACList.Clear();
            pacbs.ResetBindings(false);
            int timeout = Convert.ToInt32(tbTimeout.Text);
            int port = 2001;
            timer1.Interval = timeout;
            timer1.Start();
            try
            {
                OpenNetworkConnections(ipAddressControl1.IPAddress, port, timeout);
                await BroadcastAsync(query1);
                await RecieveAndDiscardAsync();
                await BroadcastAsync(query2);
                await RecieveDataAsync();
                await BroadcastAsync(query2);
                await RecieveDataAsync();
            }
            catch { }
            CloseNetworkConnections();
            timer1.Stop();
            btnFind.Text = "Find PACs";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var rows = PACGrid.SelectedRows;
            if (rows.Count == 1)
            {
                Opto22Device pac = (Opto22Device)rows[0].DataBoundItem;
                int port = 2001;
                int timeout = Convert.ToInt32(tbTimeout.Text);
                Form2 changeform = new Form2(this, pac, port, timeout);
                changeform.Show();
                changeform.Activate();
            }
            else
            {
                MessageBox.Show("Must select Control Engine from datagrid!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timedout = true;
            CloseNetworkConnections();
        }

        private void PACGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (PACGrid.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                PACGrid.ClearSelection();
                PACGrid.CurrentCell = null;
            }
            var rows = PACGrid.SelectedRows;
            if (rows.Count == 1)
            {
                downloadStrategyToolStripMenuItem.Enabled = true;
                runToolStripMenuItem.Enabled = true;
                stopStrategyToolStripMenuItem.Enabled = true;

            }
            else
            {
                downloadStrategyToolStripMenuItem.Enabled = false;
                runToolStripMenuItem.Enabled = false;
                stopStrategyToolStripMenuItem.Enabled = false;
            }
        }

        public void RemoveChangedPAC(Opto22Device pac)
        {
            PACList.Remove(pac);
            pacbs.ResetBindings(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void downloadStategyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            if (Directory.Exists(file.InitialDirectory + @"\Strategies"))
            {
                file.InitialDirectory += @"\Strategies";
            }
            file.Filter = "Compiled strategy files|*.cdf";

            if (file.ShowDialog() == DialogResult.OK)
            {
                string filename = Path.GetFileName(file.FileName);
                Console.WriteLine(filename);
                if (MessageBox.Show("Load " + filename + " to PAC?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DownloadStrategy(file.FileName);
                }
            }
        }

        private void DownloadStrategy(string filepath)
        {
            var rows = PACGrid.SelectedRows;
            string filename = Path.GetFileName(filepath);
            if (rows.Count == 1)
            {
                Opto22Device pac = (Opto22Device)rows[0].DataBoundItem;
                string controllerName = pac.IPAddress.ToString();
                string termclpath = getTermclPath();
                string createControllerName  = "-a " + controllerName + " tcp " + pac.IPAddress.ToString() + " 22001 3 2000";
                string uploadargs = "-d " + controllerName + " \"" + filepath + "\"";
                Console.WriteLine(uploadargs);
                var process = System.Diagnostics.Process.Start(termclpath, createControllerName);
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
                process = System.Diagnostics.Process.Start(termclpath, uploadargs);
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
                process = System.Diagnostics.Process.Start(termclpath, "-r " + controllerName + "");
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Must select Control Engine from datagrid!");
            }
        }

        private string getTermclPath()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Opto22\PAC Project 9.6\termcl.exe";
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Opto22\PAC Project 9.6\termcl.exe";
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = PACGrid.SelectedRows;
            if (rows.Count == 1)
            {
                Opto22Device pac = (Opto22Device)rows[0].DataBoundItem;
                string controllerName = pac.IPAddress.ToString();
                string termclpath = getTermclPath();
                Console.WriteLine(termclpath);
                string createControllerName = "-a " + controllerName + " tcp " + pac.IPAddress.ToString() + " 22001 3 2000";
                var process = System.Diagnostics.Process.Start(termclpath, createControllerName);
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
                process = System.Diagnostics.Process.Start(termclpath, "-r " + controllerName + "");
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Must select Control Engine from datagrid!");
            }
        }

        private void stopStrategyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = PACGrid.SelectedRows;
            if (rows.Count == 1)
            {
                Opto22Device pac = (Opto22Device)rows[0].DataBoundItem;
                string controllerName = pac.IPAddress.ToString();
                string termclpath = getTermclPath();
                string createControllerName = "-a \"" + controllerName + "\" tcp " + pac.IPAddress.ToString() + " 22001 3 2000";
                var process = System.Diagnostics.Process.Start(termclpath, createControllerName);
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
                process = System.Diagnostics.Process.Start(termclpath, "-s " + controllerName + "");
                while (!process.HasExited);
                if (process.ExitCode != 0)
                {
                    MessageBox.Show("termCL.exe not properly installed!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Must select Control Engine from datagrid!");
            }
        }
    }
    public class Opto22Device
    {

        public static uint FIRMindex = 44;
        public static uint UNITindex = 48;
        public static uint MACindex = 62;
        public static uint IPindex = 68;
        public static uint SUBNETindex = 72;
        public static uint GATEWAYindex = 76;
        public static uint DNSindex = 76;

        public static long ipMemoryAddress = 0xFFFFFFFFF008;
        public static long subnetMemoryAddress = 0xFFFFFFFFF010;
        public static long gatewayMemoryAddress = 0xFFFFFFFFF018;
        public static long dnsMemoryAddress = 0xFFFFFFFFF020;
        public static long portMemoryAddress = 0xFFFFF03A0074;


        public string MACAddress { get; set; }
        public IPAddress IPAddress { get; set; }
        public IPAddress Subnet { get; set; }
        public IPAddress Gateway { get; set; }
        public IPAddress Dns { get; set; }
        public string Firmware { get; set; }
        public string UnitType { get; set; }

        public Opto22Device(IPAddress ip, IPAddress sub, IPAddress gate, IPAddress dns, byte[] mac, byte[] firm, byte[] unit)
        {
            IPAddress = ip;
            Subnet = sub;
            Gateway = gate;
            Dns = dns;
            MACAddress = getMACAddressString(mac);
            Firmware = getFirmware(firm);
            UnitType = getUnitType(unit);
        }

        public static string getMACAddressString(byte[] mac)
        {
            string output = "";
            for (int i = 0; i < 6; i++)
            {
                output += mac[i].ToString("X2");
                if (i < 5) output += "-";
            }
            return output;
        }

        private static string getFirmware(byte[] firm)
        {
            string output = "";
            if (firm[2] == 0) output = "A";
            else if (firm[2] == 1) output = "B";
            else if (firm[2] == 2) output = "R";
            output += firm[0].ToString();
            output += ".";
            output += firm[1].ToString();
            char letter = (char)(firm[3] + 97);
            output += letter;
            return output;
        }

        private static string getUnitType(byte[] unit)
        {
            int id = ((unit[0] << 24) + (unit[1] << 16) + (unit[2] << 8) + unit[3]);
            string output = "0x" + id.ToString("x");
            output += " ";
            switch (id)
            {
                case 0x0000004E: output += "SNAP-PAC-R1-B"; break;
                case 0x00000052: output += "OPTOEMU-SNR-DR2"; break;
                case 0x00000056: output += "OPTOEMU-SNR-DR1"; break;
                case 0x00000058: output += "G4EB2"; break;
                case 0x0000005A: output += "OPTOEMU-SNR-3V"; break;
                case 0x0000005C: output += "SNAP-PAC-SRA"; break;
                case 0x00000062: output += "SNAP-PAC-SB2"; break;
                case 0x00000064: output += "SNAP-PAC-SB1"; break;
                case 0x00000066: output += "SNAP-PAC-R2-W"; break;
                case 0x00000068: output += "SNAP-PAC-R1-W"; break;
                case 0x0000006A: output += "SNAP-PAC-S1-W"; break;
                case 0x0000006C: output += "SNAP-PAC-S2-W"; break;
                case 0x00000070: output += "SNAP-PAC-EB2-W"; break;
                case 0x00000072: output += "SNAP-PAC-EB1-W"; break;
                case 0x00000074: output += "SNAP-PAC-EB2"; break;
                case 0x00000076: output += "SNAP-PAC-EB1"; break;
                case 0x00000078: output += "SNAP-PAC-R2"; break;
                case 0x0000007A: output += "SNAP-PAC-R1"; break;
                case 0x0000007C: output += "SNAP-PAC-S1"; break;
                case 0x00000083: output += "SNAP-ENET-S64"; break;
                case 0x0000008A: output += "SNAP-UPN-ADS"; break;
                case 0x0000008C: output += "SNAP-UP1-M64"; break;
                case 0x00000092: output += "SNAP-UP1-D64"; break;
                case 0x00000093: output += "SNAP-UP1-ADS"; break;
                case 0x00000094: output += "SNAP-WLAN-FH-ADS"; break;
                case 0x00000097: output += "SNAP-ENET-D64"; break;
                case 0x00000098: output += "SNAP-B3000-ENET or SNAP-ENET-RTC"; break;
                case 0x000000E1: output += "E1"; break;
                case 0x000000E2: output += "E2"; break;
                case 0x00000193: output += "SNAP-LCE"; break;
            }
            return output;
        }
    }
}