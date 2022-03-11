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
                    nudTremoloRate.Value = (mySysEx.Tremolo.TremoloRateHigh <<7) + mySysEx.Tremolo.TremoloRate;
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //determine struct to use
            TChameleonCompositeHeaderUnion tcu;
            tcu.s
            if (sysEx.Control.ConfigMode > 5) // low gain
            {
                TChameleonCompositeHeaderLowGain chameleonCompositeHeaderLow;
            }
            else
            {
                TChameleonCompositeHeaderHighGain chameleonCompositeHeaderLow;
            }
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
