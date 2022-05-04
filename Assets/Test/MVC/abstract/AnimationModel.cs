public abstract class AnimationModel<Animation>
{
    public abstract Animation Idle { get; }
    public abstract Animation Walk { get; }
    public abstract Animation Jump { get; }
    public abstract Animation Falling { get; }
    public abstract Animation Attack { get; }
    public abstract Animation AttackStanding { get; }
    public abstract Animation Damage { get; }
    public abstract Animation Death { get; }

    public abstract AllAnimations CurrentAnimation { get; set; }
    public abstract AllAnimations PreviousAnimation { get; protected set; }
}
