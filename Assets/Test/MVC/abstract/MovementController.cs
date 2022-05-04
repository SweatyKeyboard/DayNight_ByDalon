
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    protected MovementView view;
    [SerializeField] protected DataModel model;
    [SerializeField] protected PlayerInput input;

    protected abstract void Input();
    protected abstract void Movement();
    protected abstract void Init();
}
