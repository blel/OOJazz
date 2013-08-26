using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public  class MasterNote
    {
        #region Fields
        private Step _stepDown;

        private Step _stepUp;

        private MasterNoteType _masterNote;
        #endregion

        #region Properties
        public Step StepDown
        {
            get
            {
                return _stepDown;
            }
            set
            {
                _stepDown = value;
            }
        }

        public Step StepUp
        {
            get
            {
                return _stepUp;
            }
            set
            {
                _stepUp = value;
            }
        }

        public MasterNoteType MasterNoteType
        {
            get
            {
               return _masterNote;
            }

        }
        #endregion Properties

        #region Constructors

        public MasterNote(MasterNoteType masterNote)
        {
            _masterNote = masterNote;
        }
        #endregion
    } 
   

}
