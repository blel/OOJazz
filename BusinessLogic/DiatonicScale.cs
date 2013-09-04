using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class DiatonicScale : Scale
    {
        #region ----Fields----

        private List<StepType> _steps = new List<StepType>(){
                StepType.WholeStep,
                StepType.WholeStep,
                StepType.HalfStep,
                StepType.WholeStep,
                StepType.WholeStep,
                StepType.WholeStep,
                StepType.HalfStep};

        #endregion

        #region ----Properties----

        public override string CurrentMode
        {
            get
            {
                return _currentMode.Name;
            }

            set
            {
                Mode newMode = (from cc in _modes
                                where cc.Name == value
                                select cc).First();
                if (newMode == null)
                {
                    throw new Exception(string.Format("The mode \"{0}\" is not existing for this scale.", value));
                }
                _currentMode = newMode;
            }
        } 
        
        public override List<Note> Notes
        {
            get {
                List<Note> notes = new List<Note>();
                notes.Add(_rootNote);

                MasterNoteRow masterNoteRow = new MasterNoteRow();
                foreach (StepType stepType in _steps)
                {
                    notes.Add(masterNoteRow.GetNextUpperNote(notes.Last(), stepType));
                }
                return notes.RollLeft(_currentMode.Degree - 1);
            }
        }

        public override List<IntervalType> Intervals
        {
            get { return _intervals; }
            set { _intervals = value; }
        }

        public List<StepType> Steps
        {
            get { return _steps; }
        }

        public override List<Mode> Modes
        {
            get { return _modes; }
        }

        #endregion

        #region ----Constructors----

        public DiatonicScale(Note rootNote)
        {
            InitScale();
            _rootNote = rootNote;
            _currentMode = _modes.First();
        }

        public DiatonicScale(Note rootNote, string diatonicModeType)
        {
            InitScale();
            Mode newMode = (from cc in _modes
                            where cc.Name == diatonicModeType
                            select cc).First();
            if (newMode == null)
            {
                throw new Exception(string.Format("The mode \"{0}\" is not existing for this scale.", diatonicModeType));
            }
            _currentMode = newMode;
            
            _rootNote = rootNote;
        }

        #endregion

        #region ----Methods----

        private void InitScale()
        {
            _modes = new List<Mode>() { 
            new Mode(1, "Ionian"), 
            new Mode(2, "Dorian"),
            new Mode(3, "Phrygian"),
            new Mode(4, "Lydian"),
            new Mode(5, "Mixolydian"),
            new Mode(6, "Aeolian"),
            new Mode(7, "Locrian") };
            CreateIntervals();
        }

        private void CreateIntervals()
        {
            _intervals = new List<IntervalType>();
            StepAdapter stepAdapter = new StepAdapter();
            foreach (StepType stepType in _steps)
            {
                _intervals.Add(stepAdapter.GetIntervalFromStep(stepType));
            }
        }

        public override void RollToNextMode()
        {
            if (_currentMode == _modes.Last())
            {
                _currentMode = _modes.First();
            }
            else
            {
                _currentMode = _modes.SkipWhile(cc => (_currentMode.Degree >= cc.Degree)).First();
            }
        }

        public override List<IntervalType> GetIntervalsInCurrentMode()
        {
            List<IntervalType> resultList = new List<IntervalType>();
            resultList.AddRange(_intervals);
            resultList.RollLeft(_currentMode.Degree - 1);
            return resultList;
        }

        #endregion
    }
}
