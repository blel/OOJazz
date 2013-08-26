using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public abstract class IntervalType
    {
        protected MasterIntervalType _masterIntervalType;

        protected int _halfStepCount;

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
    }

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

    public class Prime : IntervalType
    {
        public Prime()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Prime;
            _halfStepCount = 0;
        }
    }

    public class MinorSecond : IntervalType
    {
        public MinorSecond()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Second;
            _halfStepCount = 1;
        }
    }

    public class MajorSecond : IntervalType
    {
        public MajorSecond()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Second;
            _halfStepCount = 2;
        }
    }

    public class MinorThird : IntervalType
    {
        public MinorThird()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Third;
            _halfStepCount = 3;
        }
    }

    public class MajorThird : IntervalType
    {
        public MajorThird()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Third;
            _halfStepCount = 4;
        }
    }

    public class PerfectFourth : IntervalType
    {
        public PerfectFourth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fourth;
            _halfStepCount = 5;
        }
    }

    public class Tritone : IntervalType
    {
        public Tritone()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fourth;
            _halfStepCount = 6;
        }
    }

    public class DiminishedFifth : IntervalType
    {
        public DiminishedFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 6;
        }
    }

    public class PerfectFifth : IntervalType
    {
        public PerfectFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 7;
        }
    }

    public class AugmentedFifth : IntervalType
    {
        public AugmentedFifth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Fifth;
            _halfStepCount = 8;
        }
    }

    public class MinorSixth : IntervalType
    {
        public MinorSixth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Sixth;
            _halfStepCount = 8;
        }
    }

    public class MajorSixth : IntervalType
    {
        public MajorSixth()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Sixth;
            _halfStepCount = 9;
        }
    }

    public class MinorSeventh : IntervalType
    {
        public MinorSeventh()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Seventh;
            _halfStepCount = 10;
        }
    }

    public class MajorSeventh : IntervalType
    {
        public MajorSeventh()
        {
            _masterIntervalType = BusinessLogic.MasterIntervalType.Seventh;
            _halfStepCount = 11;
        }
    }
  
}
