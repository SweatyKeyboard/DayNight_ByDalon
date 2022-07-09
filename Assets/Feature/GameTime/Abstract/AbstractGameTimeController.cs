using UnityEngine;

namespace GameTime.Abstract
{
    public abstract class AbstractGameTimeController : MonoBehaviour
    {
        [SerializeField] protected AbstractGameTimeModel model;
        [SerializeField] private protected AbstractGameTimeView view;
        
        protected abstract void SetPauseTime(bool isPause);

        protected abstract void ChangeTime(int day);
        protected abstract void ChangeTime(int hour, int minute, int seconds);
        protected abstract void ChangeTime(int hour, int minute, int seconds, int day);
       
    }
}