using GameTime.TimesDay.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.Model
{
    [CreateAssetMenu(menuName = "GameTime/Models/TimesDay/" + nameof(StateMorning), fileName = nameof(StateMorning))]
    internal class StateMorning : AbstractStateTimesDay
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
