using Godot;

public partial class Idling : State
{
    public override void PhysicsUpdate(double delta)
    {
        // To prevent being in both the idling state and moving state almost simultaneously allowing the player to keep the vision cone on while standing still.
        if (Input.IsActionPressed("MoveForward") && Input.IsActionPressed("MoveBackward"))
        {
            return;
        }
        if (Input.IsActionPressed("MoveRight") && Input.IsActionPressed("MoveLeft"))
        {
            return;
        }

        if (Input.IsActionPressed("MoveForward"))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Moving");
        }
        if (Input.IsActionPressed("MoveBackward"))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Moving");
        }
        if (Input.IsActionPressed("MoveRight"))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Moving");
        }
        if (Input.IsActionPressed("MoveLeft"))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Moving");
        }
    }
}
