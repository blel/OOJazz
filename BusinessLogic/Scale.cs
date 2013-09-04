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

        protected List<Mode> _modes;

        protected Mode _currentMode;

        #endregion

        #region ----Properties----

        public abstract List<Note> Notes { get; }

        public abstract List<IntervalType> Intervals { get; set; }

        public abstract string CurrentMode { get; set; }

        public abstract List<Mode> Modes { get; }

        #endregion





        #region ----Methods----

        public abstract void RollToNextMode();

        public abstract List<IntervalType> GetIntervalsInCurrentMode();

        #endregion
    }

}
