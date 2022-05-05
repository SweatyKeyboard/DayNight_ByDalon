using UnityEngine;

public abstract class AnimationConrtoller<AnimationClip> : MonoBehaviour
{
    [SerializeField] protected AnimationModel<AnimationClip> model;
    protected AnimationView<AnimationClip> view;

    /// <summary>
    /// Переключение анимации.
    /// </summary>
    /// <param name="animation"></param>
    public abstract void SetAnimation(AllAnimations animation);
    protected abstract void Init();
}


