public abstract class DataModel 
{
    public abstract int Health { get; set; }
    public abstract int MaxHealth { get;  }
    public abstract int ExHealth { get; set; }
    public abstract int MaxExHealth { get; }

    public abstract float Speed { get; }
    public abstract float CurrentSpeed { get;}
    public abstract float ModSpeed { get; set; }

    public abstract float JumpForce { get; }
    public abstract float FallingSpeed { get;  }
    public abstract float ImmortalTime { get;  }

    public abstract bool IsAlive { get; }
    public abstract bool IsFullHealth { get; }
    public abstract bool IsImmortal { get; set; }
    public abstract bool IsLeft { get; set; }
}
