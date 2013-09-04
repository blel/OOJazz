using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{

    public class Changes
    {
        #region ----Fields----

        private Note _root;

        private List<IntervalType> _chordtones;

        private List<IntervalType> _tensions;


        #endregion

        #region ----Properties----

        public string Name { get; set; }

        public IntervalType Third { get; set; }

        public IntervalType Fifth { get; set; }


        public List<IntervalType> ChordTones
        {
            get
            {
                return _chordtones;
            }

        }

        public List<IntervalType> Tensions
        {
            get
            {
                return _tensions;
            }

        }

        public Note Root
        {
            get
            {
                return _root;
            }
            set
            {
            }
        }
    
        public List<Scale> GetMatchingScales()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ----Constructors----

        public Changes(Note root, List<IntervalType> chordtones, List<IntervalType> tensions)
        {
            _root = root;
            _chordtones = chordtones;
            _tensions = tensions;

            var thirds = from cc in chordtones
                 where cc.MasterIntervalType == MasterIntervalType.Third
                 select cc;

            if (thirds.Count() > 1)
            {
                throw new Exception("The chord cannot have multiple thirds as chord tones!");
            }

            else
            {
                Third = thirds.FirstOrDefault();

                //todo: this is just a workaround. Should be some kind of null obj
                if (Third == null)
                {
                    Third = new Prime();
                }
            }


            var fifths = from cc in chordtones
                         where cc.MasterIntervalType == MasterIntervalType.Fifth
                         select cc;
            if (fifths.Count() > 1)
            {
                throw new Exception("The chord cannot have multiple fifths as chord tones)");
            }
            else
            {
                Fifth = fifths.FirstOrDefault();
            }

            //todo: this is just a workaround. Should be some kind of null obj
            if (Fifth == null)
            {
                Fifth = new Prime();
            }
            CreateSymbol();

        }

        public Changes(string notation)
        { }

        #endregion


        #region ----Methods----

        private void ParseSymbol()
        {
            throw new System.NotImplementedException();
        }

        private string CreateSymbol()
        {
            

            //get chord tones
            foreach (IntervalType intervalType in _chordtones)
            {
               intervalType.GetSymbol(this);
            }

            //get tensions
            foreach (IntervalType intervalType in _tensions)
            {
                intervalType.GetSymbol(this);
            }
            Name = _root.GetNotation() + Name;




            return Name;
        }

        #endregion


    }
}
