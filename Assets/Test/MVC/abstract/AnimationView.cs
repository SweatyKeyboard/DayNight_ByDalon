public abstract class AnimationView<AnimationClip>
{

    /// <summary>
    /// ������ �������� �� 0� �������.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    protected abstract void SetAnimation(AnimationClip animation, bool loop);
    /// <summary>
    /// ���������� �������� �� 1� �������.
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="loop"></param>
    /// <param name="trackIndex"></param>
    protected abstract void AddAnimation(AnimationClip animation, bool loop, int trackIndex = 1);
    /// <summary>
    /// ������������ ��������
    /// </summary>
    /// <param name="animation"></param>
    public abstract void SetCharacterAnimation(AllAnimations animation);
}