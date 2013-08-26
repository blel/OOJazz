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
        
        private List<Note> _notes;

      

        #endregion

        #region ----Properties----

        public override List<Note> Notes
        {
            get {
                _notes = new List<Note>();
                _notes.Add(_rootNote);

                MasterNoteRow masterNoteRow = new MasterNoteRow();
                foreach (StepType stepType in _steps)
                {
                    _notes.Add(masterNoteRow.GetNextUpperNote(_notes.Last(), stepType));
                }
                return _notes; }
        }

        public List<StepType> Steps
        {
            get { return _steps; }
        }

        #endregion



        #region ----Constructors----

        public DiatonicScale(Note rootNote)
        {
            _rootNote = rootNote;
        }

        public DiatonicScale(Note rootNote, IDiatonicMode diatonicMode)
        {
            _rootNote = rootNote;
            _steps = diatonicMode.ReorderSteps(_steps);

        }


        #endregion

        #region ----Methods----

        #endregion

    }
}
