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

namespace ChameleonSysExEd
{
    public partial class MainForm : Form
    {
        //
        //public TChameleonCompositeLowGainChorus TChameleonCompositeObj;
        public ChameleonSysExComplete sysEx = new ChameleonSysExComplete();
        public MainForm()
        {
            InitializeComponent();
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

                nudReverbHighFreqDamp.Value = mySysEx.Reverb.ReverbHighFreqDamp;
                nudReverbDecay.Value = mySysEx.Reverb.ReverbDecay;
                nudReverbMix.Value = mySysEx.Reverb.ReverbMix;

                cbTapDelay2Multiplier.SelectedIndex = mySysEx.TapDelay.TapDelayD2Multiplyer;

                cbTapDelay1Multiplier.SelectedIndex = mySysEx.TapDelay.TapDelayD2Multiplyer;

                cbControllerAssignmentParam.SelectedIndex = mySysEx.ControllerAssignment1.Param;
                cbControllerAssignmentNumber.SelectedIndex = mySysEx.ControllerAssignment1.Number;
                cbControllerAssignment.SelectedIndex = mySysEx.ControllerAssignment1.LowerLimit;

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

                cbControllerAssignmentLowerLimit.SelectedIndex = mySysEx.ControllerAssignment1.LowerLimit + 1;
                cbControllerAssignmentUpperLimit.SelectedIndex = mySysEx.ControllerAssignment1.UpperLimit;
                //nudCurPreset.Value = 

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
            }
        }
        private ChameleonSysExComplete UIToChameleonSysExComplete ()
        {
            ChameleonSysExComplete curSysEx = new ChameleonSysExComplete();

            curSysEx.Title = tbTitle.Text;
            curSysEx.Control.ConfigMode = (byte)cbConfiguration.SelectedIndex;

            curSysEx.Mixer.ReverbLevel = (byte)nudMixerReverbLevel.Value;
            curSysEx.Mixer.DelayLevel = (byte)nudMixerDelayLevel.Value;
            curSysEx.Mixer.Pan = (byte)nudMixerPan.Value;
            curSysEx.Mixer.MixDir = (byte)nudMixerMixDir.Value;
            curSysEx.Mixer.RightLevel = (byte)nudMixerRightLevel.Value;
            curSysEx.Mixer.LeftLevel = (byte)nudMixerLeftLevel.Value;
            curSysEx.Mixer.MasterVolume = (byte)nudMixerMasterVolume.Value;

            curSysEx.Hush.InOut = (byte)cbHushInOut.SelectedIndex;
            curSysEx.Hush.Threshold = (byte)nudHushThreshold.Value;
 
            curSysEx.PreEQ.LowFreqLevel = (byte)nudPreEqLowFreqLevel.Value;
            curSysEx.PreEQ.LowFreq = (byte)cbPreEqLowFreq.SelectedIndex;

            curSysEx.PreEQ.MidFreqLevel = (byte)nudPreEqMidFreqLevel.Value;
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
     
            curSysEx.SpeakerSim.Reactance = (byte)nudSpkSimReactance.Value;
            curSysEx.SpeakerSim.MicPlace = (byte)nudSpkSimMicPlace.Value;
    
            curSysEx.Reverb.ReverbHighFreqDamp = (byte)nudReverbHighFreqDamp.Value;
            curSysEx.Reverb.ReverbDecay = (byte)nudReverbDecay.Value;
            curSysEx.Reverb.ReverbMix = (byte)nudReverbMix.Value;
     
            curSysEx.TapDelay.TapDelayD2Multiplyer = (byte)cbTapDelay2Multiplier.SelectedIndex;
    
            curSysEx.TapDelay.TapDelayD1Multiplyer = (byte)cbTapDelay1Multiplier.SelectedIndex;
        
            curSysEx.ControllerAssignment1.Param = (byte)cbControllerAssignmentParam.SelectedIndex;
            curSysEx.ControllerAssignment1.Number = (byte)cbControllerAssignmentNumber.SelectedIndex;
            curSysEx.ControllerAssignment1.LowerLimit = (byte)cbControllerAssignment.SelectedIndex;
        
            curSysEx.Delay.Source2 = (byte)cbDelaySource2.SelectedIndex;
            curSysEx.Delay.DelayState = (byte)cbDelayState.SelectedIndex;
            curSysEx.Delay.MuteType = (byte)cbDelayMuteType.SelectedIndex;
            curSysEx.Delay.HighFreqDamp = (byte)nudDelayHighFreqDamp.Value;
            curSysEx.Delay.SourceMix = (byte)nudDelaySourceMix.Value;

            curSysEx.Delay.D1Time = (short)nudDelay1Time.Value ;
            curSysEx.Delay.D1Pan = (byte)nudDelay1Pan.Value;
            curSysEx.Delay.D1OutLevel = (byte)nudDelay1OutLevel.Value;
            curSysEx.Delay.D1Regen = (byte)nudDelay1Regen.Value;
  
            curSysEx.Delay.D2Time	= (short)nudDelay2Time.Value ;
            curSysEx.Delay.D2Pan = (byte)nudDelay2Pan.Value;
            curSysEx.Delay.D2OutLevel = (byte)nudDelay2OutLevel.Value;
            curSysEx.Delay.D2Regen = (byte)nudDelay2Regen.Value;

            curSysEx.ControllerAssignment1.LowerLimit  = (byte)(cbControllerAssignmentLowerLimit.SelectedIndex -1);
            curSysEx.ControllerAssignment1.UpperLimit = (byte)cbControllerAssignmentUpperLimit.SelectedIndex;

            if (curSysEx.Control.ConfigMode > 5)  //low gain, compressor allowed
            {
                curSysEx.Compressor.InOut = (byte)cbCompressorInOut.SelectedIndex;
                curSysEx.Compressor.Threshold = (byte)nudCompressorThreshold.Value;
                curSysEx.Compressor.Attack = (byte)cbCompressorAttack.SelectedIndex;
                curSysEx.Compressor.Release = (byte)cbCompressorRelease.SelectedIndex;

                curSysEx.GainLow.Presence = (byte)nudGainPresence.Value;
                curSysEx.GainLow.TrebleLevel = (byte)nudGainTrebleLevel.Value;
                curSysEx.GainLow.MidLevel = (byte)nudGainMidLevel.Value;
                curSysEx.GainLow.BassLevel = (byte)nudGainBassLevel.Value;
                curSysEx.GainLow.GainType = (byte)cbGainType.SelectedIndex;
                curSysEx.GainLow.GainAmount = (byte)nudGainAmount.Value;

            }
            else //high gain
            {
                curSysEx.GainHigh.Presence = (byte)nudGainPresence.Value;
                curSysEx.GainHigh.TrebleLevel = (byte)nudGainTrebleLevel.Value;
                curSysEx.GainHigh.MidLevel = (byte)nudGainMidLevel.Value;
                curSysEx.GainHigh.BassLevel = (byte)nudGainBassLevel.Value;
                curSysEx.GainHigh.Variac = (byte)nudGainVariac.Value;
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
                curSysEx.Chorus.Chorus1Level = (byte)nudChorus1Level.Value;
                curSysEx.Chorus.Chorus1Rate  = (short)nudChorus1Rate.Value;

                curSysEx.Chorus.Chorus2Delay = (byte)nudChorus2Delay.Value;
                curSysEx.Chorus.Chorus2Depth = (byte)nudChorus2Depth.Value;
                curSysEx.Chorus.Chorus2Pan = (byte)nudChorus2Pan.Value;
                curSysEx.Chorus.Chorus2Level = (byte)nudChorus2Level.Value;
                curSysEx.Chorus.Chorus2Rate = (short)nudChorus2Rate.Value;
            }

            if (ChamObjectHelpers.IsFlanger(curSysEx.Control.ConfigMode))
            {
                curSysEx.Flanger.FlangeInOut = (byte)cbFlangerInOut.SelectedIndex;
                curSysEx.Flanger.Regeneration = (byte)nudFlangerRegeneration.Value;

                curSysEx.Flanger.Level1 = (byte)nudFlanger1Level.Value;
                curSysEx.Flanger.Pan1 = (byte)nudFlanger1Pan.Value;
                curSysEx.Flanger.Depth1 = (byte)nudFlanger1Depth.Value;
                curSysEx.Flanger.Rate1 = (short)nudFlanger1Rate.Value;
                curSysEx.Flanger.Level2 = (byte)nudFlanger2Level.Value;
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
                curSysEx.PitchShift.Level = (byte)nudPitchShiftLevel.Value;
                curSysEx.PitchShift.Pan = (byte)nudPitchShiftPan.Value;
                curSysEx.PitchShift.Pitch = (short)nudPitchShiftPitch.Value;
                curSysEx.PitchShift.FineTune = (byte)nudPitchShiftFineTune.Value;
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
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //determine struct to use
            //TChameleonCompositeHeaderUnion tcu;
            ChameleonSysExComplete curSysx = UIToChameleonSysExComplete();
            byte[] toWrite = curSysx.ToByteArray();
            File.WriteAllBytes(openFileDialogSysEx.FileName + "2", toWrite);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDdlg.ShowDialog();
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
