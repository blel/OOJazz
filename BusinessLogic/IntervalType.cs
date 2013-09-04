using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    /// <summary>
    /// The abstract class for all Interval Types
    /// Method GetSymbol must be overwritten by subtypes
    /// </summary>
    public abstract class IntervalType
    {
        #region ----Fields----

        protected MasterIntervalType _masterIntervalType;

        protected int _halfStepCount;

        #endregion

        #region ----Properties----

        public MasterIntervalType MasterIntervalType
        {
            get
            {
                return _masterIntervalType;
            }
        }

        public int HalfStepCount
        {
            get
            {
                return _halfStepCount;
            }
        }

        #endregion

        #region ----Constructors----

        #endregion

        #region ----Methods----

        public abstract Changes GetSymbol(Changes chord);

        public bool IsIntervalMatchingScale(List<IntervalType> intervals, int shift)
        {
            //TODO: function overwritten.... to be redone....
            return false;

        }

        #endregion

    }

    /// <summary>
    /// Master Intervals
    /// The master intervals just contain the pure distance between two master notes
    /// no flatted or sharped intervals...
    /// </summary>
    public enum MasterIntervalType
    {
        Prime = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4,
        Sixth = 5,
        Seventh = 6
    }

    /// <summary>
    /// Interval Type Prime
    /// </summary>
    public class Prime : IntervalType
    {
        #region ----Constructors----

        public Prime()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Prime;
            _halfStepCount = 0;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            //prime does not make sense as chord note (see root) nor 
            //as extension
            return chord;
        }

        #endregion
    }

    /// <summary>
    /// Interval Type Minor Second
    /// </summary>
    public class MinorSecond : IntervalType
    {
        #region ----Constructors----

        public MinorSecond()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Second;
            _halfStepCount = 1;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            //Minor Second is not a chord note
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Minor Second does not make sense as chord note...");
            }

            //
            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                chord.Name += "b9";
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// Interval Type Major Second
    /// </summary>
    public class MajorSecond : IntervalType
    {
        #region ----Constructors----

        public MajorSecond()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Second;
            _halfStepCount = 2;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            //Minor Second is not a chord note
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Major Second does not make sense as chord note...");
            }

            //
            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //TODO: to be verified
                chord.Name += "9";
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The Minor Third Interval
    /// </summary>
    public class MinorThird : IntervalType
    {
        #region ----Constructors----

        public MinorThird()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Third;
            _halfStepCount = 3;
        }

        #endregion

        #region ----Methods----

        /// <summary>
        /// Overriden from base class.
        /// Adjusts chord symbol according to minor third
        /// </summary>
        /// <param name="chord"></param>
        /// <returns></returns>
        public override Changes GetSymbol(Changes chord)
        {
            //if ((from cc in chord.ChordTones
            //     where cc.GetType() == this.GetType()
            //     select cc).Count() > 0)
            //{
               
            //}

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                chord.Name += "#9";
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The Major Third Interval
    /// </summary>
    public class MajorThird : IntervalType
    {
        #region ----Constructor----

        public MajorThird()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Third;
            _halfStepCount = 4;
        }

        #endregion

        #region ----Methods----

        /// <summary>
        /// Overriden from base class.
        /// Adjusts chord symbol according to major third
        /// </summary>
        /// <param name="chord"></param>
        /// <returns></returns>
        public override Changes GetSymbol(Changes chord)
        {
            //if ((from cc in chord.ChordTones
            //     where cc.GetType() == this.GetType()
            //     select cc).Count() > 0)
            //{

            //    chord.Name = string.Empty;
            //}

            //Major Third shouldn't occur in tensions
            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Major Third is no tension");
            }

            return chord;
        }


        #endregion

    }

    /// <summary>
    /// The Interval Type for a perfect fourth
    /// </summary>
    public class PerfectFourth : IntervalType
    {
        #region ----Constructors----

        public PerfectFourth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fourth;
            _halfStepCount = 5;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //check if there are also thirds in chord notes
                //this is not allowed when having a perfect fourth
                if ((from cc in chord.ChordTones
                     where cc.GetType() == typeof(MinorThird) ||
                     cc.GetType() == typeof(MajorThird)
                     select cc).Count() > 0)
                {
                    throw new Exception("You cannot add thirds and fourths as chord notes.");
                }
                else
                {
                    chord.Name = "sus";
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //11
            }

            return chord;
        }

        #endregion

    }

    /// <summary>
    /// The Tritone Interval Type
    /// </summary>
    public class Tritone : IntervalType
    {
        #region ----Constructors----

        public Tritone()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fourth;
            _halfStepCount = 6;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {

                //The Tritone is not a chord interval
                throw new Exception("The tritone is not allowed as chord tone.");
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //#11
            }

            return chord;
        }

        #endregion

    }

    /// <summary>
    /// the Diminished Fifth Interval Type
    /// </summary>
    public class DiminishedFifth : IntervalType
    {
        #region ----Constructors----

        public DiminishedFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 6;
        }

        #endregion

        #region ----Methods-----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {

                //is allowed with minor third only
                if (chord.Third.GetType() != typeof(MinorThird))
                {
                    throw new Exception("Dinminished fifth is allowed only with minor thirds.");
                }
                else
                {
                    chord.Name = "dim";
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //b5
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The perfect fifth interval type
    /// </summary>
    public class PerfectFifth : IntervalType
    {
        #region ---Constructors----

        public PerfectFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 7;
        }

        #endregion

        #region ----Methods-----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {

                if (chord.Third.GetType() == typeof(MinorThird))
                {
                    chord.Name = "-";
                }
                else
                {
                    chord.Name = "";
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Perfect fifth is not allowed for extensions.");
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The augmented fifth interval type
    /// </summary>
    public class AugmentedFifth : IntervalType
    {
        #region ----Constructor----

        public AugmentedFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 8;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //+5 is not possible with minor third
                if (chord.Third.GetType() == typeof(MinorThird))
                {
                    throw new Exception("Aug 5th is not possible with minor third.");
                }
                else
                {
                    chord.Name = "aug";
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //is this allowed?;
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The minor sixth interval type
    /// </summary>
    public class MinorSixth : IntervalType
    {
        #region ----Constructors----

        public MinorSixth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Sixth;
            _halfStepCount = 8;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Minor 6 is not possible as chord note.");
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                chord.Name += "b13";
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The major sixth interval type
    /// </summary>
    public class MajorSixth : IntervalType
    {
        #region ----Constructors----

        public MajorSixth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Sixth;
            _halfStepCount = 9;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //minor 6 is not possible with minor third
                if (!(chord.Third.GetType() == typeof(MinorThird)) && chord.Fifth.GetType() == typeof(DiminishedFifth))
                {
                    throw new Exception("Major 6 is only possible with minor third and diminished fifth.");
                }
                else
                {
                    chord.Name = "°7";
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                //13;
            }

            return chord;
        }

        #endregion
    }

    /// <summary>
    /// The minor seventh interval type
    /// </summary>
    public class MinorSeventh : IntervalType
    {
        #region ----Constructors----

        public MinorSeventh()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Seventh;
            _halfStepCount = 10;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {

                if (chord.Third.GetType()==typeof(MinorThird) && chord.Fifth.GetType() == typeof(PerfectFifth))
                {
                    chord.Name = "min7";
                }
                else if (chord.Third.GetType() == typeof(MinorThird) && chord.Fifth.GetType() == typeof(DiminishedFifth))
                {
                    chord.Name = "min7b5";
                }
                else if (chord.Third.GetType() == typeof(MajorThird) && chord.Fifth.GetType() == typeof(PerfectFifth))
                {
                    chord.Name = "7";
                }
                else
                {
                    throw new Exception("min 7 error.");
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Min 7 is not possible as tension.");
            }

            return chord;
        }

        #endregion
    }


    /// <summary>
    /// The major seventh interval type
    /// </summary>
    public class MajorSeventh : IntervalType
    {
        #region ----Constructors----

        public MajorSeventh()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Seventh;
            _halfStepCount = 11;
        }

        #endregion

        #region ----Methods----

        public override Changes GetSymbol(Changes chord)
        {
            if ((from cc in chord.ChordTones
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {

                if (chord.Third.GetType() == typeof(MinorThird) && chord.Fifth.GetType() == typeof(PerfectFifth))
                {
                    chord.Name = "-Maj7";
                }
                else if (chord.Third.GetType() == typeof(MajorThird) && chord.Fifth.GetType() == typeof(PerfectFifth))
                {
                    chord.Name = "Maj7";
                }
                else
                {
                    throw new Exception("Maj 7 error.");
                }
            }

            if ((from cc in chord.Tensions
                 where cc.GetType() == this.GetType()
                 select cc).Count() > 0)
            {
                throw new Exception("Maj 7 is not possible as tension.");
            }

            return chord;
        }


        #endregion

    }

}

