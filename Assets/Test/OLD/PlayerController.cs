using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
//[RequireComponent( typeof(ControlRespawnPlayer), typeof(Weapon))]
public class PlayerController : MonoBehaviour//, ITakeDamage
{
    public static PlayerController Instance { get; private set; }

    private Rigidbody2D rb2D;
    private BoxCollider2D boxCollider2D;
    private PlayerStateController playerStateController;
    private PlayerInput input;

    private bool isLeft;

    [SerializeField] private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;
    public bool IsAlive => PlayerData.Health > 0;
    public bool CanRespawn => PlayerData.ExHealth > 0;
    public bool ControlEnabled => IsAlive;//&& !GameManager.IsPause;

  // [SerializeField] private GameUI ui;    //убрать

    #region Check Ground And Wall 
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
    public bool IsCollisionWall() => IsCollision(isLeft ? Vector2.left : Vector2.right);
    #endregion

    private void Awake()
    {
        #region Singlton
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        #endregion

        rb2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        //respawnPlayerController = GetComponent<RespawnPlayerController>();
       // playerStateController = GetComponent<PlayerStateController>();       
    }
    private void Start()
    {
        checkGroundLayerMask = LayerMask.GetMask("Ground");
    }

    #region Movement   
    /// <summary>
    /// Перемещение персонажа.
    /// </summary>
    public void Move()
    {
        if (input.X != 0 && ControlEnabled)
        {
            if (input.X > 0 && isLeft || input.X < 0 && !isLeft)
                Flip();
            if (!IsCollisionWall())
                rb2D.velocity = new Vector2(input.X * PlayerData.Speed * Time.fixedDeltaTime, rb2D.velocity.y);
        }
        ControlFallingSpeed();
    }
    /// <summary>
    /// Контроль скорости падения персонажа.
    /// </summary>
    private void ControlFallingSpeed()
    {
        if (rb2D.velocity.y < PlayerData.FallingSpeed)
            rb2D.velocity = new Vector2(rb2D.velocity.x, PlayerData.FallingSpeed);
    }
    /// <summary>
    /// Прыжок персонажа.
    /// </summary>
    public void Jump()     //двойной прыжок на рассмотрении
    {
        rb2D.AddForce(Vector2.up * PlayerData.JumpForce, ForceMode2D.Impulse);
    }
    /// <summary>
    /// Поворот персонажа.
    /// </summary>
    private void Flip()
    {
        var childCam = transform.GetChild(0);

        isLeft = !isLeft;
        transform.Rotate(0f, 180f, 0f);
        childCam.Rotate(0f, 180f, 0f);
    }
    #endregion
    #region Damage   
    /// <summary>
    /// Получение урона персонажем.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        if (PlayerData.IsImmortal) return;

        playerStateController.Damage();  // исправить
        PlayerData.Health -= damage;
        if (PlayerData.Health <= 0)
        {
            playerStateController.Death();  // исправить
            StartCoroutine(TimerRespawn(2));
        }
        else 
            StartCoroutine(StartImmortal(PlayerData.ImmortalTime));
    }
    private IEnumerator TimerRespawn(float time)       //исправить 
    {
        PlayerData.IsImmortal = true;
        yield return new WaitForSeconds(time);
       // respawnPlayerController.Respawn();
        PlayerData.IsImmortal = false;
    }
    /// <summary>
    /// Временная неуязвимость.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartImmortal(float time)
    {
        var vectorForce = new Vector2(0, 0.6f);
        rb2D.AddForce(vectorForce * PlayerData.JumpForce / 2, ForceMode2D.Impulse);
        PlayerData.IsImmortal = true;
        yield return new WaitForSeconds(time);
        PlayerData.IsImmortal = false;
    }
    #endregion
    public void HealPlayer(bool fullHeal = false)
    {
        PlayerData.Health = fullHeal ? PlayerData.MaxHealth : ++PlayerData.Health;
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
        if (isLeft)
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
