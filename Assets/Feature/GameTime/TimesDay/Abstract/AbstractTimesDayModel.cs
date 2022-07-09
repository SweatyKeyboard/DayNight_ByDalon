using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.Abstract
{

    public abstract class AbstractTimesDayModel : ScriptableObject
    {
        public abstract Dictionary<AllStateTimesDay, AbstractStateTimesDay> StateDictionary { get; }

        internal abstract void Init(StateMachine stateMachine);
    }
}
