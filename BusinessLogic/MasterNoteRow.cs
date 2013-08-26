using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    /// <summary>
    /// This class represents the so called "stammtonreihe"
    /// It is the base object to do all kind of musical calculations
    /// </summary>
    public class MasterNoteRow
    {
        #region ----Fields----

        private MasterNote _masterNote;

        #endregion

        #region ----Constructor----

        public MasterNoteRow()
        {
            //A
            MasterNote masterNoteA = new MasterNote(MasterNoteType.A);
            _masterNote = masterNoteA;

            //B
            MasterNote masterNoteB = new MasterNote(MasterNoteType.B);

            //A -- B
            Step stepAB = new Step(StepType.WholeStep);
            stepAB.Lower = masterNoteA;
            stepAB.Upper = masterNoteB;

            masterNoteA.StepUp = stepAB;
            masterNoteB.StepDown = stepAB;

            //C
            MasterNote masterNoteC = new MasterNote(MasterNoteType.C);

            //B - C
            Step stepBC = new Step(StepType.HalfStep);
            stepBC.Lower = masterNoteB;
            stepBC.Upper = masterNoteC;

            masterNoteB.StepUp = stepBC;
            masterNoteC.StepDown = stepBC;

            //D
            MasterNote masterNoteD = new MasterNote(MasterNoteType.D);

            //C -- D
            Step stepCD = new Step(StepType.WholeStep);
            stepCD.Lower = masterNoteC;
            stepCD.Upper = masterNoteD;

            masterNoteC.StepUp = stepCD;
            masterNoteD.StepDown = stepCD;

            //E
            MasterNote masterNoteE = new MasterNote(MasterNoteType.E);

            //D -- E
            Step stepDE = new Step(StepType.WholeStep);
            stepDE.Lower = masterNoteD;
            stepDE.Upper = masterNoteE;

            masterNoteD.StepUp = stepDE;
            masterNoteE.StepDown = stepDE;

            //F
            MasterNote masterNoteF = new MasterNote(MasterNoteType.F);


            //E - F
            Step stepEF = new Step(StepType.HalfStep);
            stepEF.Lower = masterNoteE;
            stepEF.Upper = masterNoteF;

            masterNoteE.StepUp = stepEF;
            masterNoteF.StepDown = stepEF;

            //G
            MasterNote masterNoteG = new MasterNote(MasterNoteType.G);

            //F -- G
            Step stepFG = new Step(StepType.WholeStep);
            stepFG.Lower = masterNoteF;
            stepFG.Upper = masterNoteG;

            masterNoteF.StepUp = stepFG;
            masterNoteG.StepDown = stepFG;

            //G -- A
            Step stepGA = new Step(StepType.WholeStep);
            stepGA.Lower = masterNoteG;
            stepGA.Upper = masterNoteA;

            masterNoteG.StepUp = stepGA;
            masterNoteA.StepDown = stepGA;
        }

        #endregion 

        #region ----Methods----

        /// <summary>
        /// Cicles the _masterNote private Prime to the masternote with given masternote type
        /// </summary>
        /// <param name="masterNoteType"></param>
        /// <returns></returns>
        private MasterNote GetMasterNote(MasterNoteType masterNoteType)
        {
            if (masterNoteType == _masterNote.MasterNoteType)
            {
                return _masterNote;
            }
            else
            {
                _masterNote = _masterNote.StepUp.Upper;
                return GetMasterNote(masterNoteType);
            }
        }

        /// <summary>
        /// returns the next upper masternotetype to the given masternote type
        /// </summary>
        /// <param name="masterNoteType"></param>
        /// <returns></returns>
        private MasterNoteType GetNextUpperNoteType(MasterNoteType masterNoteType)
        {
            if (masterNoteType == _masterNote.MasterNoteType)
            {
                return _masterNote.StepUp.Upper.MasterNoteType;
            }
            else
            {
                _masterNote = _masterNote.StepUp.Upper;
                return GetNextUpperNoteType(masterNoteType);
            }
        }

        /// <summary>
        /// returns the next lower masternotetype to the given masternote type
        /// </summary>
        /// <param name="masterNoteType"></param>
        /// <returns></returns>
        private MasterNoteType GetNextLowerNoteType(MasterNoteType masterNoteType)
        {
            if (masterNoteType == _masterNote.MasterNoteType)
            {
                return _masterNote.StepDown.Lower.MasterNoteType;
            }
            else
            {
                _masterNote = _masterNote.StepDown.Lower;
                return GetNextLowerNoteType(masterNoteType);
            }
        }

        /// <summary>
        /// returns half step count to next upper masternote for given masternote type
        /// </summary>
        /// <param name="masterNoteType"></param>
        /// <returns></returns>
        private StepType StepsToUpper(MasterNoteType masterNoteType)
        {
            return GetMasterNote(masterNoteType).StepUp.StepType;
        }

        /// <summary>
        /// returns half step count to next upper masternote for given masternote type
        /// </summary>
        /// <param name="masterNoteType"></param>
        /// <returns></returns>
        private StepType StepsToLower(MasterNoteType masterNoteType)
        {
            return GetMasterNote(masterNoteType).StepDown.StepType;
        }

        private int GetStepCountBetween(MasterNoteType lowerNoteType, MasterNoteType upperNoteType)
        {
            GetMasterNote(lowerNoteType);
            int stepCount = 0;
            while (_masterNote.MasterNoteType != upperNoteType)
            {
                stepCount += (int)_masterNote.StepUp.StepType;
                _masterNote = _masterNote.StepUp.Upper;
            }
            return stepCount;

        }


        /// <summary>
        /// Returns the next upper note with requested StepType 
        /// This function is here to calculate diatonic scales
        /// </summary>
        /// <param name="lowerNote"></param>
        /// <param name="requestedStepType"></param>
        /// <returns></returns>
        public Note GetNextUpperNote(Note lowerNote, StepType requestedStepType)
        {
            
            Note upperNote = new Note(GetNextUpperNoteType(lowerNote.MasterNoteType));
            StepType stepTypeBetween = StepsToUpper(lowerNote.MasterNoteType);
            if (requestedStepType == stepTypeBetween)
            {
                upperNote.Accidentials = lowerNote.Accidentials;
                return upperNote;
            }
            else 
            {
                int resultingAccidentials =(int)requestedStepType - ((int)stepTypeBetween -(int)lowerNote.Accidentials);
               upperNote.Accidentials = (Accidentials)resultingAccidentials;
               return upperNote;
            }
        }

        public Interval GetIntervalUp(Note lowerNote, IntervalType intervalType)
        {
            //initialize master note carousel...
            GetMasterNote(lowerNote.MasterNoteType);

            //turn, turn, turn
            for (int i=0; i< (int) intervalType.MasterIntervalType; i++)
            {
                _masterNote = _masterNote.StepUp.Upper;
            }

            //NoteType of resulting masternote is the note we want.
            Note upperNote = new Note(_masterNote.MasterNoteType);

            //Calculate Accidentials
            int availableSteps = GetStepCountBetween(lowerNote.MasterNoteType, upperNote.MasterNoteType);
            int requiredSteps = intervalType.HalfStepCount;

            int resultingAccidentials = requiredSteps - (availableSteps - (int)lowerNote.Accidentials);
            upperNote.Accidentials = (Accidentials)resultingAccidentials;

            return new Interval(lowerNote, upperNote);
        }

        #endregion 
    }
}
