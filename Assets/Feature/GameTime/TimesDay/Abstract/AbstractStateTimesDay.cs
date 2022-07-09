using System;
using UnityEngine;

namespace GameTime.TimesDay.Abstract
{
    public abstract class AbstractStateTimesDay : ScriptableObject
    {
        [SerializeField] protected AllStateTimesDay keyState;
        [Space]
        [SerializeField] protected int startTimeState;
        [SerializeField] protected int defaultDurationTimesDay = 6;

        private protected StateMachine stateMachine;

        public AllStateTimesDay KeyState => keyState;
        public int StartTimeState => startTimeState;

        private int _defaultDurationTimesDay;
        public int DurationTimesDay
        {
            get => _defaultDurationTimesDay;
            set
            {
                _defaultDurationTimesDay = value;
            }
        }
        public event Action<AllStateTimesDay> onEnterTimeDay = delegate { };

        private void OnEnable()
        {
            _defaultDurationTimesDay = defaultDurationTimesDay;
        }

        public virtual void Enter()
        {
            onEnterTimeDay.Invoke(KeyState);
        }
        public virtual void LogicUpdate()
        {
        }
        public virtual void Exit()
        {
        }

        internal virtual void Init(StateMachine machine)
        {
            stateMachine = machine;
        }
        public virtual void ShowTimeView()
        {


        }
    }
}
