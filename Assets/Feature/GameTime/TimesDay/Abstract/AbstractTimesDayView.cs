using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime.TimesDay.Abstract
{
    public abstract class AbstractTimesDayView : MonoBehaviour
    {
        public abstract void ShowTimeDay(AbstractStateTimesDay timesDay);
    }
}
