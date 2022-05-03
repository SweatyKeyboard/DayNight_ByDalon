using UnityEngine;
using Spine.Unity;

[System.Serializable]
public class PlayerAnimationModel
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

    public AnimationReferenceAsset Idle => _idle;
    public AnimationReferenceAsset Walk => _walk;
    public AnimationReferenceAsset Jump => _jump;
    public AnimationReferenceAsset Falling => _falling;
    public AnimationReferenceAsset Attack => _attack;
    public AnimationReferenceAsset AttackStanding => _attackStanding;
    public AnimationReferenceAsset Damage => _damage;
    public AnimationReferenceAsset Death => _death;

    public AllAnimations CurrentAnimation
    {
        get => _currentAnimation;
        set
        {
            PreviousAnimation = _currentAnimation;
            _currentAnimation = value;
        }
    }
    public AllAnimations PreviousAnimation
    {
        get => _previousAnimation;
        private set => _previousAnimation = value;
    }
}
