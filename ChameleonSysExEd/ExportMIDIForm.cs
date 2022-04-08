using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChameleonSysExEd
{
    public partial class ExportMIDIForm : Form
    {
        private OutputDevice outputDevice;
        private int midiOptionOutDeviceID = -1;
        public List<ChameleonSysExComplete> sysExList;
        int sysExIdx = -1;
        public int sendDelay = 200;
        public ExportMIDIForm(int midiOutDeviceID)
        {
            InitializeComponent();
            midiOptionOutDeviceID = midiOutDeviceID;
            outputDevice = new OutputDevice(midiOptionOutDeviceID);
            var capabilities = OutputDevice.GetDeviceCapabilities(midiOptionOutDeviceID);
            lbExportDeviceName.Text = capabilities.name + " (ID " + outputDevice.DeviceID + ")";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int msgCnt = 0;
            int byteCnt = 0;

            btnStop.Enabled = true;
            btnExport.Enabled = false;

            outputDevice.Error += OutputDevice_Error;
            foreach (var msg in sysExList)
            {
                byte [] myBytes = msg.ToByteArray();
                SysExMessage msgOut = new SysExMessage(msg.ToByteArray());
                outputDevice.Send(msgOut);
                msgCnt++;
                byteCnt += myBytes.Length;
                lbSentStatus.Text = msgCnt + " messages, " + byteCnt + " bytes sent";
                Thread.Sleep(sendDelay);
            }
        }

        private void OutputDevice_Error(object sender, Sanford.Multimedia.ErrorEventArgs e)
        {
            lbSentStatus.Text = "ERROR: " + e.ToString();
        }
    }
}
