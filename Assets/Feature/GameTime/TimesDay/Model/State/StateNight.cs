using GameTime.TimesDay.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.Model
{
    [CreateAssetMenu(menuName = "GameTime/Models/TimesDay/" + nameof(StateNight), fileName = nameof(StateNight))]
    internal class StateNight : AbstractStateTimesDay
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
