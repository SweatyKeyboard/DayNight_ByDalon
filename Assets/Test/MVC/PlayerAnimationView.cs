using Spine;
using Spine.Unity;
public class PlayerAnimationView : AnimationView<AnimationReferenceAsset>
{
    private readonly SkeletonAnimation animator;

    public PlayerAnimationView(SkeletonAnimation animator)
    {
        this.animator = animator;
    }
    
    public override void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        if (animation.Animation == animator.state.GetCurrent(0).Animation) return;

        var animationEntry = animator.state.SetAnimation(0, animation, loop);

        animationEntry.Complete += AnimationEntry_Complete;
        animationEntry.TimeScale = 1f;
    }
    public override void AddAnimation(AnimationReferenceAsset animation, bool loop, int trackIndex = 1)
    {
        if (animator.state.GetCurrent(trackIndex) != null) return;

        var animationEntry = animator.state.AddAnimation(trackIndex, animation, loop, 0);

        animationEntry.Complete += AnimationEntry_Complete;

    }
    /// <summary>
    /// ѕо завершению проигрывани€ анимации.
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
