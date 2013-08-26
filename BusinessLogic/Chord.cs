using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class Chord
    {
        #region ----Fields----
        private List<IntervalType> _buildingIntervals;

        private string _name;

        #endregion

        #region ----Properties----
        public List<IntervalType> BuildingIntervals
        {
            get
            {
                return _buildingIntervals;
            }

        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        #endregion

        #region ----Constructor----

        public Chord(string name, List<IntervalType> buildingIntervals)
        {
            _name = name;
            _buildingIntervals = buildingIntervals;
        }

        public List<IntervalType> GetInversions()
        {
            throw new NotImplementedException();
        }

        public List<Note> GetNotes(Note root)
        {
            List<Note> notes = new List<Note>();
            notes.Add(root);
            MasterNoteRow masterNoteRow = new MasterNoteRow();

            foreach (IntervalType interval in BuildingIntervals)
            {
                notes.Add(masterNoteRow.GetIntervalUp(notes.First(), interval).UpperNote);
            }

            return notes;
        }


        #endregion

    }
}
