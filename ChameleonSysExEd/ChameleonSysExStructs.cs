using ChameleonSysExEd;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Handy link to sysex spec for Roland https://www.2writers.com/eddie/TutSysEx.htm
namespace ChamSysExFileStructs
{
    public class Constants
    {
        public const int TITLE_LEN_BYTE = 26;
        public const int CHORUS_LG_BIG_GAP_LEN = 20;
        public const int FLANGER_LG_BIG_GAP_LEN = 40;
        public const int TREMOLO_LG_BIG_GAP_LEN = 40;
        public const int PITCHSHIFT_LG_BIG_GAP_LEN = 40;
        public const int WAH_LG_BIG_GAP_LEN = 40;
        public const int PHASER_LG_BIG_GAP_LEN = 40;

        //public const int TITLE_LEN_CHAR = 13;
        //public readonly List<string> ControllerAssignmentAdjustParams = new List<string>
        //{
        //                "OUTPUT",               //UL LL -> CB STEREO/MONO
        //                "GLOBAL SPKR SIM",      //UL LL -> CB LOCK/UNLOCK/LOCK LEFT/LOCKBOTH
        //                "HUSH OFFSET",          //UL -> 30 LL -> -10
        //                "MUTE",                 //UL ->  LL ->
        //                "VOLUME",               //
        //                "LEFT OUT LVL",
        //                "RIGHT OUT LVL",
        //                "MIX DIR",
        //                "DIRECT PAN",
        //                "DELAY LVL",
        //                "REVERB LVL",
        //                "GAIN",
        //                "VARIAC ADJUST",
        //                "POST BASS LVL",
        //                "POST MID LVL",
        //                "POST TREBLE LVL",
        //                "POST PRESENCE LVL",
        //                "HUSH I/O",
        //                "EXP THRESH",
        //                "PRE LF LVL",
        //                "PRE LF FREQ",
        //                "PRE MID LVL",
        //                "PRE MID FREQ",
        //                "PRE MID BW",
        //                "POST BASS FREQ",
        //                "POST BASS BW",
        //                "POST MID FREQ",
        //                "POST MID BW",
        //                "POST TREBLE FREQ",
        //                "POST TREBLE BW",
        //                "POST PRESENCE FREQ",
        //                "POST PRESENCE BW",
        //                "SPKR SIM",
        //                "SPKR TYPE",
        //                "MIC POSITION",
        //                "REACTANCE",
        //                "CHORUS I/O",
        //                "LEVEL 1",
        //                "PAN 1",
        //                "DEPTH 1",
        //                "RATE 1",
        //                "DELAY 1",
        //                "LEVEL 2",
        //                "PAN 2",
        //                "DEPTH 2",
        //                "RATE 2",
        //                "DELAY 2",
        //                "DELAY",
        //                "MUTE TYPE",
        //                "SOURCE MIX",
        //                "SOURCE 2",
        //                "DLY HF DAMP",
        //                "OUT LVL 1",
        //                "PAN 1",
        //                "DLY TIME 1",
        //                "REGEN 1",
        //                "OUT LVL 2",
        //                "PAN 2",
        //                "DLY TIME 2",
        //                "REGEN 2",
        //                "REV INPUT",
        //                "MIX DIR/DLY",
        //                "REV DECAY",
        //                "REV HF DAMP",
        //                "BYPASS"

