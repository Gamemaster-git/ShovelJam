using Godot;

using System.Collections.Generic;

[GlobalClass]
public partial class StateMachine : Node
{
    [ExportGroup("State")]
    [Export]
    private State initialState;
    [ExportGroup("Refrences")]
    [Export]
    private CharacterBody2D parent;

    public State currentState { get; set; }

    public Dictionary<StringName, State> states { get; set; } = new Dictionary<StringName, State>();


    public override void _Ready()
    {
        foreach (State child in GetChildren())
        {

            states.Add(child.Name, child);
            child.Transitioned += (State state, StringName newStateName) =>
            {
                OnStateTransition(state, newStateName);
            };
        }

        if (initialState is State)
        {
            initialState.parent = parent;
            initialState.Enter();
            currentState = initialState;
        }
    }

    public override void _Process(double delta)
    {
        if (currentState is State)
        {
            currentState.Update(delta);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (currentState is State)
        {
            currentState.PhysicsUpdate(delta);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (currentState is State)
        {
            currentState.InputUpdate(@event);
        }
    }


    private void OnStateTransition(State state, StringName newStateName)
    {

        if (state != currentState)
        {
            return;
        }

        State newState = states[newStateName];
        if (newState is null)
        {
            return;
        }

        if (currentState is State)
        {
            currentState.Exit();
        }

        newState.parent = parent;
        newState.Enter();

        currentState = newState;
    }
}
