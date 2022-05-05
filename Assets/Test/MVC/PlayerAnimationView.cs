using Spine;
using Spine.Unity;
using UnityEngine;

public class PlayerAnimationView : AnimationView<AnimationReferenceAsset>
{
    private readonly SkeletonAnimation animator;
    private readonly AnimationModel<AnimationReferenceAsset> model;

    public PlayerAnimationView(SkeletonAnimation animator ,AnimationModel<AnimationReferenceAsset> model)
    {
        this.animator = animator;
        this.model = model;
    }

    public override void SetCharacterAnimation(AllAnimations animation)
    {
        switch (animation)
        {
            case AllAnimations.Idle:
                SetAnimation(model.Idle, true);
                break;
            case AllAnimations.Walk:
                SetAnimation(model.Walk, true);
                break;
            case AllAnimations.Jump:
                SetAnimation(model.Jump, false);
                break;
            case AllAnimations.Falling:
                SetAnimation(model.Falling, true);
                break;
            case AllAnimations.Attack:
                AddAnimation(model.Attack, false);
                return;
            case AllAnimations.AttackStanding:
                AddAnimation(model.AttackStanding, false);
                return;
            case AllAnimations.Damage:
                AddAnimation(model.Damage, false);
                return;
            case AllAnimations.Death:
                SetAnimation(model.Death, false);
                break;
            default:
                Debug.LogError("Нет такой анимации");
                break;
        }
        model.CurrentAnimation = animation;
    }
    protected override void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        if (animation.Animation == animator.state.GetCurrent(0).Animation) return;

        var animationEntry = animator.state.SetAnimation(0, animation, loop);

        animationEntry.Complete += AnimationEntry_Complete;
        animationEntry.TimeScale = 1f;
    }
    protected override void AddAnimation(AnimationReferenceAsset animation, bool loop, int trackIndex = 1)
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
