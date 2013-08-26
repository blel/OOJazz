using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{

    public  class Step
    {
        #region ----Fields----
        private MasterNote _upper;
        
        private MasterNote _lower;

        private StepType _stepType;
        #endregion

        #region ----Properties----
        public MasterNote Upper
        {
            get
            {
                return _upper;
            }
            set
            {
                _upper = value;
            }
        }

        public MasterNote Lower
        {
            get
            {
                return _lower;
            }
            set
            {
                _lower = value;
            }
        }

        public StepType StepType
        {
            get { return _stepType; }

        }
        #endregion

        #region ----Constructors----
        public Step(StepType stepType)
        {
            _stepType = stepType;
        }
        #endregion
    }

}
