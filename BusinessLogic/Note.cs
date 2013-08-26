using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class Note
    {
        #region ----Fields----
        private int _octave;

        private MasterNoteType _notetype;

        private Accidentials _accidentials;

        #endregion

        #region ----Properties----

        public MasterNoteType MasterNoteType
        {
            get
            {
                return _notetype;
            }
           
        }

        public Accidentials Accidentials
        {
            get { return _accidentials; }
            set { _accidentials = value; }
        }

        public int Octave
        {
            get
            {
                return _octave;
            }
        }

        #endregion

        #region ----Constructors----

        public Note(MasterNoteType notetype)
        {
            _notetype = notetype;
        }

        public Note(MasterNoteType notetype, Accidentials accidentials)
        {
            _notetype = notetype;
            _accidentials = accidentials;
        }

        public Note(MasterNoteType notetype, Accidentials accidentials, int octave)
        {
            _notetype = notetype;
            _accidentials = accidentials;
            _octave = octave;
            
        }

        #endregion

        #region---- Methods----

        public void Raise()
        {
            if (_accidentials < Accidentials.doublesharp)
            {
                _accidentials += 1;
            }
        }

        public void Lower()
        {
            if (_accidentials > Accidentials.doubleflat)
            {
                _accidentials -= 1;
            }
        }

        /// <summary>
        /// TODO: Must be implemented
        /// </summary>
        /// <returns></returns>
        public Note ChangeEnharmonically()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
