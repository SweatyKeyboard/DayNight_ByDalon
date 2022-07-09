using GameTime.TimesDay.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.Model
{
    [CreateAssetMenu(menuName = "GameTime/Models/TimesDay/" + nameof(StateDay), fileName = nameof(StateDay))]
    internal class StateDay : AbstractStateTimesDay
    {
        public override void Enter()
        {
            base.Enter();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
