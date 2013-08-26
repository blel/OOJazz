using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class DiatonicMode : OOJazz.BusinessLogic.IDiatonicMode 
    {
        #region ----Fields----

        private DiatonicModeTypes _diatonicModeType;

        #endregion

        #region ----Properties----

        #endregion


        #region ----Constructors----

        public DiatonicMode(DiatonicModeTypes diatonicModeType)
        {
            _diatonicModeType = diatonicModeType;
        }

        #endregion

        #region ----Methods----

        public List<StepType> ReorderSteps(List<StepType> originalOrder)
        {
            int currentStep = (int)_diatonicModeType - 1;
            List<StepType> newOrder = new List<StepType>();

            for (int i = 1; i <= originalOrder.Count; i++)
            {
                newOrder.Add(originalOrder.ElementAt(currentStep));

                if (currentStep + i > originalOrder.Count)
                {
                    currentStep = 0;
                }
                else
                {
                    currentStep = currentStep + 1;
                }
            }
            return newOrder;
        }


        #endregion
    }
}
