public abstract class AnimationView<AnimationClip>
{

    /// <summary>
    /// Замена анимации на 0й дорожке.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    protected abstract void SetAnimation(AnimationClip animation, bool loop);
    /// <summary>
    /// Добавление анимации на 1ю дорожку.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    protected abstract void AddAnimation(AnimationClip animation, bool loop, int trackIndex = 1);
    /// <summary>
    /// Переключение анимации
    /// </summary>
    /// <param name="animation"></param>
    public abstract void SetCharacterAnimation(AllAnimations animation);
}