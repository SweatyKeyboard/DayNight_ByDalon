using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float x;
    private float y;
    private bool attackButton;
    private bool jumpButton;
    private bool escButton;

    public float X
    {
        get => x;
        private set => x = value;
    }
    public float Y
    {
        get => y;
        private set => y = value;
    }
    public bool AttackButton
    {
        get => attackButton;
        private set => attackButton = value;
    }
    public bool JumpButton
    {
        get => jumpButton;
        private set => jumpButton = value;
    }
    public bool EscButton
    {
        get => escButton;
        private set => escButton = value;
    }
       
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        AttackButton = Input.GetButtonDown("Fire1");
        JumpButton = Input.GetButtonDown("Jump");
        EscButton = Input.GetKeyDown(KeyCode.Escape);
    }
}
