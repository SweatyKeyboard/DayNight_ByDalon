using GameTime.Other;
using UnityEngine;

namespace GameTime.Abstract
{
    internal abstract class AbstractGameTimeView : MonoBehaviour
    {
        public abstract void ShowTime(int hour, int minute, int seconds);
        public abstract void ShowDay(int day);
    }
}
