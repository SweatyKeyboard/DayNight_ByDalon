using UnityEngine;

public abstract class AnimationConrtoller<Animation> : MonoBehaviour
{
    [SerializeField] protected AnimationModel<Animation> model;
    protected AnimationView<Animation> view;

    /// <summary>
    /// Переключение анимации.
    /// </summary>
    /// <param name="animation"></param>
    protected abstract void SetCharacterAnimation(AllAnimations animation);
    protected abstract void Init();
}


