using UnityEngine;
using Spine.Unity;

public class PlayerAnimationConrtoller : AnimationConrtoller<AnimationReferenceAsset>
{
    [SerializeField] private SkeletonAnimation animator;

    private void Start()
    {
        Init();
        model.CurrentAnimation = AllAnimations.Idle;
        SetCharacterAnimation(model.CurrentAnimation);
    }

    protected override void SetCharacterAnimation(AllAnimations animation)
    {
        switch (animation)
        {
            case AllAnimations.Idle:
                view.SetAnimation(model.Idle, true);
                break;
            case AllAnimations.Walk:
                view.SetAnimation(model.Walk, true);
                break;
            case AllAnimations.Jump:
                view.SetAnimation(model.Jump, false);
                break;
            case AllAnimations.Falling:
                view.SetAnimation(model.Falling, true);
                break;
            case AllAnimations.Attack:
                view.AddAnimation(model.Attack, false);
                return;
            case AllAnimations.AttackStanding:
                view.AddAnimation(model.AttackStanding, false);
                return;
            case AllAnimations.Damage:
                view.AddAnimation(model.Damage, false);
                return;
            case AllAnimations.Death:
                view.SetAnimation(model.Death, false);
                break;
            default:
                Debug.LogError("Нет такой анимации");
                break;
        }
        model.CurrentAnimation = animation;
    }
    protected override void Init()
    {
        view = new PlayerAnimationView(animator);
    }
}