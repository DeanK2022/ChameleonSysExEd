using System;
using Melanchall.DryWetMidi.Multimedia;

namespace InputDeviceExample
{
    class Program
    {
        private static IInputDevice _inputDevice;

        static void Main(string[] args)
        {
            _inputDevice = InputDevice.GetByName("USB2.0-MIDI");
            _inputDevice.EventReceived += OnEventReceived;
            _inputDevice.StartEventsListening();

            Console.WriteLine("Input device is listening for events. Press any key to exit...");
            Console.ReadKey();

            (_inputDevice as IDisposable)?.Dispose();
        }

        private static void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            var midiDevice = (MidiDevice)sender;
            Console.WriteLine($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
        }
    }
}