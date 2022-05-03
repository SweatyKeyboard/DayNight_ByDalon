using UnityEngine;
using Spine.Unity;

[RequireComponent(typeof(SkeletonAnimation))]
public class PlayerAnimation : MonoBehaviour 
{
    private SkeletonAnimation skeletonAnimation;

    #region Spine Animations
    [Header("Spine Animations")]
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset walk;
    [SerializeField] private AnimationReferenceAsset jump;
    [SerializeField] private AnimationReferenceAsset falling;
    [SerializeField] private AnimationReferenceAsset attack;
    [SerializeField] private AnimationReferenceAsset attackStanding;
    [SerializeField] private AnimationReferenceAsset damage;
    [SerializeField] private AnimationReferenceAsset death;
    #endregion   

    [Space]
   [SerializeField] private AllAnimations currentAnimation;
    public AllAnimations CurrentAnimation 
    {
        get => currentAnimation; 
        private set=> currentAnimation=value;
    }

    private void Awake()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    private void Start()
    {
        CurrentAnimation = AllAnimations.Idle;
        SetCharacterAnimation(CurrentAnimation);
    }

    /// <summary>
    /// Замена анимации на 0й дорожке.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="timeScale"></param>
    /// <param name="trackIndex"></param>
    private void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale = 1f, int trackIndex = 0)
    {
        if (animation.Animation == skeletonAnimation.state.GetCurrent(trackIndex).Animation) return;

        var animationEntry = skeletonAnimation.state.SetAnimation(trackIndex, animation, loop);

        animationEntry.Complete += AnimationEntry_Complete;
        animationEntry.TimeScale = timeScale;
    }
    /// <summary>
    /// Добавление анимации на 1ю дорожку.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    /// <param name="delay"></param>
    private void AddAnimation(AnimationReferenceAsset animation,  bool loop, int trackIndex = 1, float delay = 0)
    {
        if (skeletonAnimation.state.GetCurrent(trackIndex) != null) return;

        var animationEntry = skeletonAnimation.state.AddAnimation(trackIndex, animation, loop, delay);

        animationEntry.Complete += AnimationEntry_Complete;

    }
    /// <summary>
    /// По завершению проигрывания анимации.
    /// </summary>
    /// <param name="trackEntry"></param>
    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.Animation == jump.Animation)
            SetCharacterAnimation(AllAnimations.Falling);        
        else if(trackEntry.Animation == attack.Animation || trackEntry.Animation == attackStanding.Animation || trackEntry.Animation == damage.Animation)
        {

            skeletonAnimation.state.SetEmptyAnimation(1, 0);
        }
    }
    /// <summary>
    /// Переключение анимации.
    /// </summary>
    /// <param name="animation"></param>
    public void SetCharacterAnimation(AllAnimations animation)
    {
        switch (animation)
        {
            case AllAnimations.Idle:
                SetAnimation(idle, true);
                break;
            case AllAnimations.Walk:
                SetAnimation(walk, true);
                break;
            case AllAnimations.Jump:
                SetAnimation(jump, false, 0.8f);
                break;
            case AllAnimations.Falling:
                SetAnimation(falling, true);
                break;
            case AllAnimations.Attack:
                AddAnimation(attack, false);
                return;
            case AllAnimations.AttackStanding:
                AddAnimation(attackStanding, false);
                return;
            case AllAnimations.Damage:
                AddAnimation(damage, false);
                return;
            case AllAnimations.Death:
                SetAnimation(death, false);
                break;
            default:
                Debug.LogError("Нет такой анимации");
                break;
        }
        CurrentAnimation = animation;
    }

}