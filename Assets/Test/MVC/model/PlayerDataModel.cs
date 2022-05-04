using UnityEngine;

[System.Serializable]
public class PlayerDataModel : DataModel
{
    [Range(0, 5)] [SerializeField] private int _health = 5;
    [Range(1, 5)] [SerializeField] private int _maxHealth = 5;
    [Space]
    [Range(0, 3)] [SerializeField] private int _exHealth = 3;
    [Range(0, 3)] [SerializeField] private int _maxExHealth = 3;
    [Space]
    [SerializeField] private float _speed = 200f;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _modSpeed = 1f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _fallingSpeed = -6;
    [Space]
    [SerializeField] private float _immortalTime = 0.5f;
    [SerializeField] private bool _isImmortal = false;
    [SerializeField] private bool _isLeft;

    public override int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, MaxHealth);
    }
    public override int MaxHealth => _maxHealth = _maxHealth <= 0 ? 1 : _maxHealth;
    public override int ExHealth
    {
        get => _exHealth;
        set => _exHealth = Mathf.Clamp(value, 0, MaxExHealth);
    }
    public override int MaxExHealth => _maxExHealth = _maxExHealth < 0 ? 0 : _maxExHealth;
    public override float Speed => _speed;
    public override float CurrentSpeed => _currentSpeed = Speed * ModSpeed;
    public override float ModSpeed 
    {
        get => _modSpeed;
        set => _modSpeed = value;
    }
    public override float JumpForce => _jumpForce = _jumpForce < 0 ? 0 : _jumpForce;
    public override float FallingSpeed => _fallingSpeed = _fallingSpeed > 0 ? 0 : _fallingSpeed;
    public override float ImmortalTime => _immortalTime = _immortalTime < 0 ? 0 : _immortalTime;

    public override bool IsAlive => Health > 0;
    public override bool IsFullHealth => Health == MaxHealth;
    public override bool IsImmortal
    {
        get => _isImmortal;
        set => _isImmortal = value;
    }
    public override bool IsLeft
    {
        get => _isLeft;
        set => _isLeft = value;
    }

}