        //};
        public readonly List<string> ControllerAssignmentOffOrNumberParams = new List<string>
        {
                        "OUTPUT",               //UL LL -> CB STEREO/MONO                       
                        "GLOBAL SPKR SIM",      //UL LL -> CB LOCK/UNLOCK/LOCK LEFT/LOCKBOTH
                        "HUSH OFFSET",          //UL -> 30 LL -> -10
                        "VOLUME",               //UL -> 127 LL -> 0
                        "LEFT OUT LVL",         //UL -> 6 LL -> -57
                        "RIGHT OUT LVL",        //UL -> 6 LL -> -57 
                        "MIX DIR",              //UL -> 0-100 LL -> 0-100
                        "DIRECT PAN",           //UL -> 0-100 LL -> 0-100
                        "DELAY LVL",            //UL -> 0 LL -> -63
                        "REVERB LVL",           //UL -> 0 LL -> -63 
                        "GAIN",                 //UL -> 78 LL -> 12
                        "VARIAC ADJUST",        //UL -> 0 LL -> -6
                        "POST BASS LVL",        //UL -> 15 LL -> -15
                        "POST MID LVL",         //UL -> 15 LL -> -15
                        "POST TREBLE LVL",      //UL -> 15 LL -> -15
                        "POST PRESENCE LVL",    //UL -> 15 LL -> -15 
                        "HUSH I/O",             //UL LL CB  OUT/IN
                        "EXP THRESH",           //UL -27 ->  LL ->  -90
                        "PRE LF LVL",           //UL -> 6 LL -> -15
                        "PRE LF FREQ",          //CB as per edit
                        "PRE MID LVL",          //UL ->  LL -> 
                        "PRE MID FREQ",         //UL ->  LL -> 
                        "PRE MID BW",           //UL ->  LL -> 
                        "POST BASS FREQ",       //UL ->  LL -> 
                        "POST BASS BW",         //UL ->  LL -> 
                        "POST MID FREQ",        //UL ->  LL -> 
                        "POST MID BW",          //UL ->  LL -> 
                        "POST TREBLE FREQ",     //UL ->  LL -> 
                        "POST TREBLE BW",       //UL ->  LL -> 
                        "POST PRESENCE FREQ",   //UL ->  LL -> 
                        "POST PRESENCE BW",     //UL ->  LL -> 
                        "SPKR SIM",             //UL ->  LL -> 
                        "SPKR TYPE",            //UL ->  LL -> 
                        "MIC POSITION",         //UL ->  LL -> 
                        "REACTANCE",            //UL ->  LL -> 
                        "CHORUS I/O",           //UL ->  LL -> 
                        "LEVEL 1",              //UL ->  LL -> 
                        "PAN 1",                //UL ->  LL -> 
                        "DEPTH 1",              //UL ->  LL -> 
                        "RATE 1",               //UL ->  LL -> 
                        "DELAY 1",              //UL ->  LL -> 
                        "LEVEL 2",              //UL ->  LL -> 
                        "PAN 2",                //UL ->  LL -> 
                        "DEPTH 2",              //UL ->  LL -> 
                        "RATE 2",               //UL ->  LL -> 
                        "DELAY 2",              //UL ->  LL -> 
                        "DELAY",                //UL ->  LL -> 
                        "MUTE TYPE",            //UL ->  LL -> 
                        "SOURCE MIX",           //UL ->  LL -> 
                        "SOURCE 2",             //UL ->  LL -> 
                        "DLY HF DAMP",          //UL ->  LL -> 
                        "OUT LVL 1",            //UL ->  LL -> 
                        "PAN 1",                //UL ->  LL -> 
                        "DLY TIME 1",           //UL ->  LL -> 
                        "REGEN 1",              //UL ->  LL -> 
                        "OUT LVL 2",            //UL ->  LL -> 
                        "PAN 2",                //UL ->  LL -> 
                        "DLY TIME 2",           //UL ->  LL -> 
                        "REGEN 2",              //UL ->  LL -> 
                        "REV INPUT",            //UL ->  LL -> 
                        "MIX DIR/DLY",          //UL ->  LL -> 
                        "REV DECAY",            //UL ->  LL -> 
                        "REV HF DAMP",          //UL ->  LL -> 
                        "BYPASS"                //UL ->  LL -> 
        };
    }



    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonControl //@4-7 
    {
        public byte Code1;         //0x06        
        public byte Code2;         //0x28
        public byte ConfigMode;    //Index into lookup         
        public byte Z1;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonMixer  //14 public bytes
    {
        public byte MasterVolume;   //0 -> 127
        public byte Z1;
        public byte LeftLevel;      //-57 -> 6
        public byte Z2;
        public byte RightLevel;     //-57 -> 6
        public byte Z3;
        public byte MixDir;         //0 -> 100
        public byte Z4;
        public byte Pan;            //0 -> 100
        public byte Z5;
        public byte DelayLevel; //x00 is -63, x3f is 0, range 0 -> -63 
        public byte Z6;
        public byte ReverbLevel; //x00 is -63, x3f is 0, range 0 -> -63 
        public byte Z7;
    };
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonGainLow //@22-33    //12 public bytes
    {
        public byte GainAmount;     //  range 0 - 48 
        public byte Z1;
        public byte GainType;       //0 -> solid state, pentode, triode A, 3 -> triode B
        public byte Z2;
        public byte BassLevel;      //0x00 = -15 -> 0x1e 15
        public byte Z3;
        public byte MidLevel;       //0x00 = -15 -> 0x1e 15
        public byte Z4;
        public byte TrebleLevel;    //0x00 = -15 -> 0x1e 15
        public byte Z5;
        public byte Presence;       //0x00 = -15 -> 0x1e 15
        public byte Z6;
    };
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonGainHigh
    {
        public byte GainAmount; //12-78
        public byte Z1;
        public byte Variac; //0 --> -6
        public byte Z2;
        public byte BassLevel; // -15 -> 15
        public byte Z3;
        public byte MidLevel;
        public byte Z4;
        public byte TrebleLevel;
        public byte Z5;
        public byte Presence;
        public byte Z6;
    };
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompressor
    {
        public byte InOut;
        public byte Z1;
        public byte Threshold; //0 to -24 range
        public byte Z2;
        public byte Attack; //lookup  0-7 => 1, 2, 3, 8, 16, 25, 50, 75
        public byte Z3;
        public byte Release; //lookup  0- => 0.055, 0.15 0.25 ... 2.05
        public byte Z4;
    };
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonWah
    {
        public byte WahInOut;
        public byte Z1;
        public byte Freq;
        public byte Z2;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonHush
    {
        public byte InOut;
        public byte Z1;
        public byte Threshold;// range -27 to -90, x3f to 0x00
        public byte Z2;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonPreEQ
    {
        public byte LowFreqLevel; //-15 -> 6
        public byte Z1;
        public byte LowFreq;
        public byte Z2;
        public byte MidFreqLevel;  //15 -> 12
        public byte Z3;
        public byte MidFreq;
        public byte Z4;
        public byte MidBand;
        public byte Z5;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonPostEQ
    {
        public byte BassFreq;
        public byte Z1;
        public byte BassBand;
        public byte Z2;
        public byte MidFreq;
        public byte Z3;
        public byte MidBand;
        public byte Z4;
        public byte TrebleFreq;
        public byte Z5;
        public byte TrebleBand;
        public byte Z6;
        public byte PresFreq;
        public byte Z7;
        public byte PresBand;
        public byte Z8;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonSpeakerSim
    {
        public byte SpeakerSim;
        public byte Z1;
        public byte SpeakerType;
        public byte Z2;
        public byte MicPlace;
        public byte Z3;
        public byte Reactance;
        public byte Z4;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonTremolo
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
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonChorus
    {
        public byte ChorusInOut;
        public byte Z1;
        public byte Chorus1Level;
        public byte Z2;
        public byte Chorus1Pan;
        public byte Z3;
        public byte Chorus1Depth;
        public byte Z4;
        public byte Chorus1Rate;
        public byte Chorus1RateHighByte;
        public byte Chorus1Delay;
        public byte Z6;
        public byte Chorus2Level;
        public byte Z7;
        public byte Chorus2Pan;
        public byte Z8;
        public byte Chorus2Depth;
        public byte Z9;
        public byte Chorus2Rate;
        public byte Chorus2RateHighByte;
        public byte Chorus2Delay;
        public byte Z11;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonPhaser
    {
        public byte PhaserInOut;        //Depth (0-100)
        public byte Z1;
        public byte Depth;
        public byte Z2;
        public byte Rate;       //Rate (0-253)
        public byte Z3;
        public byte Resonance;          //Resonance (0-100)
        public byte Z4;
        public byte Stage;              //Stages (0-1) 4, 6
        public byte Z5;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonDelay
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
        public byte D1OutLevel;
        public byte Z6;
        public byte D1Pan;
        public byte Z7;
        public byte D1Time;
        public byte D1TimeHighByte;
        public byte D1Regen;
        public byte Z9;
        public byte D2OutLevel;
        public byte Z10;
        public byte D2Pan;
        public byte Z11;
        public byte D2Time;
        public byte D2TimeHighByte;
        public byte D2Regen;
        public byte Z13;

    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonReverb
    {
        public byte ReverbState;
        public byte Z14;
        public byte ReverbMix;
        public byte Z15;
        public byte ReverbDecay;
        public byte Z16;
        public byte ReverbHighFreqDamp;
        public byte Z17;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonControllerAssignment
    {
        public byte Number;
        public byte Z1;
        public byte Param;
        public byte Z2;
        public byte UpperLimit;
        public byte Z3;
        public byte LowerLimit;
        public byte Z4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonTapDelay
    {
        public byte TapDelayD1Multiplyer;
        public byte Z1;
        public byte TapDelayD2Multiplyer;
        public byte Z2;
    }
    //[StructLayout(LayoutKind.Sequential)]
    //public unsafe struct TChameleonFlangerLG
    //{
    //    public byte FlangeInOut;          //Flange (0-1) Off, On
    //    public byte Z0;
    //    public byte Regeneration;          //-63 -> 0
    //    public byte Z1;
    //    public byte Level1;               //Level 1 (0-58)
    //    public byte Z2;
    //    public byte Pan1;                 //Pan 1 (0-100)
    //    public byte Z3;
    //    public byte Depth1;               //Depth 1 (0-100)
    //    public byte Z4;
    //    public byte Rate1Low;             //Rate 1 (0-253)
    //    //public byte Rate1High;
    //    public byte Level2;               //Level 2 (0-58)
    //    public byte Z5;
    //    public byte Pan2;                 //Pan 2 (0-100)this
    //    public byte Z6;
    //    public byte Depth2;               //Depth 2 (0-100)
    //    public byte Z7;
    //    public byte Rate2Low;             //Rate 2 (0-253)
    //                                      //public byte Rate2High;
    //    public byte Z8;//19
    //    public byte Z9;//20
    //}
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonFlanger
    {
        public byte FlangeInOut;          //Flange (0-1) Off, On
        public byte Z0;
        public byte Level1;               //Level 1 (0-58)
        public byte Z1;
        public byte Pan1;                 //Pan 1 (0-100)
        public byte Z2;
        public byte Depth1;               //Depth 1 (0-100)
        public byte Z3;
        public byte Rate1Low;             //Rate 1 (0-253)
        public byte Rate1High;
        public byte Level2;               //Level 2 (0-58)
        public byte Z5;
        public byte Pan2;                 //Pan 2 (0-100)this
        public byte Z6;
        public byte Depth2;               //Depth 2 (0-100)
        public byte Z7;
        public byte Rate2Low;             //Rate 2 (0-253)
        public byte Rate2High;
        public byte Regeneration;          //-63 -> 0
        public byte Z8;//19
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonPitchShift
    {
        public byte PitchShiftInOut;
        public byte Z0;
        public byte Level;                  //Pitch 1
        public byte Z1;
        public byte Pan;
        public byte Z2;
        public byte Pitch;                  //Fine 1 (0-40) -20 to 20 step 1
        public byte PitchHigh;
        public byte FineTune;               //Level 1 (0-58)
        public byte Z4;
        public byte Speed;
        public byte Z5;
    }
    [StructLayout(LayoutKind.Sequential)]

    public unsafe struct TChameleonCompositeHeaderHighGain
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh Gain;            //@22-33              
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public fixed byte TailEnd[180];//pad to 252
    };
    [StructLayout(LayoutKind.Sequential)]

    public unsafe struct TChameleonCompositeHeaderLowGain
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow Gain;             //@22-33              
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        public fixed byte TailEnd[172];//pad to 252
    };
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
    struct TChameleonCompositeHeaderUnion
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHeaderLowGain LowGain;

        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHeaderHighGain HighGain;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeTailend
    {
        public fixed byte Header[156];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
        //public byte Z0;                //252 00
    };                                               //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainChorus
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        public TChameleonChorus Chorus;            //@80-97 tested

        //TChameleonFlange Flanger;           //@72-89  //80-97 low gain
        //TChameleonPhaser Phaser;            //@72-81
        //TChameleonPitchShift PitchShift;    //@72-83
        //TChameleonTremolo Tremolo;          //@72-81 //80-88 low gain

        public TChameleonDelay Delay;              //@94-127  //lg flange 100-125
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[Constants.CHORUS_LG_BIG_GAP_LEN];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
                                        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainFlanger
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33             
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        //public TChameleonChorus Chorus;          //@80-97 tested

        public TChameleonFlanger Flanger;           //80-97 low gain
        //TChameleonPhaser Phaser;                  //@72-81
        //TChameleonPitchShift PitchShift;          //@72-83
        //TChameleonTremolo Tremolo;                //80-88 low gain

        public TChameleonDelay Delay;              //@94-127  //lg flange 100-125
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainPhaser
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        public TChameleonPhaser Phaser;            //@80-89
   
        public TChameleonDelay Delay;              //@90-115
        public TChameleonReverb Reverb;            //@116-123

        public fixed byte BigGapInMiddle[20];      //@124-143 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@144-169
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainPitchShift
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        //public TChameleonChorus Chorus;            //@80-97 tested

        //TChameleonFlange Flanger;           //@72-89  //80-97 low gain
        //TChameleonPhaser Phaser;            //@72-81
        public TChameleonPitchShift PitchShift;    //@72-83
        //TChameleonTremolo Tremolo;          //@72-81 //80-88 low gain

        public TChameleonDelay Delay;              //@94-127  //lg flange 100-125
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (252 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainTremolo
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79
        //public TChameleonChorus Chorus;            //@80-97 tested

        //TChameleonFlange Flanger;           //@72-89  //80-97 low gain
        //TChameleonPhaser Phaser;            //@72-81
        //TChameleonPitchShift PitchShift;    //@72-83
        public TChameleonTremolo Tremolo;          //@72-81 //80-88 low gain

        public TChameleonDelay Delay;              //@94-127  
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeLowGainWah
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainLow GainLow;          //@22-33                 
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonCompressor Compressor;    //@72-79

        public TChameleonWah Wah;                   //80-83

        public TChameleonDelay Delay;              //84-109 checked
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[Constants.WAH_LG_BIG_GAP_LEN];     //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];                  //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;        //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainDONOTUSE
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71

        public TChameleonChorus Chorus;            //@72-93  //80-100 on low gain
                                                   //TChameleonHush Compressor;          //@82-90 low gain only 72-79
                                                   //TChameleonFlange Flanger;           //@72-89
                                                   //TChameleonPhaser Phaser;            //@72-81
                                                   //TChameleonPitchShift PitchShift;    //@72-83
                                                   //TChameleonTremolo Tremolo;          //@72-81 //80-88 low gain

        public TChameleonDelay Delay;              //@94-119
        public TChameleonReverb Reverb;            //@120-127

        public fixed byte BigGapInMiddle[28];      //@128-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
        //public byte Z0;                //252 00
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainChorus
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonChorus Chorus;            //@72-93 
        public TChameleonDelay Delay;              //@94-127 
        public TChameleonReverb Reverb;            //@128-135
        public fixed byte BigGapInMiddle[Constants.CHORUS_LG_BIG_GAP_LEN];      //@136-155 //BIG GAP HERE 
        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;                //@251 0xF7
                                        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainFlanger
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;          //@22-33             
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonFlanger Flanger;           //80-97 low gain
        public TChameleonDelay Delay;              //@94-127  //lg flange 100-125
        public TChameleonReverb Reverb;            //@128-135
        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 
        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249
        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainPhaser
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonPhaser Phaser;            //@72-81
        public TChameleonDelay Delay;              //@94-127  //lg flange 100-125
        public TChameleonReverb Reverb;            //@128-135
        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainPitchShift
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;        //@22-33           
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonPitchShift PitchShift;    //@72-83
        public TChameleonDelay Delay;              //@84
        public TChameleonReverb Reverb;            //@128-135
        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 
        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (252 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainTremolo
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;          //@22-33              // or TChameleonGainHigh GainHigh;
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonTremolo Tremolo;          //@72-81 //80-88 low gain

        public TChameleonDelay Delay;              //@94-127  
        public TChameleonReverb Reverb;            //@128-135

        public fixed byte BigGapInMiddle[20];      //@136-155 //BIG GAP HERE 

        public fixed byte Title[Constants.TITLE_LEN_BYTE];               //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;  //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249

        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    };
    //The combined message structure (225 bytes)
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TChameleonCompositeHighGainWah
    {
        public byte Status;                        //0xF0(@0)
        public byte ManufCode;                     //@1
        public byte DeviceID;                      //@2
        public byte ModelID;                       //@3     
        public TChameleonControl Control;          //@4-7     
        public TChameleonMixer Mixer;              //@8-21
        public TChameleonGainHigh GainHigh;         //@22-33                 
        public TChameleonHush Hush;                //@34-37
        public TChameleonPreEQ PreEQ;              //@38-47
        public TChameleonPostEQ PostEQ;            //@48-63
        public TChameleonSpeakerSim SpeakerSim;    //@64-71
        public TChameleonWah Wah;                   //72-75
        public TChameleonDelay Delay;              //76-101 checked
        public TChameleonReverb Reverb;            //@128-135
        public fixed byte BigGapInMiddle[Constants.WAH_LG_BIG_GAP_LEN];     //@136-155 //BIG GAP HERE 
        public fixed byte Title[Constants.TITLE_LEN_BYTE];                  //@156-181
        public TChameleonControllerAssignment ControllerAssignment1;        //64 Bytes @182-245
        public TChameleonControllerAssignment ControllerAssignment2;
        public TChameleonControllerAssignment ControllerAssignment3;
        public TChameleonControllerAssignment ControllerAssignment4;
        public TChameleonControllerAssignment ControllerAssignment5;
        public TChameleonControllerAssignment ControllerAssignment6;
        public TChameleonControllerAssignment ControllerAssignment7;
        public TChameleonControllerAssignment ControllerAssignment8;
        public TChameleonTapDelay TapDelay;        //@246 - 249
        public byte CheckSum;             //@250 checksum (bytes 7-456 XOR)
        public byte Eox;		        //@251 0xF7
        //public byte Z0;                //252 00
    }
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
    public unsafe struct TChameleonCompositeAllStructsUnion
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHeaderLowGain LowGainHeader;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHeaderHighGain HighGainHeader;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeTailend TailEnd;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainChorus LowGainChorus;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainFlanger LowGainFlanger;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainPhaser LowGainPhaser;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainPitchShift LowGainPitchShift;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainTremolo LowGainTremolo;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeLowGainWah LowGainWah;

        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainChorus HighGainChorus;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainFlanger HighGainFlanger;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainPhaser HighGainPhaser;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainPitchShift HighGainPitchShift;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainTremolo HighGainTremolo;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public TChameleonCompositeHighGainWah HighGainWah;
    }
}
