using UnityEngine;

namespace GameTime.TimesDay.Abstract
{
    public abstract class AbstractTimeDayController : MonoBehaviour
    {
        [SerializeField] private protected AbstractTimesDayModel model;
        [SerializeField] private protected AbstractTimesDayView view;

        public abstract AllStateTimesDay GetKeyTimeDay();
        public abstract void ChangeTimeDay(int hour, int minute, int seconds);
    }
}
