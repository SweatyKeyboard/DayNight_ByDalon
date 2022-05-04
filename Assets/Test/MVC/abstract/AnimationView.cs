public abstract class AnimationView<Animation>
{

    /// <summary>
    /// Замена анимации на 0й дорожке.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    public abstract void SetAnimation(Animation animation, bool loop);
    /// <summary>
    /// Добавление анимации на 1ю дорожку.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    public abstract void AddAnimation(Animation animation, bool loop, int trackIndex = 1);
}