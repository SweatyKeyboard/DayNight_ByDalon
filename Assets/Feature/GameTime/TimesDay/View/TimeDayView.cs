using GameTime.TimesDay.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.View
{
    internal class TimeDayView : AbstractTimesDayView
    {
        public override void ShowTimeDay(AbstractStateTimesDay timesDay)
        {
            Debug.Log($"TimesDay - {timesDay.KeyState}");
        }
    }
}
