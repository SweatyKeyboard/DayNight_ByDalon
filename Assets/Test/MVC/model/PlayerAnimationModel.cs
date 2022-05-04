using UnityEngine;
using Spine.Unity;

[System.Serializable]
public class PlayerAnimationModel : AnimationModel<AnimationReferenceAsset>
{
    [Header("Spine Animations")]
    [SerializeField] private AnimationReferenceAsset _idle;
    [SerializeField] private AnimationReferenceAsset _walk;
    [SerializeField] private AnimationReferenceAsset _jump;
    [SerializeField] private AnimationReferenceAsset _falling;
    [SerializeField] private AnimationReferenceAsset _attack;
    [SerializeField] private AnimationReferenceAsset _attackStanding;
    [SerializeField] private AnimationReferenceAsset _damage;
    [SerializeField] private AnimationReferenceAsset _death;

    [Space]
    [SerializeField] private AllAnimations _currentAnimation = AllAnimations.Idle;
    [SerializeField] private AllAnimations _previousAnimation;

    public override AnimationReferenceAsset Idle => _idle;
    public override AnimationReferenceAsset Walk => _walk;
    public override AnimationReferenceAsset Jump => _jump;
    public override AnimationReferenceAsset Falling => _falling;
    public override AnimationReferenceAsset Attack => _attack;
    public override AnimationReferenceAsset AttackStanding => _attackStanding;
    public override AnimationReferenceAsset Damage => _damage;
    public override AnimationReferenceAsset Death => _death;

    public override AllAnimations CurrentAnimation
    {
        get => _currentAnimation;
        set
        {
            PreviousAnimation = _currentAnimation;
            _currentAnimation = value;
        }
    }
    public override AllAnimations PreviousAnimation
    {
        get => _previousAnimation;
        protected set => _previousAnimation = value;
    }
}
