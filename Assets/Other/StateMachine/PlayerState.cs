public abstract class PlayerState : State
{
    protected PlayerStateController stateController;

    //protected HashAnimationNamesPlayer animBase = new HashAnimationNamesPlayer();
  
    public KeyPlayerState SelectState { get; protected set; } = KeyPlayerState.Idle;

    protected PlayerState(PlayerStateController controller, StateMachine stateMachine) : base(stateMachine)
    {
        this.stateController = controller;
        this.stateMachine = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        stateController.CurrentState = SelectState;           //для проверки
    }
    public override void Exit()
    {
        base.Exit();
        stateController.PreviousState = SelectState;
    }
}
