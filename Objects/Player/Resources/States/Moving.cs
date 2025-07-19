using Godot;

public partial class Moving : State
{
    [ExportGroup("Movement")]
    [Export]
    public float speed;
    [ExportGroup("Refrences")]
    [Export]
    public VelocityHandler velocityHandler;


    public override void PhysicsUpdate(double delta)
    {
        if (velocityHandler is null)
        {
            return;
        }

        Vector2 inputDirection = new Vector2();
        inputDirection = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");

        if (inputDirection == new Vector2(0, 0))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Idling");
        }

        velocityHandler.SetVelocityX(inputDirection.X * speed);
        velocityHandler.SetVelocityY(inputDirection.Y * speed);
    }
}
