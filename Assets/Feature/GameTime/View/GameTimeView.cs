using GameTime.Abstract;
using GameTime.Other;
using UnityEngine;

namespace GameTime.Views
{
    internal class GameTimeView : AbstractGameTimeView
    {
        public override void ShowDay(int day)
        {
            Debug.Log($"Day-{day}");
        }

        public override void ShowTime(int hour, int minute, int seconds)
        {
            Debug.Log($"Time-{hour}:{minute}:{seconds}");
        }
    }
}
