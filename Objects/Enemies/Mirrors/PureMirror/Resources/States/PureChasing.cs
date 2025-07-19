using Godot;

public partial class PureChasing : State
{
    [ExportGroup("Refrences")]
    [Export]
    private DetectionHandler detectionHandler;
    [Export]
    private VelocityHandler velocityHandler;
    [Export]
    private NavigationHandler navigationHandler;
    [ExportGroup("MovementValues")]
    [Export]
    private float speed;

    private Player player;


    public override void PhysicsUpdate(double delta)
    {
        Enemy parentAsEnemy = parent as Enemy;
        Player player = parentAsEnemy.player;

        if ((detectionHandler is null) || (player is null) || (velocityHandler is null) || (navigationHandler is null))
        {
            return;
        }

        Vector2 velocity = navigationHandler.GetNextPathPosition();
        velocity = parent.ToLocal(velocity).Normalized();

        if (detectionHandler.watched)
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Watching");

            velocity = new Vector2(0, 0);
        }

        velocityHandler.SetVelocityX(velocity.X * speed);
        velocityHandler.SetVelocityY(velocity.Y * speed);
    }
}
