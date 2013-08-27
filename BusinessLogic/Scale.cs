using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public abstract class Scale
    {
        
        #region ----Fields----

        protected List<IntervalType> _intervals;

        protected Note _rootNote;

        #endregion

        #region ----Properties----

        public abstract List<Note> Notes { get; }

        public abstract List<IntervalType> Intervals { get; }

        #endregion



        #region ----Methods----

        public List<Chord> GetChords(Chord chord)
        {
            throw new NotImplementedException();
        }


        #endregion
    }

}
