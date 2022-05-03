using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerStateController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private StateMachine stateMachine;

    public KeyPlayerState CurrentState;// для инспектора
    public KeyPlayerState PreviousState;
    public PlayerController PlayerController { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }
    public Dictionary<KeyPlayerState, PlayerState> AllPlayerStates { get; private set; } = new Dictionary<KeyPlayerState, PlayerState>();

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        PlayerAnimation = transform.GetChild(2).GetComponent<PlayerAnimation>();
        rb2D = GetComponent<Rigidbody2D>();

        InitStates();
    }
    private void Start()
    {
        stateMachine.Initialize(AllPlayerStates[KeyPlayerState.Idle]);
    }
    private void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
        SwitchingStates();
    }
    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();
    }

    protected virtual void SwitchingStates()
    {

        //if (Input.GetKey(KeyCode.Q))
        //    PlayerSpineAnimation.SetCharacterAnimation(PlayerSpineAnimation.AllAnimations.Attack);
        //if (Input.GetKey(KeyCode.W))
        //    PlayerSpineAnimation.SetCharacterAnimation(PlayerSpineAnimation.AllAnimations.AttackStanding);
        //if (Input.GetKeyDown(KeyCode.E))
        //    PlayerSpineAnimation.SetCharacterAnimation(PlayerSpineAnimation.AllAnimations.Walk);
        ////if (Input.GetKeyDown(KeyCode.R))
        //PlayerSpineAnimation.SetCharacterAnimation(PlayerSpineAnimation.AllAnimations.Idle);
        if (Input.GetKeyDown(KeyCode.Z))
            PlayerAnimation.SetCharacterAnimation(AllAnimations.Damage);


        if (PlayerController.ControlEnabled)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                stateMachine.ChangeState(AllPlayerStates[KeyPlayerState.Attack]);
            }
            if (Input.GetButtonDown("Jump") && PlayerController.IsCollision(Vector2.down))
            {
                stateMachine.ChangeState(AllPlayerStates[KeyPlayerState.Jump]);

            }
            
            if (rb2D.velocity.y == 0 && PlayerController.IsCollision(Vector2.down))
            {
                var move = Input.GetAxis("Horizontal");

                if (move == 0)
                    stateMachine.ChangeState(AllPlayerStates[KeyPlayerState.Idle]);
                else if (move != 0)
                {
                    stateMachine.ChangeState(AllPlayerStates[KeyPlayerState.Walk]);
                    PlayerAnimation.SetCharacterAnimation(AllAnimations.Walk); //dell

                }
            }
            else if (rb2D.velocity.y <= 0 && !PlayerController.IsCollision(Vector2.down)) //dell
            {
                PlayerAnimation.SetCharacterAnimation(AllAnimations.Falling);
                
            }
                
        }
    }
    public void Damage() // исправить
    { 
        PlayerAnimation.SetCharacterAnimation(AllAnimations.Damage);// исправить

    }
    public void Death() // исправить
    {
        PlayerAnimation.SetCharacterAnimation(AllAnimations.Death);// исправить

    }
    private void InitStates()
    {
        stateMachine = new StateMachine();
        
        #region States
        //AllPlayerStates.Add(KeyPlayerState.Idle, new IdlePlayerState(this, stateMachine));
        //AllPlayerStates.Add(KeyPlayerState.Walk, new WalkPlayerState(this, stateMachine));
        //AllPlayerStates.Add(KeyPlayerState.Jump, new JumpPlayerState(this, stateMachine));
        //AllPlayerStates.Add(KeyPlayerState.Attack, new AttackPlayerState(this, stateMachine));
        //AllPlayerStates.Add(KeyPlayerState.Death, new DeathPlayerState(this, stateMachine));
        #endregion
    }
}