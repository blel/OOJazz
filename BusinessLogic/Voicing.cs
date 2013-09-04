using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class Voicing
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

        public Voicing(string name, List<IntervalType> buildingIntervals)
        {
            _name = name;
            _buildingIntervals = buildingIntervals;
        }
        #endregion

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

        public List<List<Note>> GetMatchingChordNotes(Scale scale)
        {
            
            string originalMode = scale.CurrentMode;
            List<List<Note>> resultingChords = new List<List<Note>>();
            GetMatchingChordNotesHelper(resultingChords, scale);
            scale.CurrentMode = originalMode;
            return resultingChords;

            
        }

        private void GetMatchingChordNotesHelper(List<List<Note>> resultingChords, Scale scale)
        {
            List<Note> chordNotes = new List<Note>();

            bool IsMatching = true;
            foreach (IntervalType buildingInterval in BuildingIntervals)
            {
                IsMatching &= buildingInterval.IsIntervalMatchingScale(scale.GetIntervalsInCurrentMode(), 0);
            }

            //all intervals are matching, so return the chord Notes
            if (IsMatching)
            {
                chordNotes = GetNotes(scale.Notes.ElementAt(0));
                resultingChords.Add(chordNotes);
            }

            // check whether it works with the next scale mode
            if (scale.CurrentMode != scale.Modes.Last().Name)
            {
                scale.RollToNextMode();
                GetMatchingChordNotesHelper(resultingChords, scale);
            }
        }
    }
}
