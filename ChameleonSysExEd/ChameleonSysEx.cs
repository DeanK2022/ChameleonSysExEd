using ChameleonSysExHelpers;
using ChamSysExFileStructs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonSysExEd
{
    public unsafe class ChameleonSysEx
    {
        private unsafe TChameleonCompositeHeaderHighGain tcch;
        public unsafe TChameleonCompositeHeaderHighGain* composite;
        public TChameleonCompositeHeaderHighGain FromFileStream(FileStream fs)
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
            TChameleonCompositeHeaderHighGain loadedFile = (TChameleonCompositeHeaderHighGain)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TChameleonCompositeHeaderHighGain));
            handle.Free();//Give control of the buffer back to the GC 
            return loadedFile;
        }
        public bool LoadFromFile(string fileName)
        {
            unsafe
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                tcch = FromFileStream(fs);

                fixed (TChameleonCompositeHeaderHighGain* intermediate = &tcch)
                {
                    composite = intermediate;
                };

                fs.Close();
            }
            return true;

        }

        public unsafe class ChameleonCompositeLowGainChorus : ChameleonSysEx
        {
            unsafe public TChameleonCompositeLowGainChorus Composite
            {
                get
                {
                    IntPtr bc = (IntPtr)base.composite; return (*(TChameleonCompositeLowGainChorus*)bc);
                }

            }


        }


    }
    //--------------------------



    public class ChameleonControl //@4-7 
    {
        public byte Code1;         //0x06        
        public byte Code2;         //0x28
        public byte ConfigMode;    //Index into lookup         
                                   //public byte Z1;

        public ChameleonControl(TChameleonControl tcc)
        {
            Code1 = tcc.Code1;
            Code2 = tcc.Code2;
            ConfigMode = tcc.ConfigMode;
        }
    }

    public class ChameleonMixer  //14 public bytes
    {
        public byte MasterVolume;   //0 -> 127
        //public byte Z1;
        private byte leftLevel;      //-57 -> 6
        //public byte Z2;
        private byte rightLevel;     //-57 -> 6
        //public byte Z3;
        public byte MixDir;         //0 -> 100
        //public byte Z4;
        public byte Pan;            //0 -> 100
        //public byte Z5;
        private byte delayLevel; //x00 is -63, x3f is 0, range 0 -> -63 
        //public byte Z6;
        private byte reverbLevel; //x00 is -63, x3f is 0, range 0 -> -63 

        public byte DelayLevel { get => (byte)(delayLevel - 63); set => delayLevel = (byte)(value + 63); }
        public byte ReverbLevel { get => (byte)(reverbLevel - 63); set => reverbLevel = (byte)(value + 63); }
        public byte RightLevel { get => (byte)(rightLevel - 57); set => rightLevel = (byte)(value + 57); }
        public byte LeftLevel { get => (byte)(leftLevel - 57); set => leftLevel = (byte)(value + 57); }

        //public byte Z7;
        public ChameleonMixer(TChameleonMixer tc)
        {
            MasterVolume = tc.MasterVolume;
            leftLevel = tc.LeftLevel;
            rightLevel = tc.RightLevel;
            MixDir = tc.MixDir;
            Pan = tc.Pan;
            delayLevel = tc.DelayLevel;
            ReverbLevel = tc.ReverbLevel;
        }
    }
    public class ChameleonGainLow //@22-33    //12 public bytes
    {
        public byte GainAmount;     //  range 0 - 48 
        //public byte Z1;
        public byte GainType;       //0 -> solid state, pentode, triode A, 3 -> triode B
        //public byte Z2;
        private byte bassLevel;      //0x00 = -15 -> 0x1e 15
        //public byte Z3;
        private byte midLevel;       //0x00 = -15 -> 0x1e 15
        //public byte Z4;
        private byte trebleLevel;    //0x00 = -15 -> 0x1e 15
        //public byte Z5;
        private byte presence;       //0x00 = -15 -> 0x1e 15
        //public byte Z6;

        public ChameleonGainLow(TChameleonGainLow tc)
        {
            GainAmount = tc.GainAmount;
            GainType = tc.GainType;
            bassLevel = tc.BassLevel;
            midLevel = tc.MidLevel;
            trebleLevel = tc.TrebleLevel;
            presence = tc.Presence;
        }

        public byte Presence { get => (byte)(presence - 15); set => presence = (byte)(value + 15); }
        public byte BassLevel { get => (byte)(bassLevel - 15); set => bassLevel = (byte)(value + 15); }
        public byte MidLevel { get => (byte)(midLevel - 15); set => midLevel = (byte)(value + 15); }
        public byte TrebleLevel { get => (byte)(trebleLevel - 15); set => trebleLevel = (byte)(value + 15); }
    }
    public class ChameleonGainHigh
    {
        private byte gainAmount; //12-78
        private byte variac; //0 --> -6
        private byte bassLevel;      //0x00 = -15 -> 0x1e 15
        private byte midLevel;       //0x00 = -15 -> 0x1e 15
        private byte trebleLevel;    //0x00 = -15 -> 0x1e 15
        private byte presence;       //0x00 = -15 -> 0x1e 15

        public ChameleonGainHigh(TChameleonGainLow tc)
        {
            gainAmount = tc.GainAmount;
            Variac = tc.GainType;
            bassLevel = tc.BassLevel;
            midLevel = tc.MidLevel;
            trebleLevel = tc.TrebleLevel;
            presence = tc.Presence;
        }

        public byte Variac { get => (byte)(variac - 6); set => variac = (byte)(value + 6); }
        public byte GainAmount { get => (byte)(gainAmount - 12); set => gainAmount = (byte)(value + 12); }
        public byte Presence { get => (byte)(presence - 15); set => presence = (byte)(value + 15); }
        public byte TrebleLevel { get => (byte)(trebleLevel - 15); set => trebleLevel = (byte)(value + 15); }
        public byte MidLevel { get => (byte)(midLevel - 15); set => midLevel = (byte)(value + 15); }
        public byte BassLevel { get => (byte)(bassLevel - 15); set => bassLevel = (byte)(value + 15); }

    }
    public class ChameleonCompressor
    {
        public byte InOut;
        private byte threshold; //0 to -24 range
        public byte Attack; //lookup  0-7 => 1, 2, 3, 8, 16, 25, 50, 75
        public byte Release; //lookup  0- => 0.055, 0.15 0.25 ... 2.05
        public byte Threshold { get => (byte)(threshold - 24); set => threshold = (byte)(value + 24); }

        public ChameleonCompressor(TChameleonCompressor tc)
        {
            InOut = tc.InOut;
            threshold = tc.Threshold;
            Attack = tc.Attack;
            Release = tc.Release;
        }
    }
    public class ChameleonWah
    {
        public byte WahInOut;
        public byte Freq;
        public ChameleonWah(TChameleonWah tc)
        {
            WahInOut = tc.WahInOut;
            Freq = tc.Freq;
        }
    }
    public class ChameleonHush
    {
        public byte InOut;
        public byte Z1;
        private byte threshold;// range -27 to -90, x3f to 0x00
        public byte Z2;
        public byte Threshold { get => (byte)(threshold - 90); set => threshold = (byte)(value + 90); }

        public ChameleonHush(TChameleonHush tc)
        {
            InOut = tc.InOut;
            threshold = tc.Threshold;
        }
    }

    public class ChameleonPreEQ
    {
        private byte lowFreqLevel; //-15 -> 6
                                   //  public byte Z1;
        public byte LowFreq;
        //   public byte Z2;
        private byte midFreqLevel;  //15 -> 12
                                    //   public byte Z3;
        public byte MidFreq;
        //  public byte Z4;
        public byte MidBand;

        public byte LowFreqLevel { get => (byte)(lowFreqLevel - 15); set => lowFreqLevel = (byte)(value + 15); }
        public byte MidFreqLevel { get => (byte)(midFreqLevel - 15); set => midFreqLevel = (byte)(value + 15); }

        //  public byte Z5;
        public ChameleonPreEQ(TChameleonPreEQ tc)
        {
            lowFreqLevel = tc.LowFreqLevel;
            LowFreq = tc.LowFreq;
            midFreqLevel = tc.MidFreqLevel;
            MidFreq = tc.MidFreq;
            MidBand = tc.MidBand;
        }
    }

    public class ChameleonPostEQ
    {
        public byte BassFreq;
        // public byte Z1;
        public byte BassBand;
        //public byte Z2;
        public byte MidFreq;
        // public byte Z3;
        public byte MidBand;
        // public byte Z4;
        public byte TrebleFreq;
        //public byte Z5;
        public byte TrebleBand;
        //public byte Z6;
        public byte PresFreq;
        //public byte Z7;
        public byte PresBand;
        //public byte Z8;
        public ChameleonPostEQ(TChameleonPostEQ tc)
        {
            BassFreq = tc.BassFreq;
            BassBand = tc.BassBand;
            MidFreq = tc.MidFreq;
            MidBand = tc.MidBand;
            TrebleFreq = tc.TrebleFreq;
            TrebleBand = tc.TrebleBand;
            PresFreq = tc.PresFreq;
            PresBand = tc.PresBand;
        }
    }

    public class ChameleonSpeakerSim
    {
        public byte SpeakerSim;
        public byte Z1;
        public byte SpeakerType;
        public byte Z2;
        private byte micPlace;
        public byte Z3;
        private byte reactance;
        public byte Z4;

        public byte MicPlace { get => (byte)(micPlace - 15); set => micPlace = (byte)(value + 15); }
        public byte Reactance { get => (byte)(reactance - 15); set => reactance = (byte)(value + 15); }

        public ChameleonSpeakerSim(TChameleonSpeakerSim tc)
        {
            SpeakerSim = tc.SpeakerSim;
            SpeakerType = tc.SpeakerType;
            micPlace = tc.MicPlace;
            reactance = tc.Reactance;
        }
    }

    public class ChameleonTremolo
    {
        public byte TremoloInOut;
        public byte Z1;
        public byte TremoloLocation;
        public byte Z2;
        public byte TremoloDepth;
        public byte Z3;
        public byte TremoloRate;
        public byte TremoloRateHigh;
        public byte TremoloShape;
        public byte Z5;
        public ChameleonTremolo(TChameleonTremolo tc)
        {
            TremoloInOut = tc.TremoloInOut;
            TremoloLocation = tc.TremoloLocation;
            TremoloDepth = tc.TremoloDepth;
            TremoloRate = tc.TremoloRate;
            TremoloRateHigh = tc.TremoloRateHigh;
            TremoloShape = tc.TremoloShape;
        }
    }
    public class ChameleonChorus
    {
        public byte ChorusInOut;
        private byte chorus1Level;
        public byte Chorus1Pan;
        public byte Chorus1Depth;
        private byte chorus1Rate;
        private byte chorus1RateHighByte;
        private byte chorus1Delay;
        private byte chorus2Level;
        public byte Chorus2Pan;
        public byte Chorus2Depth;
        private byte chorus2Rate;
        private byte chorus2RateHighByte;
        private byte chorus2Delay;

        public byte Chorus1Level { get => (byte)(chorus1Level - 63); set => chorus1Level = (byte)(value + 63); }
        public byte Chorus2Level { get => (byte)(chorus2Level - 63); set => chorus2Level = (byte)(value + 63); }
        public byte Chorus1Delay { get => (byte)(chorus1Delay + 2); set => chorus1Delay = (byte)(value - 2); }
        public byte Chorus2Delay { get => (byte)(chorus2Delay + 2); set => chorus2Delay = (byte)(value - 2); }
        public short Chorus2Rate { get => (short)((chorus2RateHighByte << 7) + chorus2Rate); set => SetChorus2Rate(value); }
        public short Chorus1Rate { get => (short)((chorus1RateHighByte << 7) + chorus1Rate); set => SetChorus1Rate(value); }

        private void SetChorus1Rate(short newChorusRate)
        {
            chorus1Rate = (byte)newChorusRate;
            chorus1RateHighByte = (byte)(newChorusRate >> 7);
        }
        private void SetChorus2Rate(short newChorusRate)
        {
            chorus2Rate = (byte)newChorusRate;
            chorus2RateHighByte = (byte)(newChorusRate >> 7);
        }
        public ChameleonChorus(TChameleonChorus tc)
        {
            ChorusInOut = tc.ChorusInOut;
            chorus1Level = tc.Chorus1Level;
            Chorus1Pan = tc.Chorus1Pan;
            Chorus1Depth = tc.Chorus1Depth;
            Chorus1Rate = tc.Chorus1Rate;
            chorus1RateHighByte = tc.Chorus1RateHighByte;
            chorus1Delay = tc.Chorus1Delay;
            chorus2Level = tc.Chorus2Level;
            Chorus2Pan = tc.Chorus2Pan;
            Chorus2Depth = tc.Chorus2Depth;
            Chorus2Rate = tc.Chorus2Rate;
            chorus2RateHighByte = tc.Chorus2RateHighByte;
            chorus2Delay = tc.Chorus2Delay;
        }
    }

    public class ChameleonPhaser
    {
        public byte PhaserInOut;        //Depth (0-100)
        public byte Depth;              //Rate (0-253)
        public byte Rate;
        public byte Resonance;          //Resonance (0-100)
        public byte Stage;              //Stages (0-1) 4, 6

        public ChameleonPhaser(TChameleonPhaser tc)
        {
            PhaserInOut = tc.PhaserInOut;
            Depth = tc.Depth;
            Rate = tc.Rate;
            Resonance = tc.Resonance;
            Stage = tc.Stage;
        }
    }

    public class ChameleonDelay
    {
        public byte DelayState;
        public byte Z1;
        public byte MuteType;
        public byte Z2;
        public byte SourceMix;
        public byte Z3;
        public byte Source2;
        public byte Z4;
        public byte HighFreqDamp;
        public byte Z5;
        private byte d1OutLevel;
        public byte Z6;
        public byte D1Pan;
        public byte Z7;
        private byte d1Time;
        private byte d1TimeHighByte;
        private byte d1Regen;
        public byte Z9;
        private byte d2OutLevel;
        public byte Z10;
        public byte D2Pan;
        public byte Z11;
        private byte d2Time;
        private byte d2TimeHighByte;
        private byte d2Regen;
        public byte Z13;

        public short D1Time { get => (short)(((d1TimeHighByte << 7) + d1Time) * 4); set => SetD1Time(value); }
        private void SetD1Time(short newD1Time)
        {
            d1Time = (byte)(newD1Time / 4);
            d1TimeHighByte = (byte)((newD1Time / 4) >> 7);
        }
        public short D2Time { get => (byte)(((d2TimeHighByte << 7) + d2Time) * 4); set => SetD2Time(value); }
        public byte D1OutLevel { get => (byte)(d1OutLevel - 63); set => d1OutLevel = (byte)(value + 63); }
        public byte D1Regen { get => (byte)(d1Regen - 63); set => d1Regen = (byte)(value + 63); }
        public byte D2Regen { get => (byte)(d2Regen - 63); set => d2Regen = (byte)(value + 63); }
        public byte D2OutLevel { get => (byte)(d2OutLevel - 63); set => d2OutLevel = (byte)(value + 63); }

        private void SetD2Time(short newD2Time)
        {
            d2Time = (byte)(newD2Time / 4);
            d2TimeHighByte = (byte)((newD2Time / 4) >> 7);
        }

        public ChameleonDelay(TChameleonDelay tc)
        {
            DelayState = tc.DelayState;
            MuteType = tc.MuteType;
            SourceMix = tc.SourceMix;
            Source2 = tc.Source2;
            HighFreqDamp = tc.HighFreqDamp;
            d1OutLevel = tc.D1OutLevel;
            D1Pan = tc.D1Pan;
            d1Time = tc.D1Time;
            d1TimeHighByte = tc.D1TimeHighByte;
            d1Regen = tc.D1Regen;
            d2OutLevel = tc.D2OutLevel;
            D2Pan = tc.D2Pan;
            d2Time = tc.D2Time;
            d2TimeHighByte = tc.D2TimeHighByte;
            d2Regen = tc.D2Regen;
        }
    }

    public class ChameleonReverb
    {
        public byte ReverbState;
        public byte Z14;
        public byte ReverbMix;
        public byte Z15;
        public byte ReverbDecay;
        public byte Z16;
        public byte ReverbHighFreqDamp;
        public byte Z17;
        public ChameleonReverb(TChameleonReverb tc)
        {
            ReverbState = tc.ReverbState;
            ReverbMix = tc.ReverbMix;
            ReverbDecay = tc.ReverbDecay;
            ReverbHighFreqDamp = tc.ReverbHighFreqDamp;
        }

    }

    public class ChameleonControllerAssignment
    {
        public byte Number;
        public byte Z1;
        public byte Param;
        public byte Z2;
        public byte UpperLimit;
        public byte Z3;
        public byte LowerLimit;
        public byte Z4;
        public ChameleonControllerAssignment(TChameleonControllerAssignment tc)
        {
            Number = tc.Number;
            Param = tc.Param;
            UpperLimit = tc.UpperLimit;
            LowerLimit = tc.LowerLimit;
        }
    }


    public class ChameleonTapDelay
    {
        public byte TapDelayD1Multiplyer;
        public byte Z1;
        public byte TapDelayD2Multiplyer;
        public byte Z2;
        public ChameleonTapDelay(TChameleonTapDelay tc)
        {
            TapDelayD1Multiplyer = tc.TapDelayD1Multiplyer;
            TapDelayD2Multiplyer = tc.TapDelayD2Multiplyer;
        }
    }

    public class ChameleonFlanger
    {
        public byte FlangeInOut;          //Flange (0-1) Off, On
        private byte regeneration;          //-63 -> 0
        private byte level1;               //Level 1 (0-58)
        public byte Pan1;                 //Pan 1 (0-100)
        public byte Depth1;               //Depth 1 (0-100)
        private byte rate1Low;             //Rate 1 (0-253)
        private byte rate1High;
        private byte level2;               //Level 2 (0-58)
        public byte Pan2;                 //Pan 2 (0-100)this
        public byte Depth2;               //Depth 2 (0-100)
        private byte rate2Low;             //Rate 2 (0-253)
        private byte rate2High;

        public byte Regeneration { get => (byte)(regeneration - 63); set => regeneration = (byte)(value + 63); }
        public short Rate1 { get => (short)((rate1High << 7) + rate1Low); set => SetRate1(value); }
        public short Rate2 { get => (short)((rate2High << 7) + rate2Low); set => SetRate2(value); }
        public byte Level1 { get => (byte)(level1 - 63); set => level1 = (byte)(value + 63); }
        public byte Level2 { get => (byte)(level2 - 63); set => level2 = (byte)(value + 63); }
        private void SetRate1(short newRate)
        {
            rate1Low = (byte)newRate;
            rate1High = (byte)(newRate >> 7);
        }
        private void SetRate2(short newRate)
        {
            rate1Low = (byte)newRate;
            rate1High = (byte)(newRate >> 7);
        }
        public ChameleonFlanger(TChameleonFlanger tc)
        {
            FlangeInOut = tc.FlangeInOut;
            regeneration = tc.Regeneration;
            level1 = tc.Level1;
            Pan1 = tc.Pan1;
            Depth1 = tc.Depth1;
            rate1Low = tc.Rate1Low;
            rate1High = tc.Rate1High;
            level2 = tc.Level2;
            Pan2 = tc.Pan2;
            Depth2 = tc.Depth2;
            rate2Low = tc.Rate2Low;
            rate2High = tc.Rate2High;
        }

    }
    public class ChameleonPitchShift
    {
        public byte PitchShiftInOut;
        private byte level;                  //Pitch 1
        public byte Pan;
        private byte pitch;                  //Fine 1 (0-40) -20 to 20 step 1
        private byte pitchHigh;
        private byte fineTune;               //Level 1 (0-58)
        public byte Speed;

        public byte Level { get => (byte)(level - 63); set => level = (byte)(value + 63); }
        public byte FineTune { get => (byte)(fineTune - 20); set => fineTune = (byte)(value + 20); }
        public short Pitch { get => (short)(((pitchHigh << 7) + (pitch) - 120) * 20); set => SetPitch(value); }
        private void SetPitch(short newPitch)
        {
            pitch = (byte)((newPitch / 20) + 120);
            pitchHigh = (byte)(((newPitch / 20) + 120) >> 7);
        }
        public ChameleonPitchShift(TChameleonPitchShift tc)
        {
            PitchShiftInOut = tc.PitchShiftInOut;
            level = tc.Level;
            Pan = tc.Pan;
            pitch = tc.Pitch;
            pitchHigh = tc.PitchHigh;
            fineTune = tc.FineTune;
            Speed = tc.Speed;
        }
    }

    public class ChameleonSysExComplete
    {
        public byte Status;
        public byte ManufCode;
        public byte DeviceID;
        public byte ModelID;
        public ChameleonControl Control;
        public ChameleonMixer Mixer;
        public ChameleonGainLow GainLow;
        public ChameleonGainHigh GainHigh;
        public ChameleonHush Hush;
        public ChameleonPreEQ PreEQ;
        public ChameleonPostEQ PostEQ;
        public ChameleonSpeakerSim SpeakerSim;
        public ChameleonCompressor Compressor;
        public ChameleonChorus Chorus;

        public ChameleonFlanger Flanger;
        public ChameleonPhaser Phaser;
        public ChameleonPitchShift PitchShift;
        public ChameleonTremolo Tremolo;
        public ChameleonWah Wah;

        public ChameleonDelay Delay;
        public ChameleonReverb Reverb;

        //public fixed byte BigGapInMiddle[20];   

        public string Title;               //@156-181
        public ChameleonControllerAssignment[] ControllerAssignment;
        public ChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public ChameleonControllerAssignment ControllerAssignment2;
        public ChameleonControllerAssignment ControllerAssignment3;
        public ChameleonControllerAssignment ControllerAssignment4;
        public ChameleonControllerAssignment ControllerAssignment5;
        public ChameleonControllerAssignment ControllerAssignment6;
        public ChameleonControllerAssignment ControllerAssignment7;
        public ChameleonControllerAssignment ControllerAssignment8;
        public ChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
                                        //public byte Z0;                //252 00
        public ChameleonSysExComplete()
        {

        }
        private TChameleonCompositeHeaderHighGain FromFileStream(FileStream fs)
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
            TChameleonCompositeHeaderHighGain loadedFile = (TChameleonCompositeHeaderHighGain)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TChameleonCompositeHeaderHighGain));
            handle.Free();//Give control of the buffer back to the GC 
            return loadedFile;
        }
        public bool LoadFromFile(string fileName)
        {
            unsafe
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                TChameleonCompositeHeaderHighGain tcch = FromFileStream(fs);
                fs.Close();

                int sizeTChameleonCompositeHeaderHG = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHeaderHighGain));
                int sizeTChameleonCompositeHeaderLG = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHeaderLowGain));
                int sizeTChameleonCompositeLowGainChorus = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainChorus));

                Status = tcch.Status;
                ManufCode = tcch.ManufCode;
                DeviceID = tcch.DeviceID;
                ModelID = tcch.ModelID;
                Control = new ChameleonControl(tcch.Control);
                Mixer = new ChameleonMixer(tcch.Mixer);

                Hush = new ChameleonHush(tcch.Hush);
                PreEQ = new ChameleonPreEQ(tcch.PreEQ);
                PostEQ = new ChameleonPostEQ(tcch.PostEQ);
                SpeakerSim = new ChameleonSpeakerSim(tcch.SpeakerSim);
                IntPtr ptrToTCStruct = (IntPtr)(&tcch);
                if (tcch.Control.ConfigMode > 5)  //low gain, compressor allowed
                {
                    GainLow = new ChameleonGainLow(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->GainLow);
                    Compressor = new ChameleonCompressor(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Compressor);
                }
                else
                {
                    GainHigh = new ChameleonGainHigh(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->GainLow);
                }

                int size = Marshal.SizeOf(typeof(TChameleonCompositeHeaderHighGain));

                size = Marshal.SizeOf(typeof(TChameleonCompositeTailend));

                IntPtr ptrtoDelay = (IntPtr)(&tcch);

                if (ChamObjectHelpers.IsChorus(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        long startDelay = (long)(IntPtr)(&((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Delay) - (long)ptrToTCStruct;
                        long startReverb = (long)(IntPtr)(&((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Reverb) - (long)ptrToTCStruct;
                        TChameleonCompositeLowGainChorus* tclgc;
                        tclgc = (TChameleonCompositeLowGainChorus*)&tcch;
                        ChamObjectHelpers.DumpStructChorus(*tclgc);
                        ChamObjectHelpers.DumpAddresses(*tclgc);
                        Chorus = new ChameleonChorus(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Chorus);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        long startDelay = (long)(IntPtr)(&((TChameleonCompositeHighGainChorus*)ptrToTCStruct)->Delay) - (long)ptrToTCStruct;
                        long startReverb = (long)(IntPtr)(&((TChameleonCompositeHighGainChorus*)ptrToTCStruct)->Reverb) - (long)ptrToTCStruct;
                        TChameleonCompositeHighGainChorus* tclgc;
                        tclgc = (TChameleonCompositeHighGainChorus*)&tcch;
                        ChamObjectHelpers.DumpStructChorusHigh(*tclgc);
                        ChamObjectHelpers.DumpAddressesHigh(*tclgc);
                        Chorus = new ChameleonChorus(((TChameleonCompositeHighGainChorus*)ptrToTCStruct)->Chorus);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainChorus*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainChorus*)ptrToTCStruct)->Reverb);
                    }
                }
                if (ChamObjectHelpers.IsFlanger(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        ChamObjectHelpers.DumpStructFlanger(*(TChameleonCompositeLowGainFlanger*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainFlanger*)ptrToTCStruct);
                        Flanger = new ChameleonFlanger(((TChameleonCompositeLowGainFlanger*)ptrToTCStruct)->Flanger);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainFlanger*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainFlanger*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        ChamObjectHelpers.DumpStructFlangerHigh(*(TChameleonCompositeHighGainFlanger*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddressesHigh(*(TChameleonCompositeHighGainFlanger*)ptrToTCStruct);
                        Flanger = new ChameleonFlanger(((TChameleonCompositeHighGainFlanger*)ptrToTCStruct)->Flanger);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainFlanger*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainFlanger*)ptrToTCStruct)->Reverb);
                    }
                }

                if (ChamObjectHelpers.IsTremolo(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        ChamObjectHelpers.DumpStructTremolo(*(TChameleonCompositeLowGainTremolo*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainTremolo*)ptrToTCStruct);
                        Tremolo = new ChameleonTremolo(((TChameleonCompositeLowGainTremolo*)ptrToTCStruct)->Tremolo);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainTremolo*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainTremolo*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        ChamObjectHelpers.DumpStructTremoloHigh(*(TChameleonCompositeHighGainTremolo*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddressesHigh(*(TChameleonCompositeHighGainTremolo*)ptrToTCStruct);
                        Tremolo = new ChameleonTremolo(((TChameleonCompositeHighGainTremolo*)ptrToTCStruct)->Tremolo);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainTremolo*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainTremolo*)ptrToTCStruct)->Reverb);
                    }
                }
                if (ChamObjectHelpers.IsPitchShift(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        ChamObjectHelpers.DumpStructPitchShift(*(TChameleonCompositeLowGainPitchShift*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainPitchShift*)ptrToTCStruct);
                        PitchShift = new ChameleonPitchShift(((TChameleonCompositeLowGainPitchShift*)ptrToTCStruct)->PitchShift);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainPitchShift*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainPitchShift*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        ChamObjectHelpers.DumpStructPitchShiftHigh(*(TChameleonCompositeHighGainPitchShift*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddressesHigh(*(TChameleonCompositeHighGainPitchShift*)ptrToTCStruct);
                        PitchShift = new ChameleonPitchShift(((TChameleonCompositeHighGainPitchShift*)ptrToTCStruct)->PitchShift);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainPitchShift*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainPitchShift*)ptrToTCStruct)->Reverb);
                    }
                }
                if (ChamObjectHelpers.IsWah(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        ChamObjectHelpers.DumpStructWah(*(TChameleonCompositeLowGainWah*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainWah*)ptrToTCStruct);
                        Wah = new ChameleonWah(((TChameleonCompositeLowGainWah*)ptrToTCStruct)->Wah);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainWah*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainWah*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        ChamObjectHelpers.DumpStructWahHigh(*(TChameleonCompositeHighGainWah*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddressesHigh(*(TChameleonCompositeHighGainWah*)ptrToTCStruct);
                        Wah = new ChameleonWah(((TChameleonCompositeHighGainWah*)ptrToTCStruct)->Wah);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainWah*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainWah*)ptrToTCStruct)->Reverb);
                    }
                }
                if (ChamObjectHelpers.IsPhaser(tcch.Control.ConfigMode))
                {
                    if (tcch.Control.ConfigMode > 5)
                    {
                        ChamObjectHelpers.DumpStructPhaser(*(TChameleonCompositeLowGainPhaser*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainPhaser*)ptrToTCStruct);
                        Phaser = new ChameleonPhaser(((TChameleonCompositeLowGainPhaser*)ptrToTCStruct)->Phaser);
                        Delay = new ChameleonDelay(((TChameleonCompositeLowGainPhaser*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeLowGainPhaser*)ptrToTCStruct)->Reverb);
                    }
                    else
                    {
                        ChamObjectHelpers.DumpStructPhaserHigh(*(TChameleonCompositeHighGainPhaser*)ptrToTCStruct);
                        ChamObjectHelpers.DumpAddressesHigh(*(TChameleonCompositeHighGainPhaser*)ptrToTCStruct);
                        Phaser = new ChameleonPhaser(((TChameleonCompositeHighGainPhaser*)ptrToTCStruct)->Phaser);
                        Delay = new ChameleonDelay(((TChameleonCompositeHighGainPhaser*)ptrToTCStruct)->Delay);
                        Reverb = new ChameleonReverb(((TChameleonCompositeHighGainPhaser*)ptrToTCStruct)->Reverb);
                    }
                }

                IntPtr ptrToTailEndStruct = (IntPtr)(&tcch);
                TChameleonCompositeTailend* tailend = (TChameleonCompositeTailend*)ptrToTailEndStruct;
                long startTitle = (long)(IntPtr)(&((TChameleonCompositeTailend*)ptrToTCStruct)->Title) - (long)ptrToTCStruct;
                //long startReverb = (long)(IntPtr)(&((TChameleonCompositeLowGainChorus*)ptrToTCStruct)->Delay) - (long)ptrToTCStruct;

                Title = ChamObjectHelpers.ConvertToString(tailend->Title, Constants.TITLE_LEN_BYTE);
                ControllerAssignment1 = new ChameleonControllerAssignment(tailend->ControllerAssignment1);
                ControllerAssignment2 = new ChameleonControllerAssignment(tailend->ControllerAssignment2);
                ControllerAssignment3 = new ChameleonControllerAssignment(tailend->ControllerAssignment3);
                ControllerAssignment4 = new ChameleonControllerAssignment(tailend->ControllerAssignment4);
                ControllerAssignment5 = new ChameleonControllerAssignment(tailend->ControllerAssignment5);
                ControllerAssignment6 = new ChameleonControllerAssignment(tailend->ControllerAssignment6);
                ControllerAssignment7 = new ChameleonControllerAssignment(tailend->ControllerAssignment7);
                ControllerAssignment8 = new ChameleonControllerAssignment(tailend->ControllerAssignment8);

                ControllerAssignment = new ChameleonControllerAssignment[8];
                ControllerAssignment[0] = ControllerAssignment1;
                ControllerAssignment[1] = ControllerAssignment2;
                ControllerAssignment[2] = ControllerAssignment3;
                ControllerAssignment[3] = ControllerAssignment4;
                ControllerAssignment[4] = ControllerAssignment5;
                ControllerAssignment[5] = ControllerAssignment6;
                ControllerAssignment[6] = ControllerAssignment7;
                ControllerAssignment[7] = ControllerAssignment8;

                TapDelay = new ChameleonTapDelay(tailend->TapDelay);

                CheckSum = tailend->CheckSum;

            }
            return true;


        }
    }
}

