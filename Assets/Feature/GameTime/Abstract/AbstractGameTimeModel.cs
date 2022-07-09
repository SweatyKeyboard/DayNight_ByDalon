using UnityEngine;
using GameTime.Other;

namespace GameTime.Abstract
{
    public abstract class AbstractGameTimeModel : ScriptableObject
    {        
        public abstract DataTime Time { get; }
        public abstract int StepGameSeconds { get; set; }
        public abstract float StepRealSeconds { get;}
    }
}
