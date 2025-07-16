using Godot;

[GlobalClass]
public partial class VelocityHandler : Node
{
    [ExportGroup("Refrences")]
    [Export]
    private CharacterBody2D parent;

    private Vector2 velocity { get; set; }


    public override void _PhysicsProcess(double delta)
    {
        if (parent is null)
        {
            return;
        }

        const int Multiplier = 100;

        float velocityMultiplier = Multiplier * (float)delta;

        Vector2 finalVelocity = new Vector2(velocityMultiplier * velocity.X, velocityMultiplier * velocity.Y);

        parent.Velocity = finalVelocity;

        parent.MoveAndSlide();
    }


    // Easily set the x and y of velocity individually.
    public void SetVelocityX(float x)
    {
        float velocityX = velocity.X;

        velocityX = x;

        velocity = new Vector2(velocityX, velocity.Y);
    }

    public void SetVelocityY(float y)
    {
        float velocityY = velocity.X;

        velocityY = y;

        velocity = new Vector2(velocity.X, velocityY);
    }
}
