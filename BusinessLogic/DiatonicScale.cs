using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class DiatonicScale : Scale
    {
        #region ----Fields----

        private List<StepType> _steps = new List<StepType>(){StepType.WholeStep,
                StepType.WholeStep,
                StepType.HalfStep,
                StepType.WholeStep,
                StepType.WholeStep,
                StepType.WholeStep,
                StepType.HalfStep};

        private Note _rootNote;
        

      

        #endregion

        #region ----Properties----

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
                return notes;
            }
        }

        public override List<IntervalType> Intervals
        {
            get { return _intervals; }
        }

        public List<StepType> Steps
        {
            get { return _steps; }
        }

        #endregion



        #region ----Constructors----

        public DiatonicScale(Note rootNote)
        {
            CreateIntervals();
            _rootNote = rootNote;
        }

        public DiatonicScale(Note rootNote, IDiatonicMode diatonicMode)
        {
            CreateIntervals();
            _rootNote = rootNote;
            _steps = diatonicMode.ReorderSteps(_steps);

        }

        #endregion

        #region ----Methods----

        private void CreateIntervals()
        {
            StepAdapter stepAdapter = new StepAdapter();
            foreach (StepType stepType in _steps)
            {
                _intervals.Add(stepAdapter.GetIntervalFromStep(stepType));
            }
        }


        #endregion

    }
}
