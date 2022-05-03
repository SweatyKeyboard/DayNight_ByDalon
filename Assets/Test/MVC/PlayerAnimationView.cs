using Spine;
using Spine.Unity;
public class PlayerAnimationView : AnimationView<AnimationReferenceAsset>
{
    private readonly SkeletonAnimation animator;

    public PlayerAnimationView(SkeletonAnimation animator)
    {
        this.animator = animator;
    }
    
    /// <summary>
    /// Замена анимации на 0й дорожке.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="timeScale"></param>
    /// <param name="trackIndex"></param>
    public override void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        if (animation.Animation == animator.state.GetCurrent(0).Animation) return;

        var animationEntry = animator.state.SetAnimation(0, animation, loop);

        animationEntry.Complete += AnimationEntry_Complete;
        animationEntry.TimeScale = 1f;
    }
    /// <summary>
    /// Добавление анимации на 1ю дорожку.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    /// <param name="delay"></param>
    public override void AddAnimation(AnimationReferenceAsset animation, bool loop, int trackIndex = 1)
    {
        if (animator.state.GetCurrent(trackIndex) != null) return;

        var animationEntry = animator.state.AddAnimation(trackIndex, animation, loop, 0);

        animationEntry.Complete += AnimationEntry_Complete;

    }
    /// <summary>
    /// По завершению проигрывания анимации.
    /// </summary>
    /// <param name="trackEntry"></param>
    private void AnimationEntry_Complete(TrackEntry trackEntry)
    {
        AnimationComplete();
    } 
    private void AnimationComplete()
    {
        //if (trackEntry.Animation == jump.Animation)
        //    SetCharacterAnimation(AllAnimations.Falling);
        //else if (trackEntry.Animation == attack.Animation || trackEntry.Animation == attackStanding.Animation || trackEntry.Animation == damage.Animation)
        //{
        //    skeletonAnimation.state.SetEmptyAnimation(1, 0);
        //}
    }

}
