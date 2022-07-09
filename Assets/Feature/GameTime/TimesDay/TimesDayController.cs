using GameTime.TimesDay.Abstract;

namespace GameTime.TimesDay
{
    internal class TimesDayController : AbstractTimeDayController
    {
        private StateMachine _stateMachine;

        private void Awake() => Init();
        private void Start() => _stateMachine.Initialize(model.StateDictionary[AllStateTimesDay.Morning]);

        public override AllStateTimesDay GetKeyTimeDay() => _stateMachine.CurrentState.KeyState;
        public override void ChangeTimeDay(int hour, int minute, int seconds)
        {
            var state = model.StateDictionary;

            if (hour >= state[AllStateTimesDay.Night].StartTimeState && hour < state[AllStateTimesDay.Night].StartTimeState + state[AllStateTimesDay.Night].DurationTimesDay)
                _stateMachine.ChangeState(state[AllStateTimesDay.Night]);
            else if (hour >= state[AllStateTimesDay.Morning].StartTimeState && hour < state[AllStateTimesDay.Morning].StartTimeState + state[AllStateTimesDay.Morning].DurationTimesDay)
                _stateMachine.ChangeState(state[AllStateTimesDay.Morning]);
            else if (hour >= state[AllStateTimesDay.Day].StartTimeState && hour < state[AllStateTimesDay.Day].StartTimeState + state[AllStateTimesDay.Day].DurationTimesDay)
                _stateMachine.ChangeState(state[AllStateTimesDay.Day]);
            else if (hour >= state[AllStateTimesDay.Evening].StartTimeState && hour < state[AllStateTimesDay.Evening].StartTimeState + state[AllStateTimesDay.Evening].DurationTimesDay)
                _stateMachine.ChangeState(state[AllStateTimesDay.Evening]);
        }
        private void ShowTimesDayView(AllStateTimesDay keyState) => view.ShowTimeDay(model.StateDictionary[keyState]);

        private void Init()
        {
            _stateMachine = new StateMachine();
            model.Init(_stateMachine);
            foreach (var timesDay in model.StateDictionary)
                timesDay.Value.onEnterTimeDay += ShowTimesDayView;
        }
        private void OnDestroy()
        {
            foreach (var timesDay in model.StateDictionary)
                timesDay.Value.onEnterTimeDay -= ShowTimesDayView;
        }
    }
}
