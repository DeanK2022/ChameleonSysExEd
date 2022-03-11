using ChamSysExFileStructs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonSysExHelpers
{
    public struct ConfigModeStruct
    {
        static readonly string[] ConfigModes = new string[]
        {
           "High Gain, Chorus, Delay, Reverb",              //0  IN FILE High-Gain, Chorus, Delay, Reverb
           "High Gain, Flanger, Delay, Reverb",             //1          High-Gain, Flanger, Delay, Reverb
           "High Gain, Tremolo, Delay, Reverb",             //2          High-Gain, Tremolo, Delay, Reverb
           "High Gain, Pitch Shift, Delay, Reverb",         //3          High-Gain, Pitch Shift, Delay, Reverb
           "Wah, High Gain, Delay, Reverb",                 //4          Wah, High-Gain, Delay, Reverb
           "Phaser, High Gain, Delay, Reverb",              //5          Phaser, High-Gain, Delay, Reverb
           "Low Gain, Chorus, Delay, Reverb",               //6          Low-Gain, Chorus, Delay, Reverb
           "Low Gain, Flange, Delay, Reverb",               //7          Low-Gain, Flanger, Delay, Reverb
           "Low Gain, Tremolo, Delay, Reverb",              //8          Low-Gain, Tremolo, Delay, Reverb
           "Low Gain, Pitch Shift, Delay, Reverb",          //9          Low-Gain, Pitch Shift, Delay, Reverb
           "Wah, Low Gain, Delay, Reverb",          //10         Wah, Low-Gain, Delay, Reverb
           "Phaser, Low Gain, Delay, Reverb"        //11         Phaser, Low-Gain, Delay, Reverb

       };
    }
    
    public static unsafe class ChamObjectHelpers
    {
        public static string GetEffect(int configIdx)
        {
            switch (configIdx)
            {
                case 0:
                case 6: return "Chorus";

                case 1:
                case 7: return "Flanger";

                case 2:
                case 8: return "Tremolo";

                case 3:
                case 9: return "Pitch Shift";

                case 4:
                case 10: return "Wah";

                case 5:
                case 11: return "Phaser";
            }
            return "ERROR";
        }
        public static bool IsChorus(int configIdx)
        {
            return GetEffect(configIdx) == "Chorus";
        }
        public static bool IsFlanger(int configIdx)
        {
            return GetEffect(configIdx) == "Flanger";
        }
        public static bool IsTremolo(int configIdx)
        {
            return GetEffect(configIdx) == "Tremolo";
        }
        public static bool IsPitchShift(int configIdx)
        {
            return GetEffect(configIdx) == "Pitch Shift";
        }
        public static bool IsWah(int configIdx)
        {
            return GetEffect(configIdx) == "Wah";
        }
        public static bool IsPhaser(int configIdx)
        {
            return GetEffect(configIdx) == "Phaser";
        }
        unsafe public static string ConvertToString(char* charArr, int cnt)
        {
            string retStr = "";
            for (int idx = 0; idx < cnt; idx++)
            {
                retStr += Convert.ToChar(charArr[idx]);
            }
            return retStr;
        }
        public static string ConvertToString(byte[] arr)
        {
            unsafe
            {
                string returnStr;
                fixed (byte* fixedPtr = arr)
                {
                    returnStr = new string((sbyte*)fixedPtr);
                }
                return (returnStr);
            }
        }
        unsafe public static string ConvertToString(byte* byteArr, int cnt)
        {
            string retStr = "";
            for (int idx = 0; idx < cnt; idx++)
            {
                if (byteArr[idx] !=0)
                    retStr += Convert.ToChar(byteArr[idx]);
            }
            return retStr;
        }
        unsafe public static string ConvertToString(byte byteVal)
        {
            string retStr = "";
            retStr += Convert.ToChar(byteVal);
            return retStr;
        }
        unsafe public static void DumpFieldsByte(string fieldName, byte* byteArr, int cnt)
        {
            System.Console.Write(fieldName + " [");
            for (int idx = 0; idx < cnt; idx++)
            {
                System.Console.Write(Convert.ToChar(byteArr[idx]));
            }
            System.Console.Write("] Hex dump: [");
            for (int idx = 0; idx < cnt; idx++)
            {
                System.Console.Write("{0:X} ", (byteArr[idx]));
            }
            System.Console.WriteLine("]");
        }
        unsafe public static void DumpFieldsChar(string fieldName, char* charArr, int cnt)
        {
            System.Console.Write(fieldName + " [");
            for (int idx = 0; idx < cnt; idx++)
            {
                System.Console.Write(Convert.ToChar(charArr[idx]));
            }
            System.Console.Write("] Hex dump: [");
            for (int idx = 0; idx < cnt; idx++)
            {
                System.Console.Write("{0:X} ", (charArr[idx]));
            }
            System.Console.WriteLine("]");
        }
        public static void DumpFields<T>(long baseAddr, long fieldAddr, T Instance)
        {
            var sourceFields = typeof(T).GetFields();

            System.Console.WriteLine(typeof(T).GetTypeInfo().Name + " Start {0}", fieldAddr - baseAddr);
            foreach (var sourceProperty in sourceFields)
            {
                System.Console.WriteLine("\t" + sourceProperty.Name + " = " + sourceProperty.GetValue(Instance) + " [0x{0:X}]", sourceProperty.GetValue(Instance));
            }
        }
        public static void DumpStructChorus(TChameleonCompositeLowGainChorus tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.Chorus,  tcc.Chorus);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay,tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb,tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1,tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2,tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3,tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4,tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5,tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6,tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7,tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8,tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructFlanger(TChameleonCompositeLowGainFlanger tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.Flanger, tcc.Flanger);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructPhaser(TChameleonCompositeLowGainPhaser tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.Phaser, tcc.Phaser);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructTremolo(TChameleonCompositeLowGainTremolo tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.Tremolo, tcc.Tremolo);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructPitchShift(TChameleonCompositeLowGainPitchShift tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.PitchShift, tcc.PitchShift);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, Constants.PITCHSHIFT_LG_BIG_GAP_LEN); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructWah(TChameleonCompositeLowGainWah tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainLow, tcc.GainLow);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Compressor, tcc.Compressor);
                DumpFields((long)&tcc, (long)&tcc.Wah, tcc.Wah);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStruct(TChameleonCompositeHighGainDONOTUSE tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer,tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh,tcc.GainHigh);
                
                DumpFields((long)&tcc, (long)&tcc.Hush,tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ,tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ,tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim,tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Chorus, tcc.Chorus);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay,tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb,tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1,tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2,tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3,tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4,tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5,tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6,tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7,tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8,tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructChorusHigh(TChameleonCompositeHighGainChorus tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Chorus, tcc.Chorus);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructFlangerHigh(TChameleonCompositeHighGainFlanger tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Flanger, tcc.Flanger);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructPhaserHigh(TChameleonCompositeHighGainPhaser tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Phaser, tcc.Phaser);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructTremoloHigh(TChameleonCompositeHighGainTremolo tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Tremolo, tcc.Tremolo);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructPitchShiftHigh(TChameleonCompositeHighGainPitchShift tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.PitchShift, tcc.PitchShift);  //DK needs some recasting depending on Control value as to what FX is active, Chorus, Flanger...
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, Constants.PITCHSHIFT_LG_BIG_GAP_LEN); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static void DumpStructWahHigh(TChameleonCompositeHighGainWah tcc)
        {
            unsafe
            {
                DumpFieldsByte("Status", &tcc.Status, 1);
                DumpFieldsByte("Manuf", &tcc.ManufCode, 1);
                DumpFieldsByte("DeviceID", &tcc.DeviceID, 1);
                DumpFieldsByte("ModelID", &tcc.ModelID, 1);
                DumpFields((long)&tcc, (long)&tcc.Control, tcc.Control);
                DumpFields((long)&tcc, (long)&tcc.Mixer, tcc.Mixer);
                DumpFields((long)&tcc, (long)&tcc.GainHigh, tcc.GainHigh);
                DumpFields((long)&tcc, (long)&tcc.Hush, tcc.Hush);
                DumpFields((long)&tcc, (long)&tcc.PreEQ, tcc.PreEQ);
                DumpFields((long)&tcc, (long)&tcc.PostEQ, tcc.PostEQ);
                DumpFields((long)&tcc, (long)&tcc.SpeakerSim, tcc.SpeakerSim);
                DumpFields((long)&tcc, (long)&tcc.Wah, tcc.Wah);  
                DumpFields((long)&tcc, (long)&tcc.Delay, tcc.Delay);
                DumpFields((long)&tcc, (long)&tcc.Reverb, tcc.Reverb);
                DumpFieldsByte("BigGapInMiddle", tcc.BigGapInMiddle, 28); //28
                DumpFieldsByte("Title", tcc.Title, Constants.TITLE_LEN_BYTE);//26
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment1, tcc.ControllerAssignment1);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment2, tcc.ControllerAssignment2);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment3, tcc.ControllerAssignment3);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment4, tcc.ControllerAssignment4);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment5, tcc.ControllerAssignment5);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment6, tcc.ControllerAssignment6);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment7, tcc.ControllerAssignment7);
                DumpFields((long)&tcc, (long)&tcc.ControllerAssignment8, tcc.ControllerAssignment8);
                DumpFields((long)&tcc, (long)&tcc.TapDelay, tcc.TapDelay);        //@246 - 249
                DumpFieldsByte("CheckSum", &tcc.CheckSum, 1);             //@250 checksum (bytes 7-4
                DumpFieldsByte("Eox", &tcc.Eox, 1);               //@251 0xF7
            }
        }
        public static TChameleonCompositeLowGainChorus FromFileStream(FileStream fs)
        {
            //Create Buffer
            byte[] buff = new byte[Marshal.SizeOf(typeof(TChameleonCompositeHeaderHighGain))];
            int amt = 0;
            //Loop until we've read enough bytes (usually once) 
            while (amt < buff.Length)
                amt += fs.Read(buff, amt, buff.Length - amt); //Read bytes 
                                                              //Make sure that the Garbage Collector doesn't move our buffer 
            GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
            //Marshal the bytes
            TChameleonCompositeLowGainChorus loadedFile = (TChameleonCompositeLowGainChorus)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TChameleonCompositeLowGainChorus));
            handle.Free();//Give control of the buffer back to the GC 
            return loadedFile;
        }
        public static int ToFileStream(FileStream fs, TChameleonCompositeHeaderHighGain tcc)
        {

            int bytesWritten = 0;
            return bytesWritten;
        }
        public static int Output(string field, int start, int offset)
        {
            Console.WriteLine(field + " @" + start + "-" + (start + offset - 1));
            return start + offset;
        }
        public static long DumpDiff(byte* baseAddr, byte* secondAddr, byte* firstAddr, string secondName, string firstName)
        {

            Console.WriteLine($"[base: {(long)baseAddr:X}] [base -> {firstName}: {(long)firstAddr - (long)baseAddr}] [{firstName} -> {secondName} {(long)secondAddr-(long)firstAddr}] [base -> {secondName} {(long)secondAddr - (long)baseAddr}] |{(long)firstAddr - (long)baseAddr}-{(long)secondAddr - (long)baseAddr -1}");
            return ((long)secondAddr - (long)firstAddr);
        }
        public static void DumpAddresses(TChameleonCompositeLowGainChorus tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainLow", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Chorus, (byte*)&tcc.Compressor, "tcc.Chorus", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Chorus, "tcc.Delay", "tcc.Chorus");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddresses(TChameleonCompositeLowGainFlanger tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainLow", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Flanger, (byte*)&tcc.Compressor, "tcc.Flanger", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Flanger, "tcc.Delay", "tcc.Flanger");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddresses(TChameleonCompositeLowGainPhaser tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainLow", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Phaser, (byte*)&tcc.Compressor, "tcc.Phaser", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Phaser, "tcc.Delay", "tcc.Phaser");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddresses(TChameleonCompositeLowGainTremolo tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainLow", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Tremolo, (byte*)&tcc.Compressor, "tcc.Tremolo", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Tremolo, "tcc.Delay", "tcc.Tremolo");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddresses(TChameleonCompositeLowGainPitchShift tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainLow", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PitchShift, (byte*)&tcc.Compressor, "tcc.PitchShift", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.PitchShift, "tcc.Delay", "tcc.PitchShift");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddresses(TChameleonCompositeLowGainWah tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainLow, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainLow, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Compressor, (byte*)&tcc.SpeakerSim, "tcc.Compressor", "tcc.SpeakerSim");                     //@72-93
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Wah, (byte*)&tcc.Compressor, "tcc.Wah", "tcc.Compressor");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Wah, "tcc.Delay", "tcc.Wah");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainChorus tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Chorus, (byte*)&tcc.SpeakerSim, "tcc.Chorus", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Chorus, "tcc.Delay", "tcc.Chorus");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainFlanger tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainLow");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Flanger, (byte*)&tcc.SpeakerSim, "tcc.Flanger", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Flanger, "tcc.Delay", "tcc.Flanger");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainPhaser tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Phaser, (byte*)&tcc.SpeakerSim, "tcc.Phaser", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Phaser, "tcc.Delay", "tcc.Phaser");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainTremolo tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Tremolo, (byte*)&tcc.SpeakerSim, "tcc.Tremolo", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Tremolo, "tcc.Delay", "tcc.Tremolo");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainPitchShift tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PitchShift, (byte*)&tcc.SpeakerSim, "tcc.PitchShift", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.PitchShift, "tcc.Delay", "tcc.PitchShift");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
        public static void DumpAddressesHigh(TChameleonCompositeHighGainWah tcc)
        {
            long curOffset = 0;

            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc, (byte*)&tcc.Status, "tcc", "tcc.Status");                                           //0xF0(@0)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ManufCode, (byte*)&tcc.Status, "tcc.ManufCode", "tcc.Status");                       //@1
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.DeviceID, (byte*)&tcc.ManufCode, "tcc.DeviceID", "tcc.ManufCode");                   //@2
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ModelID, (byte*)&tcc.DeviceID, "tcc.ModelID", "tcc.DeviceID");                       //@3     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Control, (byte*)&tcc.ModelID, "tcc.Control", "tcc.ModelID");                         //@4-7     
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Mixer, (byte*)&tcc.Control, "tcc.Mixer", "tcc.Control");                             //@8-21
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.GainHigh, (byte*)&tcc.Mixer, "tcc.GainHigh", "tcc.Mixer");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Hush, (byte*)&tcc.GainHigh, "tcc.Hush", "tcc.GainHigh");                               //@34-37
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PreEQ, (byte*)&tcc.Hush, "tcc.PreEQ", "tcc.Hush");                                   //@38-47
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.PostEQ, (byte*)&tcc.PreEQ, "tcc.PostEQ", "tcc.PreEQ");                               //@48-63
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.SpeakerSim, (byte*)&tcc.PostEQ, "tcc.SpeakerSim", "tcc.PostEQ");                     //@64-71
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Wah, (byte*)&tcc.SpeakerSim, "tcc.Wah", "tcc.SpeakerSim");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Delay, (byte*)&tcc.Wah, "tcc.Delay", "tcc.Wah");                               //@94-119
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Reverb, (byte*)&tcc.Delay, "tcc.Reverb", "tcc.Delay");                               //@120-127
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.BigGapInMiddle[0], (byte*)&tcc.Reverb, "tcc.BigGapInMiddle[20]", " tcc.Reverb");      //@128-155 //BIG 
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Title[0], (byte*)&tcc.BigGapInMiddle[0], "tcc.Title[0]", "tcc.BigGapInMiddle[20]");          //@156-181
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment1, (byte*)&tcc.Title[0], "tcc.ControllerAssignment1", "tcc.Title[0]");   //64 Bytes @182-245
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment2, (byte*)&tcc.ControllerAssignment1, "tcc.ControllerAssignment2", "tcc.ControllerAssignment1");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment3, (byte*)&tcc.ControllerAssignment2, "tcc.ControllerAssignment3", "tcc.ControllerAssignment2");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment4, (byte*)&tcc.ControllerAssignment3, "tcc.ControllerAssignment4", "tcc.ControllerAssignment3");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment5, (byte*)&tcc.ControllerAssignment4, "tcc.ControllerAssignment5", "tcc.ControllerAssignment4");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment6, (byte*)&tcc.ControllerAssignment5, "tcc.ControllerAssignment6", "tcc.ControllerAssignment5");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment7, (byte*)&tcc.ControllerAssignment6, "tcc.ControllerAssignment7", "tcc.ControllerAssignment6");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.ControllerAssignment8, (byte*)&tcc.ControllerAssignment7, "tcc.ControllerAssignment8", "tcc.ControllerAssignment7");
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.TapDelay, (byte*)&tcc.ControllerAssignment8, "tcc.TapDelay", "tcc.ControllerAssignment8");   //@246 - 249
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.CheckSum, (byte*)&tcc.TapDelay, "tcc.CheckSum", "tcc.TapDelay");                             //@250 checksum (bytes 7-456 XOR)
            curOffset += DumpDiff((byte*)&tcc, (byte*)&tcc.Eox, (byte*)&tcc.CheckSum, "tcc.Eox", "tcc.CheckSum");                                       //@251 0xF7
        }
    }
}
