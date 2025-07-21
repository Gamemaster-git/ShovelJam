using Godot;

public partial class State : Node
{
    [Signal]
    public delegate void TransitionedEventHandler(State state, StringName newStateName);


    public CharacterBody2D parent;


    public virtual void Enter() { }

    public virtual void Exit() { }

    // Triggered by respective built in godot functions within parent state machine.
    public virtual void InputUpdate(InputEvent input) { }

    public virtual void Update(double delta) { }

    public virtual void PhysicsUpdate(double delta) { }
}
