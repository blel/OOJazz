using System;
namespace OOJazz.BusinessLogic
{
    public interface IDiatonicMode
    {
        System.Collections.Generic.List<StepType> ReorderSteps(System.Collections.Generic.List<StepType> originalOrder);
    }
}
