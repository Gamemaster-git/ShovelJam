using Godot;

public partial class PlayerAnimator : AnimationPlayer
{
    [ExportGroup("Refrences")]
    [Export]
    private VelocityHandler velocityHandler;

    public override void _Process(double delta)
    {
        if (velocityHandler.velocity.X > 0)
        {
            this.Play("MoveRight");
        }
        else if (velocityHandler.velocity.X < 0)
        {
            this.Play("MoveLeft");
        }
        else if (velocityHandler.velocity.Y > 0)
        {
            this.Play("MoveBackward");
        }
        else if (velocityHandler.velocity.Y < 0)
        {
            this.Play("MoveForward");
        }
    }
}
