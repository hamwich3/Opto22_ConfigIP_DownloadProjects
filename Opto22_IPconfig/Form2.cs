using Opto22.OptoMMP3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opto22_IPconfig
{
    public partial class Form2 : Form
    {
        Form1 callingForm;
        Opto22Device pac;
        int port;
        int timeout;

        public Form2(Form1 form, Opto22Device pac, int port, int timeout)
        {
            InitializeComponent();
            callingForm = form;
            this.pac = pac;
            this.port = port;
            this.timeout = timeout;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            SendChange();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            callingForm.Enabled = false;
            ipIPAddress.IPAddress = pac.IPAddress;
            ipSubnetMask.IPAddress = pac.Subnet;
            ipGateway.IPAddress = pac.Gateway;
            ipDns.IPAddress = pac.Dns;
            groupBox1.Enabled = false;
            getTCPPort();
        }

        private void getTCPPort()
        {
            OptoMMP mmp = new OptoMMP();
            int success = mmp.Open(pac.IPAddress.ToString(), port, OptoMMP.Connection.UdpIp, timeout, true);
            int[] data = new int[1];
            success = mmp.ReadInts(Opto22Device.portMemoryAddress, 1, data, 0);
            if (success != 0)
            {
                MessageBox.Show("Problem reading TCP port!");
            }
            else
            {
                tbPort.Text = data[0].ToString();
            }
            mmp.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            callingForm.Enabled = true;
            callingForm.Activate();
            callingForm.Show();
        }

        private void SendChange()
        {
            OptoMMP mmp = new OptoMMP();

            var newIpBytes = ipIPAddress.IPAddress.GetAddressBytes();
            var newSubnetBytes = ipSubnetMask.IPAddress.GetAddressBytes();
            var newGatewayBytes = ipGateway.IPAddress.GetAddressBytes();
            var newDnsBytes = ipDns.IPAddress.GetAddressBytes();

            uint newIp = 0;
            uint newSubnet = 0;
            uint newGateway = 0;
            uint newDns = 0;

            for (int i = 0; i < 4; i++)
            {
                newIp |= (uint)newIpBytes[i] << (24 - (i * 8));
                newSubnet |= (uint)newSubnetBytes[i] << (24 - (i * 8));
                newGateway |= (uint)newGatewayBytes[i] << (24 - (i * 8));
                newDns |= (uint)newDnsBytes[i] << (24 - (i * 8));
            }

            string pacIpAddr = pac.IPAddress.ToString();
            int success = mmp.Open(pacIpAddr, port, OptoMMP.Connection.UdpIp, timeout, true);
            if (success != 0)
            {
                MessageBox.Show("Error opening connection to PAC!");
                return;
            }

            ulong[] ipValue = new ulong[1];
            ulong[] subnetValue = new ulong[1];
            ulong[] gatewayValue = new ulong[1];
            ulong[] dnsValue = new ulong[1];
            uint[] portValue = new uint[1];

            ipValue[0] = ((ulong)newIp << 32) + ~newIp;
            subnetValue[0] = ((ulong)newSubnet << 32) + ~newSubnet;
            gatewayValue[0] = ((ulong)newGateway << 32) + ~newGateway;
            dnsValue[0] = ((ulong)newDns << 32) + ~newDns;
            portValue[0] = Convert.ToUInt32(tbPort.Text);

            mmp.WriteULongs(Opto22Device.ipMemoryAddress, 1, ipValue, 0);
            //Thread.Sleep(100);
            mmp.WriteULongs(Opto22Device.subnetMemoryAddress, 1, subnetValue, 0);
            //Thread.Sleep(100);
            mmp.WriteULongs(Opto22Device.gatewayMemoryAddress, 1, gatewayValue, 0);
            //Thread.Sleep(100);
            mmp.WriteULongs(Opto22Device.dnsMemoryAddress, 1, dnsValue, 0);
            //Thread.Sleep(100);
            mmp.WriteUints(Opto22Device.portMemoryAddress, 1, portValue, 0);
            Console.WriteLine(portValue[0]);
            //Thread.Sleep(100);

            mmp.WriteStatusCommand(OptoMMP.StatusWriteCommand.ResetHardware);
            mmp.Close();
            callingForm.RemoveChangedPAC(pac);
            MessageBox.Show("Changes Written!");
            this.Close();
        }

        private void ipSubnetMask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ipSubnetMask.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             groupBox1.Enabled = checkBox1.Checked;
        }
    }
}
