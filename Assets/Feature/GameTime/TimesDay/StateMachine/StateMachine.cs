using GameTime.TimesDay.Abstract;

namespace GameTime.TimesDay
{
    internal class StateMachine
    {
        public AbstractStateTimesDay CurrentState { get; private set; }

        public void Initialize(AbstractStateTimesDay startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }
        public void ChangeState(AbstractStateTimesDay newState)
        {
            if (CurrentState == newState) return;

            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}
