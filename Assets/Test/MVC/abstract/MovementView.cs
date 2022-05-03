using UnityEngine;

public abstract class MovementView 
{
    protected readonly Rigidbody2D rb2D;
    protected readonly Transform transform;

    protected MovementView(Rigidbody2D rb2D, Transform transform)
    {
        this.rb2D = rb2D;
        this.transform = transform;
    }

    /// <summary>
    /// ������������ ���������
    /// </summary>
    /// <param name="x"></param>
    /// <param name="speed"></param>
    public abstract void Move(float x, float speed);
    /// <summary>
    /// �������� ������������ �������� ������� ���������.
    /// </summary>
    /// <param name="fallingSpeed"></param>
    public abstract void ControlFallingSpeed(float fallingSpeed);
    /// <summary>
    /// ������ ���������.
    /// </summary>
    /// <param name="force"></param>
    public abstract void Jump(float force);
    /// <summary>
    /// ������� ���������
    /// </summary>
    /// <param name="isLeft"></param>
    /// <param name="subTransform">���. ������� ������.</param>
    /// <returns></returns>
    public abstract bool Flip(bool isLeft, Transform subTransform = null);
}
