using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{

    public class Interval
    {
        #region ---Fields----

        private Note _upperNote;
        
        private Note _lowerNote;

        private IntervalType _intervalType;

        #endregion

        #region ----Properties----

        public Note UpperNote
        {
            get
            {
                return _upperNote;
            }
        }

        public Note LowerNote
        {
            get
            {
                return _lowerNote;
            }
        }

        public IntervalType IntervalType
        {
            get
            {
                return _intervalType;
            }

        }

        #endregion

        #region Constructors

        public Interval(Note lowerNote, IntervalType intervalType)
        {
            //get the master note row to calculate upper note
            MasterNoteRow masterNoteRow = new MasterNoteRow();

            

        }

        public Interval(Note lowerNote, Note upperNote)
        {
            _lowerNote = lowerNote;
            _upperNote = upperNote;
        }

        public Interval(IntervalType intervalType, Note upperNote)
        { }


        #endregion
    }
}
