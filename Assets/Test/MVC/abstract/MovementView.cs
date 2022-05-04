using UnityEngine;

public abstract class MovementView 
{
    
    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    /// <param name="x"></param>
    /// <param name="speed"></param>
    public abstract void Move(float x, float speed);
    /// <summary>
    /// Контроль максимальной скорости падения персонажа.
    /// </summary>
    /// <param name="fallingSpeed"></param>
    public abstract void ControlFallingSpeed(float fallingSpeed);
    /// <summary>
    /// Прыжок персонажа.
    /// </summary>
    /// <param name="force"></param>
    public abstract void Jump(float force);
    /// <summary>
    /// Поворот персонажа
    /// </summary>
    /// <param name="isLeft"></param>
    /// <param name="subTransform">Доп. поворот обекта.</param>
    /// <returns></returns>
    public abstract bool Flip(bool isLeft, Transform subTransform = null);
}
