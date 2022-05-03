public abstract class AnimationView<T>
{
    
    public abstract void SetAnimation(T animation, bool loop);
    public abstract void AddAnimation(T animation, bool loop, int trackIndex = 1);
}
