using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    [Range(0, 5)] [SerializeField] private int _health = 5;
    [Range(1, 5)] [SerializeField] private int _maxHealth = 5;
    [Space]
    [Range(0, 3)] [SerializeField] private int _exHealth = 3;
    [Range(0, 3)] [SerializeField] private int _maxExHealth = 3;
    [Space]
    [SerializeField] private float _speed = 200f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _fallingSpeed = -6;
    [Space]
    [SerializeField] private float _immortalTime = 0.5f;
    [SerializeField] private bool _isImmortal = false;
    [SerializeField] private bool _isLeft;

    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, MaxHealth);
    }
    public int MaxHealth => _maxHealth = _maxHealth <= 0 ? 1 : _maxHealth;
    public int ExHealth
    {
        get => _exHealth;
        set => _exHealth = Mathf.Clamp(value, 0, MaxExHealth);
    }
    public int MaxExHealth => _maxExHealth = _maxExHealth < 0 ? 0 : _maxExHealth;
    public float Speed => _speed;
    public float JumpForce => _jumpForce = _jumpForce < 0 ? 0 : _jumpForce;
    public float FallingSpeed => _fallingSpeed = _fallingSpeed > 0 ? 0 : _fallingSpeed;
    public float ImmortalTime => _immortalTime = _immortalTime < 0 ? 0 : _immortalTime;

    public bool IsAlive => Health > 0;
    public bool IsFullHealth => Health == MaxHealth;
    public bool IsImmortal
    {
        get => _isImmortal;
        set => _isImmortal = value;
    }
    public bool IsLeft
    {
        get => _isLeft;
        set => _isLeft = value;
    }

}
