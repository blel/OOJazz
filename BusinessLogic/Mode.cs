using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class Mode
    {
        #region ----Fields----

        private int _degree;

        private string _name;
        
        #endregion

        #region ----Properties----

        public int Degree { get { return _degree; } set { _degree = value; } }

        public string Name { get { return _name; } set { _name = value; } }
        
        #endregion

        #region ----Constructors----

        public Mode(int degree, string name)
        {
            _degree = degree;
            _name = name;
        }

        #endregion

        #region ----Methods----

        #endregion
    }
}
