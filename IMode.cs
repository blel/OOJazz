using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz
{
    public interface IMode
    {
        List<BusinessLogic.IntervalType> ReorderIntervals(List<BusinessLogic.IntervalType> originalOrder);
    }
}
