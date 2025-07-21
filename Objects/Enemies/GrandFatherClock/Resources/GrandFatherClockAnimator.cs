using Godot;

public partial class GrandFatherClockAnimator : AnimationPlayer
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
        if (velocityHandler.velocity.X < 0)
        {
            this.Play("MoveLeft");
        }
    }
}
