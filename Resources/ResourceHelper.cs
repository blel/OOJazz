using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace OOJazz.Resources
{
    public static class ResourceHelper
    {
        /// <summary>
        /// Look up the resource file for a given accidential value and 
        /// return the notation 
        /// </summary>
        /// <param name="accidential"></param>
        /// <returns></returns>
        public static string GetAccidentialNotation(BusinessLogic.Accidentials accidential)
        {
            //get the resource file
            ResourceManager rm = new ResourceManager(typeof(Resources.OOJazzResources));

            //get all resources, cast it to a dictionaryentry and select the matching key
            string accidentialNotation = (from cc in
                                      rm.GetResourceSet(new System.Globalization.CultureInfo(1), true, true).Cast<System.Collections.DictionaryEntry>()
                                          where cc.Key.ToString() == Enum.GetName(typeof(BusinessLogic.Accidentials), accidential)
                                  select cc.Value.ToString()).FirstOrDefault();

            return accidentialNotation;
        }

    }
}
