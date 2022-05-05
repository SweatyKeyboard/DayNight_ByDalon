using UnityEngine;
using Spine.Unity;

public class PlayerAnimationConrtoller : AnimationConrtoller<AnimationReferenceAsset>
{
    [SerializeField] private SkeletonAnimation animator;

    private void Start()
    {
        Init();
        model.CurrentAnimation = AllAnimations.Idle;
        SetAnimation(model.CurrentAnimation);
    }
    public override void SetAnimation(AllAnimations animation)
    {
        view.SetCharacterAnimation(animation);
    }
    protected override void Init()
    {
        view = new PlayerAnimationView(animator, model);
    }
}