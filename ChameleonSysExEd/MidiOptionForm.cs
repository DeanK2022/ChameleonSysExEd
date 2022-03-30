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
    public partial class MidiOptionForm : Form
    {
        public MidiOptionForm()
        {
            InitializeComponent();

            cbMidiInDevice.Items.Clear();
      
            for (var i = 0; i < InputDevice.DeviceCount; i++)
            {
                //var inputDevice = new InputDevice(i, true, false);
                var capabilities = InputDevice.GetDeviceCapabilities(i);
                cbMidiInDevice.Items.Add(capabilities.name);              
            }
            if (InputDevice.DeviceCount > 0)
                cbMidiInDevice.SelectedIndex = 0;

            cbMidiOutDevice.Items.Clear();

            for (var i = 0; i < OutputDevice.DeviceCount; i++)
            {
                //var outputDevice = new OutputDevice(i, true, false);
                var capabilities = OutputDevice.GetDeviceCapabilities(i);
                cbMidiOutDevice.Items.Add(capabilities.name);
            }
            if (OutputDevice.DeviceCount > 0)
                cbMidiOutDevice.SelectedIndex = 0;

        }
        public int GetMidiInDeviceID ()
        {
            return cbMidiInDevice.SelectedIndex;
        }
        public int GetMidiOutDeviceID()
        {
            return cbMidiOutDevice.SelectedIndex;
        }
        public int GetMidiOutDelay()
        {
            return (int)nudSendDelay.Value;
        }
    }
}
