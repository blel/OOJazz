using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class StepAdapter
    {
        public StepAdapter()
        {
        }

        public IntervalType GetIntervalFromStep(StepType stepType)
        {
            if (stepType == StepType.HalfStep)
            {
                return new MinorSecond();
            }
            else
            {
                return new MajorSecond();
            }
        }

    }
}
