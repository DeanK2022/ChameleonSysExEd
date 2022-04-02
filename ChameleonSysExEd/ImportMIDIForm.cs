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
        public int midiOptionInDeviceID = -1;
        private List<InputDevice> recordingInputDevices = null;
        public ImportMIDIForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                var inputDevice = new InputDevice(midiOptionInDeviceID, true, false);
                var capabilities = InputDevice.GetDeviceCapabilities(midiOptionInDeviceID);
                lbStatus.Text = "Recording on " + inputDevice.DeviceID + " " + capabilities.name;

                inputDevice.SysExMessageReceived += InputDevice_SysExMessageReceived;
                //inputDevice.MessageReceived += InputDevice_MessageReceived1;
                recordingInputDevices = new List<InputDevice>();
                inputDevice.StartRecording();
                recordingInputDevices.Add(inputDevice);

            }
            catch (InputDeviceException ex)
            {
                lbStatus.Text = "An error occurred when recording";
            }
        }
        private void InputDevice_SysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            //DialogHost.CloseDialogCommand.Execute(null, null);

            // get our recorded message
            var message = e.Message;

            // save our recoreded sysex message to disk in a new file and add it to the library
            try
            {
                lbStatus.Text = "Got SysEx " + e.Message.Length + " bytes";   // stop recording on all devices and dispose of the resources
                foreach (var inputDevice in recordingInputDevices)
                {
                    inputDevice.StopRecording();
                    inputDevice.Dispose();
                }

                recordingInputDevices = null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error occurred when receiving a sysex message " + ex);
                lbStatus.Text = "Error: " + ex;
            }
        }
    }
}
