using UnityEngine;

public class PlayerMovementView : MovementView
{
    protected readonly Rigidbody2D rb2D;
    protected readonly Transform transform;

    public PlayerMovementView(Rigidbody2D rb2D, Transform transform)
    {
        this.rb2D = rb2D;
        this.transform = transform;
    }

    public override void Move(float x, float speed)
    {
        rb2D.velocity = new Vector2(x * speed * Time.fixedDeltaTime, rb2D.velocity.y);
    }
    public override void ControlFallingSpeed(float fallingSpeed)
    {
        if (rb2D.velocity.y < fallingSpeed)
            rb2D.velocity = new Vector2(rb2D.velocity.x, fallingSpeed);
    }
    public override void Jump(float force)
    {
        rb2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    public override bool Flip(bool isLeft, Transform subTransform = null)
    {
        isLeft = !isLeft;
        transform.Rotate(0f, 180f, 0f);
        if (subTransform)
            subTransform.Rotate(0f, 180f, 0f);
        return isLeft;
    }
}
