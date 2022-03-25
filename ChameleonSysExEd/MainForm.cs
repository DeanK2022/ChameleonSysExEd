using ChamSysExFileStructs;
using ChameleonSysExHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChameleonSysExEd.ChameleonSysExComplete;
using Sanford.Multimedia.Midi;

namespace ChameleonSysExEd
{
    public partial class MainForm : Form
    {
        public ChameleonSysExComplete sysEx = new ChameleonSysExComplete();
        private FormDirtyTracker _dirtyTracker;
        private readonly Dictionary<string, ParamSetItemBase> ControllerParamLookup = new Dictionary<string, ParamSetItemBase>();
        private List<InputDevice> recordingInputDevices = null;

        public MainForm()
        {
            InitializeComponent();
            //ParamSetHelpers.HaveIGotEverything();
            ParamSetHelpers.LoadParamSetItems(ControllerParamLookup);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (openFileDialogSysEx.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusFileName.Text = openFileDialogSysEx.FileName;
                FileStream fs = new FileStream(openFileDialogSysEx.FileName, FileMode.Open);

                //TChameleonCompositeObj = ChamObjectHelpers.FromFileStream(fs);

                fs.Close();

                sysEx.LoadFromFile(openFileDialogSysEx.FileName);
                LoadFormFromComposite(sysEx);
               // LoadFormFromComposite(TChameleonCompositeObj);
               // ChamObjectHelpers.DumpAddresses(TChameleonCompositeObj);
            }
        }
        private void LoadFormFromComposite(ChameleonSysExComplete mySysEx)
        {
            unsafe
            {

                int oo = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeAllStructsUnion));
         
