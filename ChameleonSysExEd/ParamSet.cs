using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonSysExEd
{
    abstract class ParamSetItemBase
    {
        public string paramName;
    }
    class ParamSetItemNumeric : ParamSetItemBase
    {
        //int paramID;

        int limitMin;
        int limitMax;

        public ParamSetItemNumeric(string paramName,
            int limitMin,
            int limitMax)
        {

            this.paramName = paramName;
            this.limitMin = limitMin;
            this.limitMax = limitMax;

        }
    }
    class ParamSetItemChoices : ParamSetItemBase
    {
        string[] lowerLimitValues;
        string[] upperLimitValues;

        public ParamSetItemChoices(string paramName, string[] lowerLimitValues, string[] upperLimitValues)
        {
            this.paramName = paramName;
            this.lowerLimitValues = lowerLimitValues;
            if (upperLimitValues == null)
                this.upperLimitValues = lowerLimitValues;
            else
                this.upperLimitValues = upperLimitValues;
        }
    }
    class ParamSetHelpers
    {
        public static void LoadParamSetItems(Dictionary<string, ParamSetItemBase> kvpParams)
        {
         
            kvpParams["OUTPUT"] = new ParamSetItemChoices("OUTPUT", new string[] { "STEREO", "MONO" }, null);
            kvpParams["GLOBAL SPKR SIM"] = new ParamSetItemChoices("GLOBAL SPKR SIM", new string[] { "LOCK", "UNLOCK", "LOCK LEFT", "LOCK BOTH" }, null);
            kvpParams["HUSH OFFSET"] = new ParamSetItemNumeric("HUSH OFFSET", -10, 30);
            kvpParams["VOLUME"] = new ParamSetItemNumeric("VOLUME", 0, 127);
            kvpParams["LEFT OUT LVL"] = new ParamSetItemNumeric("LEFT OUT LVL", -57, 6);
            kvpParams["RIGHT OUT LVL"] = new ParamSetItemNumeric("RIGHT OUT LVL", -57, 6);
            kvpParams["MIX DIR"] = new ParamSetItemNumeric("MIX DIR", 0, 100);
            kvpParams["DIRECT PAN"] = new ParamSetItemNumeric("DIRECT PAN", 0, 100);
            kvpParams["DELAY LVL"] = new ParamSetItemNumeric("DELAY LVL", -63, 0);
            kvpParams["REVERB LVL"] = new ParamSetItemNumeric("REVERB LVL", -63, 0);
            kvpParams["GAIN"] = new ParamSetItemNumeric("GAIN", 12, 78);
            kvpParams["DIST TYPE"] = new ParamSetItemChoices("DIST TYPE", new string[] { "Solid State", "Pentode", "Triode A", "Triode B" }, null);
            kvpParams["VARIAC ADJUST"] = new ParamSetItemNumeric("VARIAC ADJUST", -6, 0);
            kvpParams["POST BASS LVL"] = new ParamSetItemNumeric("POST BASS LVL", -15, 15);
            kvpParams["POST MID LVL"] = new ParamSetItemNumeric("POST MID LVL", -15, 15);
            kvpParams["POST TREBLE LVL"] = new ParamSetItemNumeric("POST TREBLE LVL", -15, 15);
            kvpParams["POST PRESENCE LVL"] = new ParamSetItemNumeric("POST PRESENCE LVL", -15, 15);
            kvpParams["HUSH I/O"] = new ParamSetItemChoices("HUSH I/ O", new string[] { "OUT", "IN" }, null);
            kvpParams["EXP THRESH"] = new ParamSetItemNumeric("EXP THRESH", -90, -27);
            kvpParams["PRE LF LVL"] = new ParamSetItemNumeric("PRE LF LVL", -15, 6);
            kvpParams["PRE LF FREQ"] = new ParamSetItemChoices("PRE LF FREQ", PreEQLowFilterFreq(), null);
            kvpParams["PRE MID LVL"] = new ParamSetItemNumeric("PRE MID LVL", -15, 6);
            kvpParams["PRE MID FREQ"] = new ParamSetItemChoices("PRE MID FREQ", PreEQMidFilterFreq(), null);
            kvpParams["PRE MID BW"] = new ParamSetItemChoices("PRE MID BW", PreEQMidBW(), null);
            kvpParams["POST BASS FREQ"] = new ParamSetItemChoices("POST BASS FREQ", PreEQLowFilterFreq(), null);
            kvpParams["POST BASS BW"] = new ParamSetItemChoices("POST BASS BW", PreEQMidBW(), null);
            kvpParams["POST MID FREQ"] = new ParamSetItemChoices("POST MID FREQ", PreEQMidFilterFreq(), null);
            kvpParams["POST MID BW"] = new ParamSetItemChoices("POST MID BW", PreEQMidBW(), null);
            kvpParams["POST TREBLE FREQ"] = new ParamSetItemChoices("POST TREBLE FREQ", PostEQTrebleFreq(), null);
            kvpParams["POST TREBLE BW"] = new ParamSetItemChoices("POST TREBLE BW", PreEQMidBW(), null);
            kvpParams["POST PRESENCE FREQ"] = new ParamSetItemChoices("POST PRESENCE FREQ", PostEQPresenceFreq(), null);
            kvpParams["POST PRESENCE BW"] = new ParamSetItemChoices("POST PRESENCE BW", PreEQMidBW(), null);
            kvpParams["SPKR SIM"] = new ParamSetItemChoices("SPKR SIM", new string[] { "OFF", "LEFT", "BOTH" }, null);
            kvpParams["SPKR TYPE"] = new ParamSetItemChoices("SPKR TYPE", new string[] { "15 \"", "12 \"", "10 \"", "8 \"", "FULL" }, null);
            kvpParams["MIC POSITION"] = new ParamSetItemNumeric("MIC POSITION", -15, 15);
            kvpParams["REACTANCE"] = new ParamSetItemNumeric("REACTANCE", -15, 15);
            kvpParams["COMPRESSOR I/O"] = new ParamSetItemChoices("COMPRESSOR I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["HUSH I/O"] = new ParamSetItemChoices("HUSH I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["CHORUS I/O"] = new ParamSetItemChoices("CHORUS I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["LEVEL 1"] = new ParamSetItemNumeric("LEVEL 1", -63, 0);
            kvpParams["DEPTH 1"] = new ParamSetItemNumeric("DEPTH 1", 0, 100);
            kvpParams["RATE 1"] =  new ParamSetItemNumeric("RATE 1", 0,254);
            kvpParams["DELAY 1"] = new ParamSetItemNumeric("DELAY 1", 2, 40);
            kvpParams["LEVEL 2"] = new ParamSetItemNumeric("LEVEL 2", -63, 0);
            kvpParams["DEPTH 2"] = new ParamSetItemNumeric("DEPTH 2", 0, 100);
            kvpParams["RATE 2"] =  new ParamSetItemNumeric("RATE 2", 0, 254);
            kvpParams["DELAY 2"] = new ParamSetItemNumeric("DELAY 2", 2, 40);

            kvpParams["FLANGE I/O"] = new ParamSetItemChoices("FLANGE I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["REGEN"] = new ParamSetItemNumeric("REGEN", -63, 0);
            kvpParams["WAH-WAH I/O"] = new ParamSetItemChoices("WAH-WAH I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["WAH FREQ"] = new ParamSetItemChoices("WAH-WAH FREQ", WahFreq(), null);

            kvpParams["TREMOLO I/O"] = new ParamSetItemChoices("TREMOLO I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["LOCATION"] = new ParamSetItemChoices("LOCATION", new string[] { "PRE-REV", "POST-REV" }, null);
            kvpParams["SHAPE"] = new ParamSetItemNumeric("SHAPE", 2, 40);

            kvpParams["PITCH SHIFT I/O"] = new ParamSetItemChoices("PITCH SHIFT I/O", new string[] { "OUT", "IN" }, null);
          
            kvpParams["PITCH"] = new ParamSetItemNumeric("PITCH", -2400,1200);
            kvpParams["FINE"] = new ParamSetItemNumeric("FINE", 2, 40);
            kvpParams["SPEED"] = new ParamSetItemChoices("SPEED", new string[] { "SLOW", "MED", "FAST" }, null);

            kvpParams["LEVEL"] = new ParamSetItemNumeric("LEVEL",-63,0);
            kvpParams["PAN"] = new ParamSetItemNumeric("PAN",0,100 );


            kvpParams["COMP THRESH"] = new ParamSetItemNumeric("COMP THRESH", -24, 0);
            kvpParams["COMP ATTACK"] = new ParamSetItemChoices("COMP ATTACK", CompressorAttack(), null);
            kvpParams["COMP RELEASE"] = new ParamSetItemChoices("COMP RELEASE", CompressorRelease(), null);
            kvpParams["PHASER I/O"] = new ParamSetItemChoices("PHASER I/O", new string[] { "OUT", "IN" }, null);
            kvpParams["DEPTH"] = new ParamSetItemNumeric("DEPTH", 0, 100);
            kvpParams["RATE"] = new ParamSetItemNumeric("RATE", 0, 254);
            kvpParams["RESONANCE"] = new ParamSetItemNumeric("RESONANCE", 0, 100);
            kvpParams["STAGES"] = new ParamSetItemChoices("STAGES", new string[] { "4", "6" }, null);
            kvpParams["DELAY"] = new ParamSetItemChoices("DELAY", new string[] { "MUTED", "ACTIVE" }, null);
            kvpParams["MUTE TYPE"] = new ParamSetItemChoices("MUTE TYPE", new string[] { "PRE", "POST", "BOTH" }, null);
            kvpParams["SOURCE MIX"] = new ParamSetItemNumeric("SOURCE MIX", 0, 100);
            kvpParams["SOURCE 2"] = new ParamSetItemChoices("SOURCE 2", new string[] { "DIRECT", "VOICE" }, null);
            kvpParams["DLY HF DAMP"] = new ParamSetItemNumeric("DLY HF DAMP", 0, 99);
            kvpParams["OUT LVL 1"] = new ParamSetItemNumeric("OUT LVL 1", -63, 0);
            kvpParams["PAN 1"] = new ParamSetItemNumeric("PAN 1", 0, 100);
            kvpParams["DLY TIME 1"] = new ParamSetItemNumeric("DLY TIME 1", 0, 1000);
            kvpParams["REGEN 1"] = new ParamSetItemNumeric("REGEN 1", -63, 0);
            kvpParams["OUT LVL 2"] = new ParamSetItemNumeric("OUT LVL 2", -63, 0);
            kvpParams["PAN 2"] = new ParamSetItemNumeric("PAN 2", 0, 100);
            kvpParams["DLY TIME 2"] = new ParamSetItemNumeric("DLY TIME 2", 0, 1000);
            kvpParams["REGEN 2"] = new ParamSetItemNumeric("REGEN 2", -63, 0);
            kvpParams["REV INPUT"] = new ParamSetItemChoices("REV INPUT", new string[] { "MUTED", "ACTIVE" }, null);
            kvpParams["MIX DIR/DLY"] = new ParamSetItemNumeric("MIX DIR/ DLY", 0, 100);
            kvpParams["REV DECAY"] = new ParamSetItemNumeric("REV DECAY", 0, 99);
            kvpParams["REV HF DAMP"] = new ParamSetItemNumeric("REV HF DAMP", 0, 99);
            kvpParams["BYPASS"] = new ParamSetItemChoices("BYPASS", new string[] { "OFF", "ON" }, null);

        }
        static public string[] GetHGChorusParams()
        {
            return new string[] { "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "CHORUS I/O",
                "LEVEL 1",
                "PAN 1",
                "DEPTH 1",
                "RATE 1",
                "DELAY 1",
                "LEVEL 2",
                "PAN 2",
                "DEPTH 2",
                "RATE 2",
                "DELAY 2",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS"};
        }


        static public string[] GetHGFlangeParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "FLANGE I/O",
                "LEVEL 1",
                "PAN 1",
                "DEPTH 1",
                "RATE 1",
                "LEVEL 2",
                "PAN 2",
                "DEPTH 2",
                "RATE 2",
                "REGEN",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }
        static public string[] GetHGTremoloParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "TREMOLO I/O",
                "LOCATION",
                "DEPTH",
                "RATE",
                "SHAPE",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }

        static public string[] GetHGPitchShiftParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "PITCH SHIFT I/O",
                "LEVEL",
                "PAN",
                "PITCH",
                "FINE",
                "SPEED",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }
        static public string[] GetHGWahParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "WAH-WAH I/O",
                "WAH FREQ",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }

        static public string[] GetHGPhaserParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "VARIAC ADJUST",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "PHASER I/O",
                "DEPTH",
                "RATE",
                "RESONANCE",
                "STAGES",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }


        static public string[] GetLGChorusParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "CHORUS I/O",
                "LEVEL 1",
                "PAN 1",
                "DEPTH 1",
                "RATE 1",
                "DELAY 1",
                "LEVEL 2",
                "PAN 2",
                "DEPTH 2",
                "RATE 2",
                "DELAY 2",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY" };
        }

        static public string[] GetLGFlangeParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "FLANGE I/O",
                "LEVEL 1",
                "PAN 1",
                "DEPTH 1",
                "RATE 1",
                "LEVEL 2",
                "PAN 2",
                "DEPTH 2",
                "RATE 2",
                "REGEN",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP" };
        }


        static public string[] GetLGTremoloParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "TREMOLO I/O",
                "LOCATION",
                "DEPTH",
                "RATE",
                "SHAPE",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }

        static public string[] GetLGPitchShiftParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "PITCH SHIFT I/O",
                "LEVEL",
                "PAN",
                "PITCH",
                "FINE",
                "SPEED",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }

        static public string[] GetLGWahParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "WAH-WAH I/O",
                "WAH FREQ",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };
        }

        static public string[] GetLGPhaserParams()
        {
            return new string[] {
                "OUTPUT",
                "GLOBAL SPKR SIM",
                "HUSH OFFSET",
                //"MUTE",
                "VOLUME",
                "LEFT OUT LVL",
                "RIGHT OUT LVL",
                "MIX DIR",
                "DIRECT PAN",
                "DELAY LVL",
                "REVERB LVL",
                "GAIN",
                "DIST TYPE",
                "POST BASS LVL",
                "POST MID LVL",
                "POST TREBLE LVL",
                "POST PRESENCE LVL",
                "HUSH I/O",
                "EXP THRESH",
                "PRE LF LVL",
                "PRE LF FREQ",
                "PRE MID LVL",
                "PRE MID FREQ",
                "PRE MID BW",
                "POST BASS FREQ",
                "POST BASS BW",
                "POST MID FREQ",
                "POST MID BW",
                "POST TREBLE FREQ",
                "POST TREBLE BW",
                "POST PRESENCE FREQ",
                "POST PRESENCE BW",
                "SPKR SIM",
                "SPKR TYPE",
                "MIC POSITION",
                "REACTANCE",
                "COMPRESSOR I/O",
                "COMP THRESH",
                "COMP ATTACK",
                "COMP RELEASE",
                "PHASER I/O",
                "DEPTH",
                "RATE",
                "RESONANCE",
                "STAGES",
                "DELAY",
                "MUTE TYPE",
                "SOURCE MIX",
                "SOURCE 2",
                "DLY HF DAMP",
                "OUT LVL 1",
                "PAN 1",
                "DLY TIME 1",
                "REGEN 1",
                "OUT LVL 2",
                "PAN 2",
                "DLY TIME 2",
                "REGEN 2",
                "REV INPUT",
                "MIX DIR/DLY",
                "REV DECAY",
                "REV HF DAMP",
                "BYPASS" };

        }
        static public  string[] PreEQLowFilterFreq()
        {
            return new string[] {
             "63 Hz",
             "65 Hz",
             "68 Hz",
             "71 Hz",
             "74 Hz",
             "78 Hz",
             "81 Hz",
             "85 Hz",
             "88 Hz",
             "92 Hz",
             "96 Hz",
            "101 Hz",
            "105 Hz",
            "110 Hz",
            "115 Hz",
            "120 Hz",
            "125 Hz",
            "131 Hz",
            "136 Hz",
            "142 Hz",
            "149 Hz",
            "155 Hz",
            "162 Hz",
            "169 Hz",
            "177 Hz",
            "185 Hz",
            "193 Hz",
            "201 Hz",
            "210 Hz",
            "220 Hz",
            "229 Hz",
            "239 Hz",
            "250 Hz",
            "261 Hz",
            "273 Hz",
            "285 Hz",
            "297 Hz",
            "310 Hz",
            "324 Hz",
            "339 Hz",
            "354 Hz",
            "369 Hz",
            "386 Hz",
            "403 Hz",
            "420 Hz",
            "439 Hz",
            "459 Hz",
            "479 Hz",
            "500 Hz"};
        }
        static public string[] PreEQMidFilterFreq()
        {
            return new string[] {
                "500 Hz",
                "522 Hz",
                "545 Hz",
                "569 Hz",
                "595 Hz",
                "621 Hz",
                "648 Hz",
                "677 Hz",
                "707 Hz",
                "738 Hz",
                "771 Hz",
                "805 Hz",
                "841 Hz",
                "878 Hz",
                "917 Hz",
                "958 Hz",
                "1000 Hz",
                "1044 Hz",
                "1091 Hz",
                "1139 Hz",
                "1189 Hz",
                "1242 Hz",
                "1297 Hz",
                "1354 Hz",
                "1414 Hz",
                "1477 Hz",
                "1542 Hz",
                "1610 Hz",
                "1682 Hz",
                "1756 Hz",
                "1834 Hz",
                "1915 Hz",
                "2000 Hz",
                "2089 Hz",
                "2181 Hz",
                "2278 Hz",
                "2378 Hz",
                "2484 Hz",
                "2594 Hz",
                "2709 Hz",
                "2828 Hz",
                "2954 Hz",
                "3084 Hz",
                "3221 Hz",
                "3364 Hz",
                "3513 Hz",
                "3668 Hz",
                "3830 Hz",
                "4000 Hz"
            };
        }
        static public string[] PreEQMidBW()
        {
            return new string[] {
                "0.2 OCT",
                "0.3 OCT",
                "0.4 OCT",
                "0.5 OCT",
                "0.6 OCT",
                "0.7 OCT",
                "0.8 OCT",
                "0.9 OCT",
                "1.0 OCT",
                "1.1 OCT",
                "1.2 OCT",
                "1.3 OCT",
                "1.4 OCT",
                "1.5 OCT",
                "1.6 OCT",
                "1.7 OCT",
                "1.8 OCT",
                "1.9 OCT",
                "2.0 OCT"
            };

        }
        static public string[] PostEQTrebleFreq()
        {
            return new string[] {

                "1000 Hz",
                "1044 Hz",
                "1091 Hz",
                "1139 Hz",
                "1189 Hz",
                "1242 Hz",
                "1297 Hz",
                "1354 Hz",
                "1414 Hz",
                "1477 Hz",
                "1542 Hz",
                "1610 Hz",
                "1682 Hz",
                "1756 Hz",
                "1834 Hz",
                "1915 Hz",
                "2000 Hz",
                "2089 Hz",
                "2181 Hz",
                "2278 Hz",
                "2378 Hz",
                "2484 Hz",
                "2594 Hz",
                "2709 Hz",
                "2828 Hz",
                "2954 Hz",
                "3084 Hz",
                "3221 Hz",
                "3364 Hz",
                "3513 Hz",
                "3668 Hz",
                "3830 Hz",
                "4000 Hz",
                "4177 Hz",
                "4362 Hz",
                "4555 Hz",
                "4757 Hz",
                "4967 Hz",
                "5187 Hz",
                "5417 Hz",
                "5657 Hz",
                "5907 Hz",
                "6169 Hz",
                "6442 Hz",
                "6727 Hz",
                "7025 Hz",
                "7336 Hz",
                "7661 Hz",
                "8000 Hz"
            };
        }
        static public string[] PostEQPresenceFreq()
        {
            return new string[] {
                "2000 Hz",
                "2089 Hz",
                "2181 Hz",
                "2278 Hz",
                "2378 Hz",
                "2484 Hz",
                "2594 Hz",
                "2709 Hz",
                "2828 Hz",
                "2954 Hz",
                "3084 Hz",
                "3221 Hz",
                "3364 Hz",
                "3513 Hz",
                "3668 Hz",
                "3830 Hz",
                "4000 Hz",
                "4177 Hz",
                "4362 Hz",
                "4555 Hz",
                "4757 Hz",
                "4967 Hz",
                "5187 Hz",
                "5417 Hz",
                "5657 Hz",
                "5907 Hz",
                "6169 Hz",
                "6442 Hz",
                "6727 Hz",
                "7025 Hz",
                "7336 Hz",
                "7661 Hz",
                "8000 Hz"
            };
        }
        static public string[] CompressorAttack()
        {
            return new string[] {
                "1ms",
                "2ms",
                "3ms",
                "8ms",
                "16ms",
                "25ms",
                "75ms"
            };
        }
        static public string[] CompressorRelease()
        {
            return new string[] {
                "0.055",
                "0.15",
                "0.25",
                "0.35",
                "0.45",
                "0.55",
                "0.65",
                "0.75",
                "0.85",
                "0.95",
                "1.05",
                "1.15",
                "1.25",
                "1.35",
                "1.45",
                "1.55",
                "1.65",
                "1.75",
                "1.85",
                "1.95",
                "2.05" };
        }
        static public string[] WahFreq()
        {
            return new string[] {
                "310 Hz",
             "317 Hz",
             "324 Hz",
             "331 Hz",
             "339 Hz",
             "346 Hz",
             "354 Hz",
             "361 Hz",
             "369 Hz",
             "377 Hz",
             "386 Hz",
             "394 Hz",
             "403 Hz",
             "411 Hz",
             "420 Hz",
             "430 Hz",
             "439 Hz",
             "449 Hz",
             "459 Hz",
             "469 Hz",
             "479 Hz",
             "489 Hz",
             "500 Hz",
             "511 Hz",
             "522 Hz",
             "534 Hz",
             "545 Hz",
             "557 Hz",
             "569 Hz",
             "582 Hz",
             "595 Hz",
             "608 Hz",
             "621 Hz",
             "635 Hz",
             "648 Hz",
             "663 Hz",
             "677 Hz",
             "692 Hz",
             "707 Hz",
             "723 Hz",
             "738 Hz",
             "755 Hz",
             "771 Hz",
             "788 Hz",
             "805 Hz",
             "823 Hz",
             "841 Hz",
             "859 Hz",
             "878 Hz",
             "897 Hz",
             "917 Hz",
             "937 Hz",
             "958 Hz",
             "979 Hz",
            "1000 Hz",
            "1022 Hz",
            "1044 Hz",
            "1067 Hz",
            "1091 Hz",
            "1114 Hz",
            "1139 Hz",
            "1164 Hz",
            "1189 Hz",
            "1215 Hz",
            "1242 Hz",
            "1269 Hz",
            "1297 Hz",
            "1325 Hz",
            "1354 Hz",
            "1384 Hz",
            "1414 Hz",
            "1445 Hz",
            "1477 Hz",
            "1509 Hz",
            "1542 Hz",
            "1576 Hz",
            "1611 Hz",
            "1646 Hz",
            "1682 Hz",
            "1719 Hz",
            "1756 Hz",
            "1795 Hz",
            "1834 Hz",
            "1874 Hz",
            "1915 Hz",
            "1957 Hz",
            "2000 Hz",
            "2019 Hz",
            "2038 Hz",
            "2056 Hz",
            "2075 Hz",
            "2094 Hz",
            "2113 Hz",
            "2131 Hz",
            "2150 Hz",
            "2169 Hz",
            "2188 Hz",
            "2206 Hz",
            "2225 Hz",
            "2244 Hz",
            "2262 Hz",
            "2281 Hz",
            "2300 Hz",
            "2319 Hz",
            "2338 Hz",
            "2356 Hz",
            "2375 Hz",
            "2394 Hz",
            "2412 Hz",
            "2431 Hz",
            "2450 Hz",
            "2469 Hz",
            "2487 Hz",
            "2506 Hz",
            "2525 Hz",
            "2544 Hz",
            "2562 Hz",
            "2581 Hz",
            "2591 Hz",
            "2592 Hz",
            "2593 Hz",
            "2594 Hz",
            "2595 Hz",
            "2596 Hz",
            "2597 Hz",
            "2598 Hz",
            "2599 Hz",
            "2600 Hz"};
        }
    
        static public void HaveIGotEverything()
        {
            Dictionary<string, ParamSetItemBase> ControllerParamLookup = new Dictionary<string, ParamSetItemBase>();
            LoadParamSetItems(ControllerParamLookup);
            foreach (var item in GetHGChorusParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGChorusParams Missing param def for " + item);
                
            }
            foreach (var item in GetHGFlangeParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGFlangeParams Missing param def for " + item);

            }
            foreach (var item in GetHGTremoloParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGTremoloParams Missing param def for " + item);

            }
            foreach (var item in GetHGPitchShiftParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGPitchShiftParams Missing param def for " + item);

            }
            foreach (var item in GetHGWahParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGWahParams Missing param def for " + item);

            }

            foreach (var item in GetHGPhaserParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetHGPhaserParams Missing param def for " + item);

            }
            foreach (var item in GetLGChorusParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGChorusParams Missing param def for " + item);

            }
            foreach (var item in GetLGFlangeParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGFlangeParams Missing param def for " + item);

            }
           
            foreach (var item in GetLGTremoloParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGTremoloParams Missing param def for " + item);

            }
            foreach (var item in GetLGPitchShiftParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGPitchShiftParams Missing param def for " + item);

            }
            foreach (var item in GetLGWahParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGWahParams Missing param def for " + item);

            }
            foreach (var item in GetLGPhaserParams())
            {
                if (!ControllerParamLookup.ContainsKey(item))
                    Console.WriteLine(item + "GetLGPhaserParams Missing param def for " + item);

            }
       
    
        }

    }
}
