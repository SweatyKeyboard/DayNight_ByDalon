using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Transform childCamera;

    private PlayerMovementView view;
    [SerializeField] private PlayerDataModel dataModel;
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerStateController playerStateController;

    #region Коллизия
    private LayerMask checkGroundLayerMask;
    private readonly float rayDistanceGround = 0.02f;

    /// <summary>
    /// Проверка колизии персонажа.
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public bool IsCollision(Vector2 vector)
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, vector, rayDistanceGround, checkGroundLayerMask);
        return hit.collider != null;
    }
    /// <summary>
    /// Проверка коллизии по направлению взгляда.
    /// </summary>
    /// <returns></returns>
    public bool IsCollisionWall() => IsCollision(dataModel.IsLeft ? Vector2.left : Vector2.right);
    #endregion

    public bool IsAlive => dataModel.Health > 0;
    public bool ControlEnabled => IsAlive;  // && !GameManager.IsPause;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerStateController = GetComponent<PlayerStateController>();
    }
    private void Start()
    {
        Init();
        checkGroundLayerMask = LayerMask.GetMask("Ground");
       childCamera = transform.GetChild(0);
    }
    private void Update()
    {
        Input();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    public void Input()
    {
        if (input.JumpButton)
            view.Jump(dataModel.JumpForce);

    }
    public void Movement()
    {
        view.ControlFallingSpeed(dataModel.FallingSpeed);

        if (!ControlEnabled) return;

        if (input.X > 0 && dataModel.IsLeft || input.X < 0 && !dataModel.IsLeft)
            dataModel.IsLeft = view.Flip(dataModel.IsLeft, childCamera);
        if (!Mathf.Approximately(input.X, 0)&&IsCollisionWall())
            view.Move(input.X, dataModel.Speed);
        
    }

    private void Init()
    {
        view = new PlayerMovementView(GetComponent<Rigidbody2D>(), transform);
    }

    void OnDrawGizmos()
    {
        if (!boxCollider2D)
            boxCollider2D = GetComponent<BoxCollider2D>();

        #region Gizmos Ground        
        if (IsCollision(Vector2.down)) Gizmos.color = Color.white;
        else Gizmos.color = Color.red;
        Gizmos.DrawRay(boxCollider2D.bounds.min, Vector2.down * rayDistanceGround);
        Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.max.x, boxCollider2D.bounds.min.y), Vector2.down * rayDistanceGround);
        Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.min.y - rayDistanceGround), Vector2.right * (boxCollider2D.bounds.extents.x * 2));
        #endregion

        #region Gizmos Wall
        if (IsCollisionWall()) Gizmos.color = Color.red;
        else Gizmos.color = Color.blue;
        if (dataModel.IsLeft)
        {
            Gizmos.DrawRay(boxCollider2D.bounds.min, Vector2.left * rayDistanceGround);
            Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.max.y), Vector2.left * rayDistanceGround);
            Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.min.x - rayDistanceGround, boxCollider2D.bounds.min.y), Vector2.up * (boxCollider2D.bounds.extents.y * 2));
        }
        else
        {
            Gizmos.DrawRay(boxCollider2D.bounds.max, Vector2.right * rayDistanceGround);
            Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.max.x, boxCollider2D.bounds.min.y), Vector2.right * rayDistanceGround);
            Gizmos.DrawRay(new Vector2(boxCollider2D.bounds.max.x + rayDistanceGround, boxCollider2D.bounds.min.y), Vector2.up * (boxCollider2D.bounds.extents.y * 2));
        }
        #endregion
    }
}
