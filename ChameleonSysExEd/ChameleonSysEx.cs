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
                    IntPtr bc = (IntPtr)base.composite;
                    return (*(TChameleonCompositeLowGainChorus*)bc);
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

        public ChameleonControl()
        {
            Code1 = 6;
            Code2 = 40; //0x28
        }

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

        public sbyte DelayLevel { get => (sbyte)(delayLevel - 63); set => delayLevel = (byte)(value + 63); }
        public sbyte ReverbLevel { get => (sbyte)(reverbLevel - 63); set => reverbLevel = (byte)(value + 63); }
        public sbyte RightLevel { get => (sbyte)(rightLevel - 57); set => rightLevel = (byte)(value + 57); }
        public sbyte LeftLevel { get => (sbyte)(leftLevel - 57); set => leftLevel = (byte)(value + 57); }

        //public byte Z7;
        public ChameleonMixer(TChameleonMixer tc)
        {
            MasterVolume = tc.MasterVolume;
            leftLevel = tc.LeftLevel;
            rightLevel = tc.RightLevel;
            MixDir = tc.MixDir;
            Pan = tc.Pan;
            delayLevel = tc.DelayLevel;
            reverbLevel = tc.ReverbLevel;
        }

        public ChameleonMixer()
        {
        }

        unsafe public void ToStruct(TChameleonMixer* dst)
        {
            dst->MasterVolume = MasterVolume;
            dst->Z1 = 0;
            dst->LeftLevel = leftLevel;
            dst->Z2 = 0;
            dst->RightLevel = rightLevel;
            dst->Z3 = 0;
            dst->MixDir = MixDir;
            dst->Z4 = 0;
            dst->Pan = Pan;
            dst->Z5 = 0;
            dst->DelayLevel = delayLevel;
            dst->Z6 = 0;
            dst->ReverbLevel = reverbLevel;
            dst->Z7 = 0;
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

        public ChameleonGainLow()
        {
        }

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

        public sbyte Presence { get => (sbyte)(presence - 15); set => presence = (byte)(value + 15); }
        public sbyte BassLevel { get => (sbyte)(bassLevel - 15); set => bassLevel = (byte)(value + 15); }
        public sbyte MidLevel { get => (sbyte)(midLevel - 15); set => midLevel = (byte)(value + 15); }
        public sbyte TrebleLevel { get => (sbyte)(trebleLevel - 15); set => trebleLevel = (byte)(value + 15); }
        unsafe public void ToStruct(TChameleonGainLow* dst)
        {
            dst->GainAmount = GainAmount;
            dst->Z1 = 0;
            dst->GainType = GainType;
            dst->Z2 = 0;
            dst->BassLevel = bassLevel;
            dst->Z3 = 0;
            dst->MidLevel = midLevel;
            dst->Z4 = 0;
            dst->TrebleLevel = trebleLevel;
            dst->Z5 = 0;
            dst->Presence = presence;
            dst->Z6 = 0;
        }

    }
    public class ChameleonGainHigh
    {
        private byte gainAmount; //12-78
        private byte variac; //0 --> -6
        private byte bassLevel;      //0x00 = -15 -> 0x1e 15
        private byte midLevel;       //0x00 = -15 -> 0x1e 15
        private byte trebleLevel;    //0x00 = -15 -> 0x1e 15
        private byte presence;       //0x00 = -15 -> 0x1e 15

        public ChameleonGainHigh()
        {
        }

        public ChameleonGainHigh(TChameleonGainLow tc)
        {
            gainAmount = tc.GainAmount;
            variac = tc.GainType;
            bassLevel = tc.BassLevel;
            midLevel = tc.MidLevel;
            trebleLevel = tc.TrebleLevel;
            presence = tc.Presence;
        }

        public sbyte Variac { get => (sbyte)(variac - 6); set => variac = (byte)(value + 6); }
        public byte GainAmount { get => (byte)(gainAmount - 12); set => gainAmount = (byte)(value + 12); }
        public sbyte Presence { get => (sbyte)(presence - 15); set => presence = (byte)(value + 15); }
        public sbyte TrebleLevel { get => (sbyte)(trebleLevel - 15); set => trebleLevel = (byte)(value + 15); }
        public sbyte MidLevel { get => (sbyte)(midLevel - 15); set => midLevel = (byte)(value + 15); }
        public sbyte BassLevel { get => (sbyte)(bassLevel - 15); set => bassLevel = (byte)(value + 15); }
        unsafe public void ToStruct(TChameleonGainHigh* dst)
        {
            dst->GainAmount = gainAmount;
            dst->Z1 = 0;
            dst->Variac = variac;
            dst->Z2 = 0;
            dst->BassLevel = bassLevel;
            dst->Z3 = 0;
            dst->MidLevel = midLevel;
            dst->Z4 = 0;
            dst->TrebleLevel = trebleLevel;
            dst->Z5 = 0;
            dst->Presence = presence;
            dst->Z6 = 0;
        }
    }
    public class ChameleonCompressor
    {
        public byte InOut;
        private byte threshold; //0 to -24 range
        public byte Attack; //lookup  0-7 => 1, 2, 3, 8, 16, 25, 50, 75
        public byte Release; //lookup  0- => 0.055, 0.15 0.25 ... 2.05
        public sbyte Threshold { get => (sbyte)(threshold - 24); set => threshold = (byte)(value + 24); }

        public ChameleonCompressor(TChameleonCompressor tc)
        {
            InOut = tc.InOut;
            threshold = tc.Threshold;
            Attack = tc.Attack;
            Release = tc.Release;
        }

        public ChameleonCompressor()
        {
        }

        unsafe public void ToStruct(TChameleonCompressor* dst)
        {
            dst->InOut = InOut;
            dst->Z1 = 0;
            dst->Threshold = threshold;
            dst->Z2 = 0;
            dst->Attack = Attack;
            dst->Z3 = 0;
            dst->Release = Release;
            dst->Z4 = 0;

        }
    }
    public class ChameleonWah
    {
        public byte WahInOut;
        public byte Freq;

        public ChameleonWah()
        {
        }

        public ChameleonWah(TChameleonWah tc)
        {
            WahInOut = tc.WahInOut;
            Freq = tc.Freq;
        }

        unsafe public void ToStruct(TChameleonWah* dst)
        {
            dst->WahInOut = WahInOut;
            dst->Freq = Freq;
        }
    }
    public class ChameleonHush
    {
        public byte InOut;
        public byte Z1;
        private byte threshold;// range -27 to -90, x3f to 0x00
        public byte Z2;
        public sbyte Threshold { get => (sbyte)(threshold - 90); set => threshold = (byte)(value + 90); }

        public ChameleonHush(TChameleonHush tc)
        {
            InOut = tc.InOut;
            threshold = tc.Threshold;
        }

        public ChameleonHush()
        {
        }

        unsafe public void ToStruct(TChameleonHush* dst)
        {
            dst->InOut = InOut;
            dst->Z1 = 0;
            dst->Threshold = threshold;
            dst->Z2 = 0;
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

        public sbyte LowFreqLevel { get => (sbyte)(lowFreqLevel - 15); set => lowFreqLevel = (byte)(value + 15); }
        public sbyte MidFreqLevel { get => (sbyte)(midFreqLevel - 15); set => midFreqLevel = (byte)(value + 15); }

        //  public byte Z5;
        public ChameleonPreEQ(TChameleonPreEQ tc)
        {
            lowFreqLevel = tc.LowFreqLevel;
            LowFreq = tc.LowFreq;
            midFreqLevel = tc.MidFreqLevel;
            MidFreq = tc.MidFreq;
            MidBand = tc.MidBand;
        }

        public ChameleonPreEQ()
        {
        }

        unsafe public void ToStruct(TChameleonPreEQ* dst)
        {
            dst->LowFreqLevel = lowFreqLevel;
            dst->Z1 = 0;
            dst->LowFreq = LowFreq;
            dst->Z2 = 0;
            dst->MidFreqLevel = midFreqLevel;
            dst->Z3 = 0;
            dst->MidFreq = MidFreq;
            dst->Z4 = 0;
            dst->MidBand = MidBand;
            dst->Z5 = 0;

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

        public ChameleonPostEQ()
        {
        }

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
        unsafe public void ToStruct(TChameleonPostEQ* dst)
        {
            dst->BassFreq = BassFreq;
            dst->Z1 = 0;
            dst->BassBand = BassBand;
            dst->Z2 = 0;
            dst->MidFreq = MidFreq;
            dst->Z3 = 0;
            dst->MidBand = MidBand;
            dst->Z4 = 0;
            dst->TrebleFreq = TrebleFreq;
            dst->Z5 = 0;
            dst->TrebleBand = TrebleBand;
            dst->Z6 = 0;
            dst->PresFreq = PresFreq;
            dst->Z7 = 0;
            dst->PresBand = PresBand;
            dst->Z8 = 0;

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

        public sbyte MicPlace { get => (sbyte)(micPlace - 15); set => micPlace = (byte)(value + 15); }
        public sbyte Reactance { get => (sbyte)(reactance - 15); set => reactance = (byte)(value + 15); }

        public ChameleonSpeakerSim(TChameleonSpeakerSim tc)
        {
            SpeakerSim = tc.SpeakerSim;
            SpeakerType = tc.SpeakerType;
            micPlace = tc.MicPlace;
            reactance = tc.Reactance;
        }

        public ChameleonSpeakerSim()
        {
        }

        unsafe public void ToStruct(TChameleonSpeakerSim* dst)
        {
            dst->SpeakerSim = SpeakerSim;
            dst->Z1 = 0;
            dst->SpeakerType = SpeakerType;
            dst->Z2 = 0;
            dst->MicPlace = micPlace;
            dst->Z3 = 0;
            dst->Reactance = reactance;
            dst->Z4 = 0;
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
        private byte tremoloRate;
        private byte tremoloRateHigh;
        public byte TremoloShape;
        public byte Z5;

        public short TremoloRate { get => (short)((tremoloRateHigh << 7) + tremoloRate); set => SetRate(value); }
        private void SetRate(short value)
        {
            tremoloRate = (byte)value;
            tremoloRateHigh = (byte)(value >> 7);
        }
        public ChameleonTremolo(TChameleonTremolo tc)
        {
            TremoloInOut = tc.TremoloInOut;
            TremoloLocation = tc.TremoloLocation;
            TremoloDepth = tc.TremoloDepth;
            tremoloRate = tc.TremoloRate;
            tremoloRateHigh = tc.TremoloRateHigh;
            TremoloShape = tc.TremoloShape;
        }

        public ChameleonTremolo()
        {
        }

        unsafe public void ToStruct(TChameleonTremolo* dst)
        {
            dst->TremoloInOut = TremoloInOut;
            dst->Z1 = 0;
            dst->TremoloLocation = TremoloLocation;
            dst->Z2 = 0;
            dst->TremoloDepth = TremoloDepth;
            dst->Z3 = 0;
            dst->TremoloRate = tremoloRate;
            dst->TremoloRateHigh = tremoloRateHigh;
            dst->TremoloShape = TremoloShape;
            dst->Z5 = 0;

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

        public sbyte Chorus1Level { get => (sbyte)(chorus1Level - 63); set => chorus1Level = (byte)(value + 63); }
        public sbyte Chorus2Level { get => (sbyte)(chorus2Level - 63); set => chorus2Level = (byte)(value + 63); }
        public byte Chorus1Delay { get => (byte)(chorus1Delay + 2); set => chorus1Delay = (byte)(value - 2); }
        public byte Chorus2Delay { get => (byte)(chorus2Delay + 2); set => chorus2Delay = (byte)(value - 2); }
        public short Chorus2Rate { get => (short)((chorus2RateHighByte << 7) + chorus2Rate); set => SetChorus2Rate(value); }
        public short Chorus1Rate { get => (short)((chorus1RateHighByte << 7) + chorus1Rate); set => SetChorus1Rate(value); }

        private void SetChorus1Rate(short newChorusRate)
        {
            chorus1RateHighByte = (byte)(newChorusRate >> 7);
            chorus1Rate = (byte)(newChorusRate - (chorus1RateHighByte<<7));
            
        }
        private void SetChorus2Rate(short newChorusRate)
        {
            chorus2RateHighByte = (byte)(newChorusRate >> 7);
            chorus2Rate = (byte)(newChorusRate - (chorus2RateHighByte << 7));

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

        public ChameleonChorus()
        {
        }

        unsafe public void ToStruct(TChameleonChorus* dst)
        {
            dst->ChorusInOut = ChorusInOut;
            dst->Z1 = 0;
            dst->Chorus1Level = chorus1Level;
            dst->Z2 = 0;
            dst->Chorus1Pan = Chorus1Pan;
            dst->Z3 = 0;
            dst->Chorus1Depth = Chorus1Depth;
            dst->Z4 = 0;
            dst->Chorus1Rate = chorus1Rate;
            dst->Chorus1RateHighByte = chorus1RateHighByte;
            dst->Chorus1Delay = chorus1Delay;
            dst->Z6 = 0;
            dst->Chorus2Level = chorus2Level;
            dst->Z7 = 0;
            dst->Chorus2Pan = Chorus2Pan;
            dst->Z8 = 0;
            dst->Chorus2Depth = Chorus2Depth;
            dst->Z9 = 0;
            dst->Chorus2Rate = chorus2Rate;
            dst->Chorus2RateHighByte = chorus2RateHighByte;
            dst->Chorus2Delay = chorus2Delay;
            dst->Z11 = 0;
        }
    }

    public class ChameleonPhaser
    {
        public byte PhaserInOut;        //Depth (0-100)
        public byte Depth;              //Rate (0-253)
        public byte Rate;
        public byte Resonance;          //Resonance (0-100)
        public byte Stage;              //Stages (0-1) 4, 6

        public ChameleonPhaser()
        {
        }

        public ChameleonPhaser(TChameleonPhaser tc)
        {
            PhaserInOut = tc.PhaserInOut;
            Depth = tc.Depth;
            Rate = tc.Rate;
            Resonance = tc.Resonance;
            Stage = tc.Stage;
        }
        unsafe public void ToStruct(TChameleonPhaser* dst)
        {
            dst->PhaserInOut = PhaserInOut;
            dst->Z1 = 0;
            dst->Depth = Depth;
            dst->Z2 = 0;
            dst->Rate = Rate;
            dst->Z3 = 0;
            dst->Resonance = Resonance;
            dst->Z4 = 0;
            dst->Stage = Stage;
            dst->Z5 = 0;
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
            d1TimeHighByte = (byte)((newD1Time / 4) >> 7);
            d1Time = (byte)((newD1Time / 4) - (d1TimeHighByte<<7));
        
        }
        public short D2Time { get => (short)(((d2TimeHighByte << 7) + d2Time) * 4); set => SetD2Time(value); }
        public sbyte D1OutLevel { get => (sbyte)(d1OutLevel - 63); set => d1OutLevel = (byte)(value + 63); }
        public sbyte D1Regen { get => (sbyte)(d1Regen - 63); set => d1Regen = (byte)(value + 63); }
        public sbyte D2Regen { get => (sbyte)(d2Regen - 63); set => d2Regen = (byte)(value + 63); }
        public sbyte D2OutLevel { get => (sbyte)(d2OutLevel - 63); set => d2OutLevel = (byte)(value + 63); }

        private void SetD2Time(short newD2Time)
        {
            d2TimeHighByte = (byte)((newD2Time / 4) >> 7);
            d2Time = (byte)((newD2Time / 4) - (d2TimeHighByte << 7));
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

        public ChameleonDelay()
        {
        }

        unsafe public void ToStruct(TChameleonDelay* dst)
        {
            dst->DelayState = DelayState;
            dst->Z1 = 0;
            dst->MuteType = MuteType;
            dst->Z2 = 0;
            dst->SourceMix = SourceMix;
            dst->Z3 = 0;
            dst->Source2 = Source2;
            dst->Z4 = 0;
            dst->HighFreqDamp = HighFreqDamp;
            dst->Z5 = 0;
            dst->D1OutLevel = d1OutLevel;
            dst->Z6 = 0;
            dst->D1Pan = D1Pan;
            dst->Z7 = 0;
            dst->D1Time = d1Time;
            dst->D1TimeHighByte = d1TimeHighByte;
            dst->D1Regen = d1Regen;
            dst->Z9 = 0;
            dst->D2OutLevel = d2OutLevel;
            dst->Z10 = 0;
            dst->D2Pan = D2Pan;
            dst->Z11 = 0;
            dst->D2Time = d2Time;
            dst->D2TimeHighByte = d2TimeHighByte;
            dst->D2Regen = d2Regen;
            dst->Z13 = 0;

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

        public ChameleonReverb()
        {
        }

        public ChameleonReverb(TChameleonReverb tc)
        {
            ReverbState = tc.ReverbState;
            ReverbMix = tc.ReverbMix;
            ReverbDecay = tc.ReverbDecay;
            ReverbHighFreqDamp = tc.ReverbHighFreqDamp;
        }
        unsafe public void ToStruct(TChameleonReverb* dst)
        {
            dst->ReverbState = ReverbState;
            dst->Z14 = 0;
            dst->ReverbMix = ReverbMix;
            dst->Z15 = 0;
            dst->ReverbDecay = ReverbDecay;
            dst->Z16 = 0;
            dst->ReverbHighFreqDamp = ReverbHighFreqDamp;
            dst->Z17 = 0;
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

        public ChameleonControllerAssignment()
        {
        }

        public ChameleonControllerAssignment(TChameleonControllerAssignment tc)
        {
            Number = tc.Number;
            Param = tc.Param;
            UpperLimit = tc.UpperLimit;
            LowerLimit = tc.LowerLimit;
        }
        unsafe public void ToStruct(TChameleonControllerAssignment* dest)
        {
            dest->Number = Number;
            dest->Z1 = 0;
            dest->Param = Param;
            dest->Z2 = 0;
            dest->UpperLimit = UpperLimit;
            dest->Z3 = 0;
            dest->LowerLimit = LowerLimit;
            dest->Z4 = 0;
        }
    }

    public class ChameleonTapDelay
    {
        public byte TapDelayD1Multiplyer;
        public byte Z1;
        public byte TapDelayD2Multiplyer;
        public byte Z2;

        public ChameleonTapDelay()
        {
        }

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

        public sbyte Regeneration { get => (sbyte)(regeneration - 63); set => regeneration = (byte)(value + 63); }
        public short Rate1 { get => (short)((rate1High << 7) + rate1Low); set => SetRate1(value); }
        public short Rate2 { get => (short)((rate2High << 7) + rate2Low); set => SetRate2(value); }
        public sbyte Level1 { get => (sbyte)(level1 - 63); set => level1 = (byte)(value + 63); }
        public sbyte Level2 { get => (sbyte)(level2 - 63); set => level2 = (byte)(value + 63); }
        private void SetRate1(short newRate)
        {
            rate1Low = (byte)newRate;
            rate1High = (byte)(newRate >> 7);
        }
        private void SetRate2(short newRate)
        {
            rate2Low = (byte)newRate;
            rate2High = (byte)(newRate >> 7);
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

        public ChameleonFlanger()
        {
        }

        unsafe public void ToStruct(TChameleonFlanger* dst)
        {
            dst->FlangeInOut = FlangeInOut;
            dst->Z0 = 0;
            dst->Level1 = level1;
            dst->Z1 = 0;
            dst->Pan1 = Pan1;
            dst->Z2 = 0;
            dst->Depth1 = Depth1;
            dst->Z3 = 0;
            dst->Rate1Low = rate1Low;
            dst->Rate1High = rate1High;
            dst->Level2 = level2;
            dst->Z5 = 0;
            dst->Pan2 = Pan2;
            dst->Z6 = 0;
            dst->Depth2 = Depth2;
            dst->Z7 = 0;
            dst->Rate2Low = rate2Low;
            dst->Rate2High = rate2High;
            dst->Regeneration = regeneration;
            dst->Z8 = 0;

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

        public sbyte Level { get => (sbyte)(level - 63); set => level = (byte)(value + 63); }
        public sbyte FineTune { get => (sbyte)(fineTune - 20); set => fineTune = (byte)(value + 20); }
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

        public ChameleonPitchShift()
        {
        }

        unsafe public void ToStruct(TChameleonPitchShift* dst)
        {
            dst->PitchShiftInOut = PitchShiftInOut;
            dst->Z0 = 0;
            dst->Level = level;
            dst->Z1 = 0;
            dst->Pan = Pan;
            dst->Z2 = 0;
            dst->Pitch = pitch;
            dst->PitchHigh = pitchHigh;
            dst->FineTune = fineTune;
            dst->Z4 = 0;
            dst->Speed = Speed;
            dst->Z5 = 0;
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
        public ChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
                                        //public byte Z0;                //252 00
        public ChameleonSysExComplete()
        {
            Status =(byte)240; //F0
            ManufCode =0;
            DeviceID=0;
            ModelID=41;//0x29



            Control = new ChameleonControl();
            Mixer = new ChameleonMixer();
            GainLow = new ChameleonGainLow();
            GainHigh = new ChameleonGainHigh();
            Hush = new ChameleonHush();
            PreEQ = new ChameleonPreEQ();
            PostEQ = new ChameleonPostEQ();
            SpeakerSim = new ChameleonSpeakerSim();
            Compressor = new ChameleonCompressor();
            Chorus = new ChameleonChorus();

            Flanger = new ChameleonFlanger();
            Phaser = new ChameleonPhaser();
            PitchShift = new ChameleonPitchShift();
            Tremolo = new ChameleonTremolo();
            Wah = new ChameleonWah();

            Delay = new ChameleonDelay();
            Reverb = new ChameleonReverb();

            ControllerAssignment = new ChameleonControllerAssignment[8];
            for (int idx =0; idx < Constants.MAX_CONTROLLER_COUNT;idx++)
                ControllerAssignment[idx] = new ChameleonControllerAssignment();

            TapDelay = new ChameleonTapDelay();
            Eox = 0xf7;
        }
        private TChameleonCompositeHeaderHighGain FromFileStreamHG(FileStream fs)
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
        private TChameleonCompositeAllStructsUnion FromFileStream(FileStream fs)
        {
            //Create Buffer
            byte[] buff = new byte[Marshal.SizeOf(typeof(TChameleonCompositeAllStructsUnion))];
            int amt = 0;
            //Loop until we've read enough bytes (usually once) 
            while (amt < buff.Length)
                amt += fs.Read(buff, amt, buff.Length - amt); //Read bytes 
                                                              //Make sure that the Garbage Collector doesn't move our buffer 
            GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
            //Marshal the bytes
            TChameleonCompositeAllStructsUnion loadedFile = (TChameleonCompositeAllStructsUnion)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TChameleonCompositeAllStructsUnion));
            handle.Free();//Give control of the buffer back to the GC 
            return loadedFile;
        }
        public bool LoadFromFile(string fileName, List<ChameleonSysExComplete> sysExList, ref int sysExStart)
        {
            Console.WriteLine("From File Load " + fileName);
            unsafe
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);

                if (fs.Length % sizeof(TChameleonCompositeHeaderHighGain) != 0)
                    return false;

                long sysExCnt = fs.Length / sizeof(TChameleonCompositeHeaderHighGain);

                for (int sysExIdx = 0; sysExIdx < sysExCnt; sysExIdx++)
                {
                    TChameleonCompositeAllStructsUnion casu = FromFileStream(fs);

                    LoadFromStruct(casu);
                    sysExStart++;
                    sysExList.Add(this);
                    
                }
                fs.Close();
            }
            return true;

        }

        unsafe public byte[] StructureToByteArray(TChameleonCompositeAllStructsUnion* obj)
        {
            int len = Marshal.SizeOf(*obj);

            byte[] arr = new byte[len];

            IntPtr ptr = Marshal.AllocHGlobal(len);

            Marshal.StructureToPtr(*obj, ptr, true);

            Marshal.Copy(ptr, arr, 0, len);

            Marshal.FreeHGlobal(ptr);

            return arr;
        }
        public byte[] ToByteArray()
        {
            unsafe
            {
                TChameleonCompositeAllStructsUnion asu;
                asu.HighGainHeader.Status = Status;
                asu.HighGainHeader.ManufCode = ManufCode;
                asu.HighGainHeader.DeviceID = DeviceID;
                asu.HighGainHeader.ModelID = ModelID;

                asu.HighGainHeader.Control.Code1 = Control.Code1;
                asu.HighGainHeader.Control.Code2 = Control.Code2;
                asu.HighGainHeader.Control.ConfigMode = Control.ConfigMode;
                asu.HighGainHeader.Control.Z1 = 0;

                Mixer.ToStruct(&asu.HighGainHeader.Mixer);
                Hush.ToStruct(&asu.HighGainHeader.Hush);
                PreEQ.ToStruct(&asu.HighGainHeader.PreEQ);
                PostEQ.ToStruct(&asu.HighGainHeader.PostEQ);
                SpeakerSim.ToStruct(&asu.HighGainHeader.SpeakerSim);

                for (int i = 0; i < Constants.TITLE_LEN_BYTE; i += 2)
                {
                    asu.TailEnd.Title[i] = (byte)32;
                    asu.TailEnd.Title[i+1] = (byte)0;
                }
                for (int i = 0; i < Title.Length * 2; i += 2)
                {
                    asu.TailEnd.Title[i] = (byte)Title[i/2];
                    asu.TailEnd.Title[i+1] = (byte)0;
                }

                ControllerAssignment[0].ToStruct(&asu.TailEnd.ControllerAssignment1);
                ControllerAssignment[1].ToStruct(&asu.TailEnd.ControllerAssignment2);
                ControllerAssignment[2].ToStruct(&asu.TailEnd.ControllerAssignment3);
                ControllerAssignment[3].ToStruct(&asu.TailEnd.ControllerAssignment4);
                ControllerAssignment[4].ToStruct(&asu.TailEnd.ControllerAssignment5);
                ControllerAssignment[5].ToStruct(&asu.TailEnd.ControllerAssignment6);
                ControllerAssignment[6].ToStruct(&asu.TailEnd.ControllerAssignment7);
                ControllerAssignment[7].ToStruct(&asu.TailEnd.ControllerAssignment8);
                

                asu.TailEnd.TapDelay.TapDelayD1Multiplyer = TapDelay.TapDelayD1Multiplyer;
                asu.TailEnd.TapDelay.Z1 = 0;
                asu.TailEnd.TapDelay.TapDelayD2Multiplyer = TapDelay.TapDelayD2Multiplyer;
                asu.TailEnd.TapDelay.Z2 = 0;
                asu.TailEnd.Eox = Eox;

                if (asu.HighGainHeader.Control.ConfigMode > 5) // low gain
                {
                    Compressor.ToStruct(&asu.LowGainHeader.Compressor);
                    GainLow.ToStruct(&asu.LowGainHeader.Gain);

                    if (ChamObjectHelpers.IsChorus(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Chorus.ToStruct(&asu.LowGainChorus.Chorus);
                        Delay.ToStruct(&asu.LowGainChorus.Delay);
                        Reverb.ToStruct(&asu.LowGainChorus.Reverb);
                    }
                    if (ChamObjectHelpers.IsFlanger(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Flanger.ToStruct(&asu.LowGainFlanger.Flanger);
                        Delay.ToStruct(&asu.LowGainFlanger.Delay);
                        Reverb.ToStruct(&asu.LowGainFlanger.Reverb);
                    }
                    if (ChamObjectHelpers.IsPhaser(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Phaser.ToStruct(&asu.LowGainPhaser.Phaser);
                        Delay.ToStruct(&asu.LowGainPhaser.Delay);
                        Reverb.ToStruct(&asu.LowGainPhaser.Reverb);
                        Console.WriteLine("From ToByteArray");
                        ChamObjectHelpers.DumpStructPhaser(*(TChameleonCompositeLowGainPhaser*)&asu);
                        ChamObjectHelpers.DumpAddresses(*(TChameleonCompositeLowGainPhaser*)&asu);
                    }
                    if (ChamObjectHelpers.IsPitchShift(asu.HighGainHeader.Control.ConfigMode))
                    {
                        PitchShift.ToStruct(&asu.LowGainPitchShift.PitchShift);
                        Delay.ToStruct(&asu.LowGainPitchShift.Delay);
                        Reverb.ToStruct(&asu.LowGainPitchShift.Reverb);
                    }
                    if (ChamObjectHelpers.IsTremolo(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Tremolo.ToStruct(&asu.LowGainTremolo.Tremolo);
                        Delay.ToStruct(&asu.LowGainTremolo.Delay);
                        Reverb.ToStruct(&asu.LowGainTremolo.Reverb);
                    }
                    if (ChamObjectHelpers.IsWah(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Wah.ToStruct(&asu.LowGainWah.Wah);
                        Delay.ToStruct(&asu.LowGainWah.Delay);
                        Reverb.ToStruct(&asu.LowGainWah.Reverb);
                    }
                }
                else
                {
                    GainHigh.ToStruct(&asu.HighGainHeader.Gain);

                    if (ChamObjectHelpers.IsChorus(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Chorus.ToStruct(&asu.HighGainChorus.Chorus);
                        Delay.ToStruct(&asu.HighGainChorus.Delay);
                        Reverb.ToStruct(&asu.HighGainChorus.Reverb);
                    }
                    if (ChamObjectHelpers.IsFlanger(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Flanger.ToStruct(&asu.HighGainFlanger.Flanger);
                        Delay.ToStruct(&asu.HighGainFlanger.Delay);
                        Reverb.ToStruct(&asu.HighGainFlanger.Reverb);
                    }
                    if (ChamObjectHelpers.IsPhaser(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Phaser.ToStruct(&asu.HighGainPhaser.Phaser);
                        Delay.ToStruct(&asu.HighGainPhaser.Delay);
                        Reverb.ToStruct(&asu.HighGainPhaser.Reverb);
                    }
                    if (ChamObjectHelpers.IsPitchShift(asu.HighGainHeader.Control.ConfigMode))
                    {
                        PitchShift.ToStruct(&asu.HighGainPitchShift.PitchShift);
                        Delay.ToStruct(&asu.HighGainPitchShift.Delay);
                        Reverb.ToStruct(&asu.HighGainPitchShift.Reverb);
                    }
                    if (ChamObjectHelpers.IsTremolo(asu.HighGainHeader.Control.ConfigMode))
                    {
                        Tremolo.ToStruct(&asu.HighGainTremolo.Tremolo);
                        Delay.ToStruct(&asu.HighGainTremolo.Delay);
                        Reverb.ToStruct(&asu.HighGainTremolo.Reverb);
                    }
                    if (ChamObjectHelpers.IsWah(asu.HighGainHeader.Control.ConfigMode))
                    {       
                        Wah.ToStruct(&asu.HighGainWah.Wah);
                        Delay.ToStruct(&asu.HighGainWah.Delay);
                        Reverb.ToStruct(&asu.HighGainWah.Reverb);
                    }
                    
                }
                IntPtr myPtr;
                if (asu.HighGainHeader.Control.ConfigMode > 5)
                    myPtr = (IntPtr)(&asu.LowGainHeader);

                byte[] bytes= StructureToByteArray(&asu);
                byte xorRunValue = 0;
                for (int i = 6; i < 250; i++)
                    xorRunValue = (byte)(xorRunValue ^ bytes[i]);  //sum the XOR of the data, ignoring const midi header
                bytes[250] = (byte)xorRunValue;
                return bytes;
            }
        }
        public unsafe void FromByteArr(byte[] arr)
        {
            TChameleonCompositeAllStructsUnion tcasu = ByteArrToStruct(arr);
           
            //TChameleonCompositeAllStructsUnion casu = new TChameleonCompositeAllStructsUnion();

            //int size = Marshal.SizeOf(casu);
            //IntPtr ptr = Marshal.AllocHGlobal(size);
            //Marshal.Copy(arr, 0, ptr, size);

            //casu = (TChameleonCompositeAllStructsUnion)Marshal.PtrToStructure(ptr, casu.GetType());
            
            LoadFromStruct(tcasu);
           // Marshal.FreeHGlobal(ptr);
        }
        public unsafe TChameleonCompositeAllStructsUnion ByteArrToStruct(byte[] arr)
        {
            TChameleonCompositeAllStructsUnion casu = new TChameleonCompositeAllStructsUnion();
          
            int len = arr.Length;
            IntPtr arrPtr;
            fixed(byte* v = &arr[0])
            { 
                arrPtr = (IntPtr)v;
            
                Marshal.PtrToStructure(arrPtr, casu.GetType());
            }
            return casu;
        }
        public unsafe void LoadFromStruct (TChameleonCompositeAllStructsUnion tcch)
        {
            Status = tcch.HighGainHeader.Status;
            ManufCode = tcch.HighGainHeader.ManufCode;
            DeviceID = tcch.HighGainHeader.DeviceID;
            ModelID = tcch.HighGainHeader.ModelID;
            Control = new ChameleonControl(tcch.HighGainHeader.Control);
            Mixer = new ChameleonMixer(tcch.HighGainHeader.Mixer);

            Hush = new ChameleonHush(tcch.HighGainHeader.Hush);
            PreEQ = new ChameleonPreEQ(tcch.HighGainHeader.PreEQ);
            PostEQ = new ChameleonPostEQ(tcch.HighGainHeader.PostEQ);
            SpeakerSim = new ChameleonSpeakerSim(tcch.HighGainHeader.SpeakerSim);
            IntPtr ptrToTCStruct = (IntPtr)(&tcch);

            TChameleonCompositeAllStructsUnion* asu = (TChameleonCompositeAllStructsUnion*)&tcch;
            byte[] bytes = StructureToByteArray(asu);

            //calc and apply checksum
            byte xorRunValue = 0;
            for (int i = 6; i < 250; i++)
                xorRunValue = (byte)(xorRunValue ^ bytes[i]);  //XOR

            bytes[250] = xorRunValue;

            if (tcch.HighGainHeader.Control.ConfigMode > 5)  //low gain, compressor allowed
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

            if (ChamObjectHelpers.IsChorus(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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
            if (ChamObjectHelpers.IsFlanger(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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

            if (ChamObjectHelpers.IsTremolo(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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
            if (ChamObjectHelpers.IsPitchShift(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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
            if (ChamObjectHelpers.IsWah(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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
            if (ChamObjectHelpers.IsPhaser(tcch.HighGainHeader.Control.ConfigMode))
            {
                if (tcch.HighGainHeader.Control.ConfigMode > 5)
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

            ControllerAssignment = new ChameleonControllerAssignment[Constants.MAX_CONTROLLER_COUNT];
            ControllerAssignment[0] = new ChameleonControllerAssignment(tailend->ControllerAssignment1);
            ControllerAssignment[1] = new ChameleonControllerAssignment(tailend->ControllerAssignment2);
            ControllerAssignment[2] = new ChameleonControllerAssignment(tailend->ControllerAssignment3);
            ControllerAssignment[3] = new ChameleonControllerAssignment(tailend->ControllerAssignment4);
            ControllerAssignment[4] = new ChameleonControllerAssignment(tailend->ControllerAssignment5);
            ControllerAssignment[5] = new ChameleonControllerAssignment(tailend->ControllerAssignment6);
            ControllerAssignment[6] = new ChameleonControllerAssignment(tailend->ControllerAssignment7);
            ControllerAssignment[7] = new ChameleonControllerAssignment(tailend->ControllerAssignment8);

            TapDelay = new ChameleonTapDelay(tailend->TapDelay);

            CheckSum = tailend->CheckSum;
        }
    }
}

