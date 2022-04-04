using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChameleonSysExEd
{
    public partial class ImportMIDIForm : Form
    {
        InputDevice inputDevice;
        private int midiOptionInDeviceID = -1;
        private List<InputDevice> recordingInputDevices = null;
        public List<ChameleonSysExComplete> sysExList;
        public int sysExStart;
        public ImportMIDIForm(int midiInDeviceID)
        {
            InitializeComponent();
            midiOptionInDeviceID = midiInDeviceID;
            inputDevice = new InputDevice(midiOptionInDeviceID, true, false);
            var capabilities = InputDevice.GetDeviceCapabilities(midiOptionInDeviceID);
            lbImportDeviceName.Text = capabilities.name + " (ID " + inputDevice.DeviceID + ")";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop.Enabled = true;
                btnImport.Enabled = false;
                inputDevice.SysExMessageReceived += InputDevice_SysExMessageReceived;
                //inputDevice.MessageReceived += InputDevice_MessageReceived1;
                recordingInputDevices = new List<InputDevice>();
                inputDevice.StartRecording();
                recordingInputDevices.Add(inputDevice);
            }
            catch (InputDeviceException ex)
            {
                lbReceived.Text = "An error occurred when recording";
            }
        }
        private void InputDevice_SysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            var message = e.Message;
                        
            try
            {
                lbReceived.Text = e.Message.Length + " bytes";   // stop recording on all devices and dispose of the resources

                ChameleonSysExComplete sysEx = new ChameleonSysExComplete();
                sysEx.FromByteArr(message.GetBytes());
                sysExList.Add(sysEx);
                sysExStart++;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error occurred when receiving a sysex message " + ex);
                lbReceived.Text = "Error: " + ex;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnImport.Enabled = true;

            foreach (var inputDevice in recordingInputDevices)
            {
                inputDevice.StopRecording();
                inputDevice.Dispose();
            }
            inputDevice.SysExMessageReceived -= InputDevice_SysExMessageReceived;
            recordingInputDevices = null;
        }
    }
}
