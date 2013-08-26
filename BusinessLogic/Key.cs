using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public class Key
    {
        #region ----Fields----
        
        private Note _root;

        private KeyMode _keyMode;

        #endregion

        #region ----Properties----
        public Note Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }

        public KeyMode KeyMode
        {
            get
            {
                return _keyMode;
            }
            set
            {
                _keyMode = value;
            }
        }

        #endregion

        #region ----Constructors----

        public Key(Note root, KeyMode keyMode)
        {
            _root = root;
            _keyMode = keyMode;
        }

        #endregion

    }
}
