public abstract class AnimationView<Animation>
{

    /// <summary>
    /// ������ �������� �� 0� �������.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    public abstract void SetAnimation(Animation animation, bool loop);
    /// <summary>
    /// ���������� �������� �� 1� �������.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    public abstract void AddAnimation(Animation animation, bool loop, int trackIndex = 1);
}