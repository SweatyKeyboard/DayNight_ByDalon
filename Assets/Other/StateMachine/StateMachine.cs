public class StateMachine
{
    public State CurrentState { get; private set; }

    /// <summary>
    /// Запуск первого состояния 
    /// </summary>
    /// <param name="startingState"></param>
    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }
    /// <summary>
    /// Смена состояния 
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {
        if (CheckState(newState)) 
            return;
        CurrentState.Exit();      
        CurrentState = newState;
        newState.Enter();
    }
    /// <summary>
    /// Корректность нового состояния 
    /// </summary>
    /// <param name="newState"></param>
    /// <returns></returns>
    private bool CheckState(State newState)
    {    
        return  CurrentState == newState;       //CurrentState is DeathEnemyState ||
    }
}