                int oa = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHeaderLowGain));
                int os = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHeaderHighGain));
                int od = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeTailend));
                int of = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainChorus));
                int og = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainFlanger));
                int oh = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainPhaser));
                int oj = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainPitchShift));
                int ok = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainTremolo));
                int oq = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeLowGainWah));
                int ow = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainChorus));
                int oe = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainFlanger));
                int or = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainPhaser));
                int ot = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainPitchShift));
                int oy = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainTremolo));
                int ou = System.Runtime.InteropServices.Marshal.SizeOf(typeof(TChameleonCompositeHighGainWah));

                tbTitle.Text = mySysEx.Title;
                cbConfiguration.SelectedIndex = mySysEx.Control.ConfigMode;

                nudMixerReverbLevel.Value = mySysEx.Mixer.ReverbLevel;
                nudMixerDelayLevel.Value = mySysEx.Mixer.DelayLevel;
                nudMixerPan.Value = mySysEx.Mixer.Pan;
                nudMixerMixDir.Value = mySysEx.Mixer.MixDir;
                nudMixerRightLevel.Value = mySysEx.Mixer.RightLevel;
                nudMixerLeftLevel.Value = mySysEx.Mixer.LeftLevel;
                nudMixerMasterVolume.Value = mySysEx.Mixer.MasterVolume;

                cbHushInOut.SelectedIndex = mySysEx.Hush.InOut;
                nudHushThreshold.Value = mySysEx.Hush.Threshold;

                nudPreEqLowFreqLevel.Value = mySysEx.PreEQ.LowFreqLevel;
                cbPreEqLowFreq.SelectedIndex = mySysEx.PreEQ.LowFreq;

                nudPreEqMidFreqLevel.Value = mySysEx.PreEQ.MidFreqLevel ;
                cbPreEqMidFreq.SelectedIndex = mySysEx.PreEQ.MidFreq;
                cbPreEqMidBand.SelectedIndex = mySysEx.PreEQ.MidBand;

                cbPostEqBassFreq.SelectedIndex = mySysEx.PostEQ.BassFreq;
                cbPostEqBassBand.SelectedIndex = mySysEx.PostEQ.BassBand;
                cbPostEqMidFreq.SelectedIndex = mySysEx.PostEQ.MidFreq;
                cbPostEqMidBand.SelectedIndex = mySysEx.PostEQ.MidBand;

                cbPostEqPresFreq.SelectedIndex = mySysEx.PostEQ.PresFreq;
                cbPostEqPresBand.SelectedIndex = mySysEx.PostEQ.PresBand;

                cbPostEqTrebleFreq.SelectedIndex = mySysEx.PostEQ.TrebleFreq;
                cbPostEqTrebleBand.SelectedIndex = mySysEx.PostEQ.TrebleBand;

                nudSpkSimReactance.Value = mySysEx.SpeakerSim.Reactance;
                nudSpkSimMicPlace.Value = mySysEx.SpeakerSim.MicPlace;

                cbReverbState.SelectedIndex = mySysEx.Reverb.ReverbState;
                nudReverbHighFreqDamp.Value = mySysEx.Reverb.ReverbHighFreqDamp;
                nudReverbDecay.Value = mySysEx.Reverb.ReverbDecay;
                nudReverbMix.Value = mySysEx.Reverb.ReverbMix;

                cbTapDelay2Multiplier.SelectedIndex = mySysEx.TapDelay.TapDelayD2Multiplyer;

                cbTapDelay1Multiplier.SelectedIndex = mySysEx.TapDelay.TapDelayD2Multiplyer;

                cbControllerAssignment.SelectedIndex = 1;
                SetControllerAssignmentFromClass(1);
                //cbControllerAssignmentParam.SelectedIndex = mySysEx.ControllerAssignment[0].Param;
                //cbControllerAssignmentNumber.SelectedIndex = mySysEx.ControllerAssignment[0].Number;
                //cbControllerAssignmentLowerLimit.SelectedIndex = mySysEx.ControllerAssignment[0].LowerLimit;
                //cbControllerAssignmentUpperLimit.SelectedIndex = mySysEx.ControllerAssignment[0].UpperLimit;

                cbDelaySource2.SelectedIndex = mySysEx.Delay.Source2;
                cbDelayState.SelectedIndex = mySysEx.Delay.DelayState;
                cbDelayMuteType.SelectedIndex = mySysEx.Delay.MuteType;
                nudDelayHighFreqDamp.Value = mySysEx.Delay.HighFreqDamp;
                nudDelaySourceMix.Value = mySysEx.Delay.SourceMix;

                nudDelay1Time.Value = mySysEx.Delay.D1Time; // ((mySysEx.Delay.D1TimeHighByte << 7) + mySysEx.Delay.D1Time) * 4;
                nudDelay1Pan.Value = mySysEx.Delay.D1Pan;
                nudDelay1OutLevel.Value = mySysEx.Delay.D1OutLevel;
                nudDelay1Regen.Value = mySysEx.Delay.D1Regen;

                nudDelay2Time.Value = mySysEx.Delay.D2Time;// ((mySysEx.Delay.D2TimeHighByte << 7) + mySysEx.Delay.D2Time) * 4;
                nudDelay2Pan.Value = mySysEx.Delay.D2Pan;
                nudDelay2OutLevel.Value = mySysEx.Delay.D2OutLevel;
                nudDelay2Regen.Value = mySysEx.Delay.D2Regen;

                if (mySysEx.Control.ConfigMode > 5)  //low gain, compressor allowed
                {
                    gbCompressor.Visible = true;
                    nudGainAmount.Minimum = 0;
                    nudGainAmount.Maximum = 48;
                    cbGainType.Enabled = true;
                    nudGainVariac.Enabled = false;

                    cbCompressorInOut.SelectedIndex = mySysEx.Compressor.InOut;
                    nudCompressorThreshold.Value = mySysEx.Compressor.Threshold;
                    cbCompressorAttack.SelectedIndex = mySysEx.Compressor.Attack;
                    cbCompressorRelease.SelectedIndex = mySysEx.Compressor.Release;

                    nudGainPresence.Value = mySysEx.GainLow.Presence;
                    nudGainTrebleLevel.Value = mySysEx.GainLow.TrebleLevel;
                    nudGainMidLevel.Value = mySysEx.GainLow.MidLevel;
                    nudGainBassLevel.Value = mySysEx.GainLow.BassLevel;
                    nudGainVariac.Enabled = false;
                    cbGainType.SelectedIndex = mySysEx.GainLow.GainType;
                    nudGainAmount.Minimum = 0;
                    nudGainAmount.Maximum = 48;
                    nudGainAmount.Value = mySysEx.GainLow.GainAmount; //+ 40;
                }
                else //high gain
                {
                    gbCompressor.Visible = false;
                    nudGainAmount.Minimum = 12;
                    nudGainAmount.Maximum = 78;
                    cbGainType.Enabled = false;
                    nudGainVariac.Enabled = true;

                    nudGainPresence.Value = mySysEx.GainHigh.Presence;
                    nudGainTrebleLevel.Value = mySysEx.GainHigh.TrebleLevel ;
                    nudGainMidLevel.Value = mySysEx.GainHigh.MidLevel;
                    nudGainBassLevel.Value = mySysEx.GainHigh.BassLevel;
                    nudGainVariac.Value = mySysEx.GainHigh.Variac;
                    nudGainAmount.Value = mySysEx.GainHigh.GainAmount;

                }
                cbSpkSimSpkType.SelectedIndex = mySysEx.SpeakerSim.SpeakerType;
                cbSpkSimSpkSim.SelectedIndex = mySysEx.SpeakerSim.SpeakerSim;
       
                if (ChamObjectHelpers.IsChorus(mySysEx.Control.ConfigMode))
                {
                    cbChorusInOut.SelectedIndex = mySysEx.Chorus.ChorusInOut;
                    cbReverbState.SelectedIndex = mySysEx.Reverb.ReverbState;
                    nudChorus1Delay.Value = mySysEx.Chorus.Chorus1Delay ;
                    nudChorus1Depth.Value = mySysEx.Chorus.Chorus1Depth;
                    nudChorus1Pan.Value = mySysEx.Chorus.Chorus1Pan;
                    nudChorus1Level.Value = mySysEx.Chorus.Chorus1Level ;
                    nudChorus1Rate.Value = mySysEx.Chorus.Chorus1Rate;// (mySysEx.Chorus.Chorus1RateHighByte << 7) + mySysEx.Chorus.Chorus1Rate;

                    nudChorus2Delay.Value = mySysEx.Chorus.Chorus2Delay ;
                    nudChorus2Depth.Value = mySysEx.Chorus.Chorus2Depth;
                    nudChorus2Pan.Value = mySysEx.Chorus.Chorus2Pan;
                    nudChorus2Level.Value = mySysEx.Chorus.Chorus2Level ;
                    nudChorus2Rate.Value = mySysEx.Chorus.Chorus2Rate;// (mySysEx.Chorus.Chorus2RateHighByte << 7) + mySysEx.Chorus.Chorus2Rate;
                }

                if (ChamObjectHelpers.IsFlanger(mySysEx.Control.ConfigMode))
                {
                    cbFlangerInOut.SelectedIndex = mySysEx.Flanger.FlangeInOut;
                    nudFlangerRegeneration.Value = mySysEx.Flanger.Regeneration;
                   
                    nudFlanger1Level.Value = mySysEx.Flanger.Level1;
                    nudFlanger1Pan.Value = mySysEx.Flanger.Pan1;
                    nudFlanger1Depth.Value = mySysEx.Flanger.Depth1;
                    nudFlanger1Rate.Value = mySysEx.Flanger.Rate1; //(mySysEx.Flanger.Rate1High <<7) + mySysEx.Flanger.Rate1Low ;
                    nudFlanger2Level.Value = mySysEx.Flanger.Level2;
                    nudFlanger2Pan.Value = mySysEx.Flanger.Pan2;
                    nudFlanger2Depth.Value = mySysEx.Flanger.Depth2;
                    nudFlanger2Rate.Value = mySysEx.Flanger.Rate2; //(mySysEx.Flanger.Rate2High << 7) + mySysEx.Flanger.Rate2Low;
                };

                if (ChamObjectHelpers.IsTremolo(mySysEx.Control.ConfigMode))
                {
                    cbTremoloLocation.SelectedIndex = mySysEx.Tremolo.TremoloLocation;
                    nudTremoloRate.Value = mySysEx.Tremolo.TremoloRate;
                    nudTremoloDepth.Value = mySysEx.Tremolo.TremoloDepth;
                    cbTremoloShape.SelectedIndex = mySysEx.Tremolo.TremoloShape;
                    cbTremoloInOut.SelectedIndex = mySysEx.Tremolo.TremoloInOut;
                };

                if (ChamObjectHelpers.IsPitchShift(mySysEx.Control.ConfigMode))
                {
                    cbPitchShiftInOut.SelectedIndex = mySysEx.PitchShift.PitchShiftInOut;
                    nudPitchShiftLevel.Value = mySysEx.PitchShift.Level;
                    nudPitchShiftPan.Value = mySysEx.PitchShift.Pan;
                    nudPitchShiftPitch.Value = mySysEx.PitchShift.Pitch;//((mySysEx.PitchShift.PitchHigh << 7) +(mySysEx.PitchShift.Pitch) - 120) * 20;
                    nudPitchShiftFineTune.Value = mySysEx.PitchShift.FineTune;
                    cbPitchShiftSpeed.SelectedIndex = mySysEx.PitchShift.Speed;
                };

                if (ChamObjectHelpers.IsWah(mySysEx.Control.ConfigMode))
                {
                    cbWahFrequency.SelectedIndex = mySysEx.Wah.Freq;
                    cbWahInOut.SelectedIndex = mySysEx.Wah.WahInOut;
                };

                if (ChamObjectHelpers.IsPhaser(mySysEx.Control.ConfigMode))
                {
                    nudPhaserDepth.Value = mySysEx.Phaser.Depth;
                    nudPhaserReson.Value = mySysEx.Phaser.Resonance;
                    nudPhaserRate.Value = mySysEx.Phaser.Rate;
                    cbPhaserStage.SelectedIndex = mySysEx.Phaser.Stage;
                    cbPhaserInOut.SelectedIndex = mySysEx.Phaser.PhaserInOut;
                };
                SetControllerAssignmentFromClass(0);
            }
        }
        private void SetControllerAssignmentFromClass(int controllerIdx)
        {
            cbControllerAssignment.SelectedIndex = controllerIdx ;
            cbControllerAssignmentParam.SelectedIndex = sysEx.ControllerAssignment[controllerIdx].Param;
            cbControllerAssignmentNumber.SelectedIndex = sysEx.ControllerAssignment[controllerIdx].Number;

            if (ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()] is ParamSetItemChoices)
            {
                ParamSetItemChoices psic = (ParamSetItemChoices)ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()];
                cbControllerAssignmentLowerLimit.Items.Clear();
                cbControllerAssignmentLowerLimit.Items.AddRange(psic.lowerLimitValues);
                cbControllerAssignmentUpperLimit.Items.Clear();
                cbControllerAssignmentUpperLimit.Items.AddRange(psic.upperLimitValues);
                cbControllerAssignmentLowerLimit.SelectedIndex = sysEx.ControllerAssignment[controllerIdx].LowerLimit;
                cbControllerAssignmentUpperLimit.SelectedIndex = sysEx.ControllerAssignment[controllerIdx].UpperLimit;
            }

            if (ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()] is ParamSetItemNumeric)
            {
                ParamSetItemNumeric psin = (ParamSetItemNumeric)ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()];
                nudControllerAssignmentLowerLimit.Maximum = psin.limitMax;
                nudControllerAssignmentLowerLimit.Minimum = psin.limitMin;
                nudControllerAssignmentUpperLimit.Maximum = psin.limitMax;
                nudControllerAssignmentUpperLimit.Minimum = psin.limitMin;

                nudControllerAssignmentLowerLimit.Value = sysEx.ControllerAssignment[controllerIdx].LowerLimit;
                nudControllerAssignmentUpperLimit.Value = sysEx.ControllerAssignment[controllerIdx].UpperLimit;
            }



        }
        private ChameleonSysExComplete UIToChameleonSysExComplete ()
        {
            ChameleonSysExComplete curSysEx = new ChameleonSysExComplete
            {
                Title = tbTitle.Text
            };
            curSysEx.Control.ConfigMode = (byte)cbConfiguration.SelectedIndex;

            curSysEx.Mixer.ReverbLevel = (sbyte)nudMixerReverbLevel.Value;
            curSysEx.Mixer.DelayLevel = (sbyte)nudMixerDelayLevel.Value;
            curSysEx.Mixer.Pan = (byte)nudMixerPan.Value;
            curSysEx.Mixer.MixDir = (byte)nudMixerMixDir.Value;
            curSysEx.Mixer.RightLevel = (sbyte)nudMixerRightLevel.Value;
            curSysEx.Mixer.LeftLevel = (sbyte)nudMixerLeftLevel.Value;
            curSysEx.Mixer.MasterVolume = (byte)nudMixerMasterVolume.Value;

            curSysEx.Hush.InOut = (byte)cbHushInOut.SelectedIndex;
            curSysEx.Hush.Threshold = (sbyte)nudHushThreshold.Value;
 
            curSysEx.PreEQ.LowFreqLevel = (sbyte)nudPreEqLowFreqLevel.Value;
            curSysEx.PreEQ.LowFreq = (byte)cbPreEqLowFreq.SelectedIndex;

            curSysEx.PreEQ.MidFreqLevel = (sbyte)nudPreEqMidFreqLevel.Value;
            curSysEx.PreEQ.MidFreq = (byte)cbPreEqMidFreq.SelectedIndex;
            curSysEx.PreEQ.MidBand = (byte)cbPreEqMidBand.SelectedIndex;

            curSysEx.PostEQ.BassFreq = (byte)cbPostEqBassFreq.SelectedIndex;
            curSysEx.PostEQ.BassBand = (byte)cbPostEqBassBand.SelectedIndex;
            curSysEx.PostEQ.MidFreq = (byte)cbPostEqMidFreq.SelectedIndex;
            curSysEx.PostEQ.MidBand = (byte)cbPostEqMidBand.SelectedIndex;
            
            curSysEx.PostEQ.PresFreq = (byte)cbPostEqPresFreq.SelectedIndex;
            curSysEx.PostEQ.PresBand = (byte)cbPostEqPresBand.SelectedIndex;
           
            curSysEx.PostEQ.TrebleFreq = (byte)cbPostEqTrebleFreq.SelectedIndex;
            curSysEx.PostEQ.TrebleBand = (byte)cbPostEqTrebleBand.SelectedIndex;
     
            curSysEx.SpeakerSim.Reactance = (sbyte)nudSpkSimReactance.Value;
            curSysEx.SpeakerSim.MicPlace = (sbyte)nudSpkSimMicPlace.Value;

            curSysEx.Reverb.ReverbState = (byte)cbReverbState.SelectedIndex;
            curSysEx.Reverb.ReverbHighFreqDamp = (byte)nudReverbHighFreqDamp.Value;
            curSysEx.Reverb.ReverbDecay = (byte)nudReverbDecay.Value;
            curSysEx.Reverb.ReverbMix = (byte)nudReverbMix.Value;
     
            curSysEx.TapDelay.TapDelayD2Multiplyer = (byte)cbTapDelay2Multiplier.SelectedIndex;
    
            curSysEx.TapDelay.TapDelayD1Multiplyer = (byte)cbTapDelay1Multiplier.SelectedIndex;
        
            curSysEx.Delay.Source2 = (byte)cbDelaySource2.SelectedIndex;
            curSysEx.Delay.DelayState = (byte)cbDelayState.SelectedIndex;
            curSysEx.Delay.MuteType = (byte)cbDelayMuteType.SelectedIndex;
            curSysEx.Delay.HighFreqDamp = (byte)nudDelayHighFreqDamp.Value;
            curSysEx.Delay.SourceMix = (byte)nudDelaySourceMix.Value;

            curSysEx.Delay.D1Time = (short)nudDelay1Time.Value ;
            curSysEx.Delay.D1Pan = (byte)nudDelay1Pan.Value;
            curSysEx.Delay.D1OutLevel = (sbyte)nudDelay1OutLevel.Value;
            curSysEx.Delay.D1Regen = (sbyte)nudDelay1Regen.Value;
  
            curSysEx.Delay.D2Time	= (short)nudDelay2Time.Value ;
            curSysEx.Delay.D2Pan = (byte)nudDelay2Pan.Value;
            curSysEx.Delay.D2OutLevel = (sbyte)nudDelay2OutLevel.Value;
            curSysEx.Delay.D2Regen = (sbyte)nudDelay2Regen.Value;
            for (int idx = 0;idx < Constants.MAX_CONTROLLER_COUNT;idx++)
            {
                curSysEx.ControllerAssignment[idx].LowerLimit = sysEx.ControllerAssignment[idx].LowerLimit;
                curSysEx.ControllerAssignment[idx].UpperLimit = sysEx.ControllerAssignment[idx].UpperLimit;
                curSysEx.ControllerAssignment[idx].Number = sysEx.ControllerAssignment[idx].Number;
                curSysEx.ControllerAssignment[idx].Param = sysEx.ControllerAssignment[idx].Param;
            }
            if (ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()] is ParamSetItemChoices)
            {
                curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].LowerLimit = (byte)(cbControllerAssignmentLowerLimit.SelectedIndex);
                curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].UpperLimit = (byte)cbControllerAssignmentUpperLimit.SelectedIndex;
            }
            if (ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()] is ParamSetItemNumeric)
            {
                curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].LowerLimit = (byte)(nudControllerAssignmentLowerLimit.Value);
                curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].UpperLimit = (byte)nudControllerAssignmentUpperLimit.Value;
            }

            curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].Number = (byte)cbControllerAssignmentNumber.SelectedIndex;
            curSysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].Param = (byte)cbControllerAssignmentParam.SelectedIndex;

            if (curSysEx.Control.ConfigMode > 5)  //low gain, compressor allowed
            {
                curSysEx.Compressor.InOut = (byte)cbCompressorInOut.SelectedIndex;
                curSysEx.Compressor.Threshold = (sbyte)nudCompressorThreshold.Value;
                curSysEx.Compressor.Attack = (byte)cbCompressorAttack.SelectedIndex;
                curSysEx.Compressor.Release = (byte)cbCompressorRelease.SelectedIndex;

                curSysEx.GainLow.Presence = (sbyte)nudGainPresence.Value;
                curSysEx.GainLow.TrebleLevel = (sbyte)nudGainTrebleLevel.Value;
                curSysEx.GainLow.MidLevel = (sbyte)nudGainMidLevel.Value;
                curSysEx.GainLow.BassLevel = (sbyte)nudGainBassLevel.Value;
                curSysEx.GainLow.GainType = (byte)cbGainType.SelectedIndex;
                curSysEx.GainLow.GainAmount = (byte)nudGainAmount.Value;
            }
            else //high gain
            {
                curSysEx.GainHigh.Presence = (sbyte)nudGainPresence.Value;
                curSysEx.GainHigh.TrebleLevel = (sbyte)nudGainTrebleLevel.Value;
                curSysEx.GainHigh.MidLevel = (sbyte)nudGainMidLevel.Value;
                curSysEx.GainHigh.BassLevel = (sbyte)nudGainBassLevel.Value;
                curSysEx.GainHigh.Variac = (sbyte)nudGainVariac.Value;
                curSysEx.GainHigh.GainAmount = (byte)nudGainAmount.Value;

            }
            curSysEx.SpeakerSim.SpeakerType = (byte)cbSpkSimSpkType.SelectedIndex;
            curSysEx.SpeakerSim.SpeakerSim = (byte)cbSpkSimSpkSim.SelectedIndex;

            if (ChamObjectHelpers.IsChorus(curSysEx.Control.ConfigMode))
            {
                curSysEx.Chorus.ChorusInOut  = (byte)cbChorusInOut.SelectedIndex;
                curSysEx.Reverb.ReverbState  = (byte)cbReverbState.SelectedIndex;
                curSysEx.Chorus.Chorus1Delay = (byte)nudChorus1Delay.Value;
                curSysEx.Chorus.Chorus1Depth = (byte)nudChorus1Depth.Value;
                curSysEx.Chorus.Chorus1Pan   = (byte)nudChorus1Pan.Value;
                curSysEx.Chorus.Chorus1Level = (sbyte)nudChorus1Level.Value;
                curSysEx.Chorus.Chorus1Rate  = (short)nudChorus1Rate.Value;

                curSysEx.Chorus.Chorus2Delay = (byte)nudChorus2Delay.Value;
                curSysEx.Chorus.Chorus2Depth = (byte)nudChorus2Depth.Value;
                curSysEx.Chorus.Chorus2Pan = (byte)nudChorus2Pan.Value;
                curSysEx.Chorus.Chorus2Level = (sbyte)nudChorus2Level.Value;
                curSysEx.Chorus.Chorus2Rate = (short)nudChorus2Rate.Value;
            }

            if (ChamObjectHelpers.IsFlanger(curSysEx.Control.ConfigMode))
            {
                curSysEx.Flanger.FlangeInOut = (byte)cbFlangerInOut.SelectedIndex;
                curSysEx.Flanger.Regeneration = (sbyte)nudFlangerRegeneration.Value;

                curSysEx.Flanger.Level1 = (sbyte)nudFlanger1Level.Value;
                curSysEx.Flanger.Pan1 = (byte)nudFlanger1Pan.Value;
                curSysEx.Flanger.Depth1 = (byte)nudFlanger1Depth.Value;
                curSysEx.Flanger.Rate1 = (short)nudFlanger1Rate.Value;
                curSysEx.Flanger.Level2 = (sbyte)nudFlanger2Level.Value;
                curSysEx.Flanger.Pan2 = (byte)nudFlanger2Pan.Value;
                curSysEx.Flanger.Depth2 = (byte)nudFlanger2Depth.Value;
                curSysEx.Flanger.Rate2 = (short)nudFlanger2Rate.Value;
            };

            if (ChamObjectHelpers.IsTremolo(curSysEx.Control.ConfigMode))
            {
                curSysEx.Tremolo.TremoloLocation = (byte)cbTremoloLocation.SelectedIndex;
                curSysEx.Tremolo.TremoloRate = (byte)nudTremoloRate.Value;
                curSysEx.Tremolo.TremoloDepth = (byte)nudTremoloDepth.Value;
                curSysEx.Tremolo.TremoloShape = (byte)cbTremoloShape.SelectedIndex;
                curSysEx.Tremolo.TremoloInOut = (byte)cbTremoloInOut.SelectedIndex;

            };

            if (ChamObjectHelpers.IsPitchShift(curSysEx.Control.ConfigMode))
            {
                curSysEx.PitchShift.PitchShiftInOut = (byte)cbPitchShiftInOut.SelectedIndex;
                curSysEx.PitchShift.Level = (sbyte)nudPitchShiftLevel.Value;
                curSysEx.PitchShift.Pan = (byte)nudPitchShiftPan.Value;
                curSysEx.PitchShift.Pitch = (short)nudPitchShiftPitch.Value;
                curSysEx.PitchShift.FineTune = (sbyte)nudPitchShiftFineTune.Value;
                curSysEx.PitchShift.Speed = (byte)cbPitchShiftSpeed.SelectedIndex;

            };

            if (ChamObjectHelpers.IsWah(curSysEx.Control.ConfigMode))
            {
                curSysEx.Wah.Freq = (byte)cbWahFrequency.SelectedIndex;
                curSysEx.Wah.WahInOut = (byte)cbWahInOut.SelectedIndex;

            };

            if (ChamObjectHelpers.IsPhaser(curSysEx.Control.ConfigMode))
            {
                curSysEx.Phaser.Depth = (byte)nudPhaserDepth.Value;
                curSysEx.Phaser.Resonance = (byte)nudPhaserReson.Value;
                curSysEx.Phaser.Rate = (byte)nudPhaserRate.Value;
                curSysEx.Phaser.Stage = (byte)cbPhaserStage.SelectedIndex;
                curSysEx.Phaser.PhaserInOut = (byte)cbPhaserInOut.SelectedIndex;

            };
            return curSysEx;
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //determine struct to use
            //TChameleonCompositeHeaderUnion tcu;
            ChameleonSysExComplete curSysx = UIToChameleonSysExComplete();
            byte[] toWrite = curSysx.ToByteArray();
            File.WriteAllBytes(openFileDialogSysEx.FileName + "2", toWrite);
            _dirtyTracker.SetAsClean();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDdlg.ShowDialog();
        }

        private void CbControllerAssignment_Enter(object sender, EventArgs e)
        {
            sysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].LowerLimit= (byte)cbControllerAssignmentLowerLimit.SelectedIndex ; 
            sysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].UpperLimit= (byte)cbControllerAssignmentUpperLimit.SelectedIndex ; 
            sysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].Param= (byte)cbControllerAssignmentParam.SelectedIndex;
            sysEx.ControllerAssignment[cbControllerAssignment.SelectedIndex].Number= (byte)cbControllerAssignmentNumber.SelectedIndex; 
        }

        private void CbControllerAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControllerAssignmentFromClass(cbControllerAssignment.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_dirtyTracker.IsDirty)
                Application.Exit();
            else
            {
                var confirmResult = MessageBox.Show("Are you sure to abandon changes?",
                                     "Confirm application close.",
                                     MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    // do nothing
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // instantiate a tracker to determine if values have changed in the form
            _dirtyTracker = new FormDirtyTracker(this);
        }

        private void cbControllerAssignmentParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParamSetItemBase paramSetItemBase = ControllerParamLookup[cbControllerAssignmentParam.SelectedItem.ToString()];
            bool isNumericParam = (paramSetItemBase is ParamSetItemNumeric);

            cbControllerAssignmentLowerLimit.Visible = !isNumericParam;
            nudControllerAssignmentLowerLimit.Visible = isNumericParam;


            cbControllerAssignmentUpperLimit.Visible = !isNumericParam;
            nudControllerAssignmentUpperLimit.Visible = isNumericParam;

            if (isNumericParam)
            {
                ParamSetItemNumeric paramSetItemNumeric = (ParamSetItemNumeric)paramSetItemBase;
                nudControllerAssignmentLowerLimit.Minimum = paramSetItemNumeric.limitMin;
                nudControllerAssignmentLowerLimit.Maximum = paramSetItemNumeric.limitMax;
                nudControllerAssignmentUpperLimit.Minimum = paramSetItemNumeric.limitMin;
                nudControllerAssignmentUpperLimit.Maximum = paramSetItemNumeric.limitMax;
            }
            else 
            {
                ParamSetItemChoices paramSetItemChoices = (ParamSetItemChoices)paramSetItemBase;
                cbControllerAssignmentUpperLimit.Items.Clear();
                cbControllerAssignmentUpperLimit.Items.AddRange(paramSetItemChoices.upperLimitValues);
                cbControllerAssignmentLowerLimit.Items.Clear();
                cbControllerAssignmentLowerLimit.Items.AddRange(paramSetItemChoices.lowerLimitValues);
            }
        }

        private void cbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbControllerAssignmentParam.Items.Clear();
            if (sysEx.Control.ConfigMode > 5)//lowgain
            {
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetLGChorusParams());
            }
            else
            {
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
                if (ChamObjectHelpers.IsChorus(sysEx.Control.ConfigMode))
                    cbControllerAssignmentParam.Items.AddRange(ParamSetHelpers.GetHGChorusParams());
            }
        }
        private async void InputDevice_SysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            //DialogHost.CloseDialogCommand.Execute(null, null);

            // get our recorded message
            var message = e.Message;

            // save our recoreded sysex message to disk in a new file and add it to the library
            try
            {
                var sysExLibrarianFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}";
                var filePath = $"{sysExLibrarianFolder}\\NewFile_{DateTime.Now.ToString("yyyy_dd_M_HH_mm_ss")}.syx";
                File.WriteAllBytes(filePath, message.GetBytes());
                // stop recording on all devices and dispose of the resources
                foreach (var inputDevice in recordingInputDevices)
                {
                    inputDevice.StopRecording();
                    inputDevice.Dispose();
                }

                recordingInputDevices = null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine( "An error occurred when receiving a sysex message " + ex);
            }
        }
        private void btnRecordSysEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputDevice.DeviceCount == 0)
                {
                    tbRecordStatus.Text = "You need at least one MIDI input device connected to record.";
         
                    return;
                }

                recordingInputDevices = new List<InputDevice>();

                for (var i = 0; i < InputDevice.DeviceCount; i++)
                {
                    var inputDevice = new InputDevice(i);
                    inputDevice.SysExMessageReceived += InputDevice_SysExMessageReceived;
                    inputDevice.StartRecording();

                    recordingInputDevices.Add(inputDevice);
                    var capabilities = InputDevice.GetDeviceCapabilities(i);
                    tbRecordStatus.Text = "Recording on " + inputDevice.DeviceID + " " + capabilities.name;
                }

                //await DialogHost.Show(new ProgressDialog(), "RootDialog", RecordingCanceled_ClosingEventHandler);


            }
            catch (InputDeviceException ex)
            {
                tbRecordStatus.Text = "An error occurred when recording";
            }
        }
        //private void LoadFormFromComposite(TChameleonCompositeLowGainChorus tccObj)
        //{
        //    unsafe
        //    {
        //        ChamObjectHelpers.DumpStructChorus(tccObj);
        //        ChamObjectHelpers.DumpAddresses(tccObj);

        //        tbTitle.Text = ChamObjectHelpers.ConvertToString(tccObj.Title, Constants.TITLE_LEN_BYTE);
        //        cbConfiguration.SelectedIndex = tccObj.Control.ConfigMode;

        //        nudMixerReverbLevel.Value = tccObj.Mixer.ReverbLevel - 63;
        //        nudMixerDelayLevel.Value = tccObj.Mixer.DelayLevel - 63;
        //        nudMixerPan.Value = tccObj.Mixer.Pan;
        //        nudMixerMixDir.Value = tccObj.Mixer.MixDir;
        //        nudMixerRightLevel.Value = tccObj.Mixer.RightLevel - 57;
        //        nudMixerLeftLevel.Value = tccObj.Mixer.LeftLevel - 57;
        //        nudMixerMasterVolume.Value = tccObj.Mixer.MasterVolume;

        //        cbHushInOut.SelectedIndex = tccObj.Hush.InOut;
        //        nudHushThreshold.Value = tccObj.Hush.Threshold - 90;

        //        nudPreEqLowFreqLevel.Value = tccObj.PreEQ.LowFreqLevel - 15;
        //        cbPreEqLowFreq.SelectedIndex = tccObj.PreEQ.LowFreq;

        //        nudPreEqMidFreqLevel.Value = tccObj.PreEQ.MidFreqLevel - 15;
        //        cbPreEqMidFreq.SelectedIndex = tccObj.PreEQ.MidFreq;
        //        cbPreEqMidBand.SelectedIndex = tccObj.PreEQ.MidBand;

        //        cbPostEqBassFreq.SelectedIndex = tccObj.PostEQ.BassFreq;
        //        cbPostEqBassBand.SelectedIndex = tccObj.PostEQ.BassBand;
        //        cbPostEqMidFreq.SelectedIndex = tccObj.PostEQ.MidFreq;
        //        cbPostEqMidBand.SelectedIndex = tccObj.PostEQ.MidBand;

        //        cbPostEqPresFreq.SelectedIndex = tccObj.PostEQ.PresFreq; 
        //        cbPostEqPresBand.SelectedIndex = tccObj.PostEQ.PresBand;

        //        cbPostEqTrebleFreq.SelectedIndex = tccObj.PostEQ.TrebleFreq;
        //        cbPostEqTrebleBand.SelectedIndex = tccObj.PostEQ.TrebleBand;

        //        nudSpkSimReactance.Value = tccObj.SpeakerSim.Reactance - 15;
        //        nudSpkSimMicPlace.Value = tccObj.SpeakerSim.MicPlace - 15;

        //        nudReverbHighFreqDamp.Value = tccObj.Reverb.ReverbHighFreqDamp;
        //        nudReverbDecay.Value = tccObj.Reverb.ReverbDecay;
        //        nudReverbMix.Value = tccObj.Reverb.ReverbMix;

        //        cbTapDelay2Multiplier.SelectedIndex = tccObj.TapDelay.TapDelayD2Multiplyer;

        //        cbTapDelay1Multiplier.SelectedIndex = tccObj.TapDelay.TapDelayD2Multiplyer;

        //        cbControllerAssignmentParam.SelectedIndex = tccObj.ControllerAssignment1.Param;
        //        cbControllerAssignmentNumber.SelectedIndex = tccObj.ControllerAssignment1.Number;
        //        cbControllerAssignment.SelectedIndex = tccObj.ControllerAssignment1.LowerLimit; 

        //        cbDelaySource2.SelectedIndex = tccObj.Delay.Source2;
        //        cbDelayState.SelectedIndex = tccObj.Delay.DelayState;
        //        cbDelayMuteType.SelectedIndex = tccObj.Delay.MuteType;
        //        nudDelayHighFreqDamp.Value = tccObj.Delay.HighFreqDamp;
        //        nudDelaySourceMix.Value = tccObj.Delay.SourceMix;

        //        nudDelay1Time.Value = ((tccObj.Delay.D1TimeHighByte << 7) + tccObj.Delay.D1Time) * 4;
        //        nudDelay1Pan.Value = tccObj.Delay.D1Pan;
        //        nudDelay1OutLevel.Value = tccObj.Delay.D1OutLevel - 63;
        //        nudDelay1Regen.Value = tccObj.Delay.D1Regen - 63;

        //        nudDelay2Time.Value = ((tccObj.Delay.D2TimeHighByte << 7) + tccObj.Delay.D2Time) * 4;
        //        nudDelay2Pan.Value = tccObj.Delay.D2Pan;
        //        nudDelay2OutLevel.Value = tccObj.Delay.D2OutLevel - 63;
        //        nudDelay2Regen.Value = tccObj.Delay.D2Regen - 63;

        //        cbControllerAssignmentLowerLimit.SelectedIndex = tccObj.ControllerAssignment1.LowerLimit + 1;
        //        cbControllerAssignmentUpperLimit.SelectedIndex = tccObj.ControllerAssignment1.UpperLimit;
        //        //nudCurPreset.Value = 

        //        if (tccObj.Control.ConfigMode > 5)  //low gain, compressor allowed
        //        {
        //            gbCompressor.Visible = true;
        //            nudGainAmount.Minimum = 0;
        //            nudGainAmount.Maximum = 48;

        //            cbCompressorInOut.SelectedIndex = tccObj.Compressor.InOut;
        //            nudCompressorThreshold.Value = tccObj.Compressor.Threshold -24;
        //            cbCompressorAttack.SelectedIndex = tccObj.Compressor.Attack;
        //            cbCompressorRelease.SelectedIndex = tccObj.Compressor.Release;

        //            nudGainPresence.Value = tccObj.GainLow.Presence - 15;
        //            nudGainTrebleLevel.Value = tccObj.GainLow.TrebleLevel - 15;
        //            nudGainMidLevel.Value = tccObj.GainLow.MidLevel - 15;
        //            nudGainBassLevel.Value = tccObj.GainLow.BassLevel - 15;
        //            nudGainVariac.Enabled = false;
        //            cbGainType.SelectedIndex = tccObj.GainLow.GainType;
        //            nudGainAmount.Minimum = 0;
        //            nudGainAmount.Maximum = 48;
        //            nudGainAmount.Value = tccObj.GainLow.GainAmount + 40;
        //        }
        //        else
        //        {
        //            gbCompressor.Visible = false;
        //            nudGainAmount.Minimum = 12;
        //            nudGainAmount.Maximum = 78;

        //            nudGainPresence.Value = tccObj.GainLow.Presence - 15;
        //            nudGainTrebleLevel.Value = tccObj.GainLow.TrebleLevel - 15;
        //            nudGainMidLevel.Value = tccObj.GainLow.MidLevel - 15;
        //            nudGainBassLevel.Value = tccObj.GainLow.BassLevel - 15;
        //            nudGainVariac.Value = tccObj.GainLow.GainType;
        //            nudGainAmount.Value = tccObj.GainLow.GainAmount + 12;

        //        }
        //        cbSpkSimSpkType.SelectedIndex = tccObj.SpeakerSim.SpeakerType;
        //        cbSpkSimSpkSim.SelectedIndex = tccObj.SpeakerSim.SpeakerSim;
        //        cbChorusInOut.SelectedIndex = tccObj.Chorus.ChorusInOut;
        //        cbReverbState.SelectedIndex = tccObj.Reverb.ReverbState;

        //        if (ChamObjectHelpers.IsChorus(tccObj.Control.ConfigMode))
        //        {
        //            nudChorus1Delay.Value = tccObj.Chorus.Chorus1Delay + 2;
        //            nudChorus1Depth.Value = tccObj.Chorus.Chorus1Depth;
        //            nudChorus1Pan.Value = tccObj.Chorus.Chorus1Pan;
        //            nudChorus1Level.Value = tccObj.Chorus.Chorus1Level - 63;
        //            nudChorus1Rate.Value = (tccObj.Chorus.Chorus1RateHighByte << 7) + tccObj.Chorus.Chorus1Rate;

        //            nudChorus2Delay.Value = tccObj.Chorus.Chorus2Delay + 2;
        //            nudChorus2Depth.Value = tccObj.Chorus.Chorus2Depth;
        //            nudChorus2Pan.Value = tccObj.Chorus.Chorus2Pan;
        //            nudChorus2Level.Value = tccObj.Chorus.Chorus2Level - 63;
        //            nudChorus2Rate.Value = (tccObj.Chorus.Chorus2RateHighByte << 7) + tccObj.Chorus.Chorus2Rate;
        //        }

        //        if (ChamObjectHelpers.IsFlanger(tccObj.Control.ConfigMode))
        //        {
        //            TChameleonFlanger* tcps = (TChameleonFlanger*)&tccObj.Chorus;
        //            cbFlangerInOut.SelectedIndex = tcps->FlangeInOut;
        //            nudFlangerRegeneration.Value = tcps->Regeneration;
        //            nudFlanger2Depth.Value = tcps->Depth2;
        //            nudFlanger2Pan.Value = tcps->Pan2;
        //            nudFlanger2Level.Value = tcps->Level2;
        //            nudFlanger2Rate.Value = tcps->Rate2Low;
        //            nudFlanger1Depth.Value = tcps->Depth1;
        //            nudFlanger1Pan.Value = tcps->Pan1;
        //            nudFlanger1Level.Value = tcps->Level1;
        //            nudFlanger1Rate.Value = tcps->Rate1Low;
        //        };

        //        if (ChamObjectHelpers.IsTremolo(tccObj.Control.ConfigMode))
        //        {
        //            TChameleonTremolo* tcps = (TChameleonTremolo*)&tccObj.Chorus;
        //            cbTremoloLocation.SelectedIndex = tcps->TremoloLocation;
        //            nudTremoloRate.Value = tcps->TremoloRate;
        //            nudTremoloDepth.Value = tcps->TremoloDepth;
        //            cbTremoloShape.SelectedIndex = tcps->TremoloShape;
        //            cbTremoloInOut.SelectedIndex = tcps->TremoloInOut;

        //        };

        //        if (ChamObjectHelpers.IsPitchShift(tccObj.Control.ConfigMode))
        //        {
        //            TChameleonPitchShift *tcps = (TChameleonPitchShift*) &tccObj.Chorus;
        //            nudPitchShiftFineTune.Value = tcps->FineTune;
        //            nudPitchShiftPitch.Value = tcps->Pitch;
        //            cbPitchShiftSpeed.SelectedIndex = tcps->Speed;
        //            cbPitchShiftInOut.SelectedIndex = tcps->PitchShiftInOut;
        //            nudPitchShiftPan.Value = tcps->Pan;
        //            nudPitchShiftLevel.Value = tcps->Level;

        //        };

        //        if (ChamObjectHelpers.IsWah(tccObj.Control.ConfigMode))
        //        {
        //            TChameleonWah* tcps = (TChameleonWah*)&tccObj.Chorus;
        //            cbWahFrequency.SelectedIndex = tcps->Freq;
        //            cbWahInOut.SelectedIndex = tcps->WahInOut;

        //        };

        //        if (ChamObjectHelpers.IsPhaser(tccObj.Control.ConfigMode))
        //        {
        //            TChameleonPhaser* tcps = (TChameleonPhaser*)&tccObj.Chorus;

        //            nudPhaserDepth.Value = tcps->Depth;
        //            nudPhaserReson.Value = tcps->Resonance;
        //            nudPhaserRate.Value = tcps->Rate;
        //            cbPhaserStage.SelectedIndex = tcps->Stage;
        //            cbPhaserInOut.SelectedIndex = tcps->PhaserInOut;
        //        };
        //    }
        //}

    }
 }
