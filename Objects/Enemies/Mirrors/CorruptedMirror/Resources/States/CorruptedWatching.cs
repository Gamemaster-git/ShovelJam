using Godot;

public partial class CorruptedWatching : State
{
    [ExportGroup("Refrences")]
    [Export]
    private DetectionHandler detectionHandler;

    public override void PhysicsUpdate(double delta)
    {
        if ((detectionHandler is null))
        {
            return;
        }

        if (detectionHandler.watched)
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Chasing");
        }
    }
}
