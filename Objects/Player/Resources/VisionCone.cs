using Godot;

public partial class VisionCone : PointLight2D
{
    enum LightSwitchState
    {
        ON,
        OFF
    }

    [ExportGroup("Refrences")]
    [Export]
    private CharacterBody2D parent;
    [Export]
    private StateMachine stateMachine;
    [Export]
    private PointLight2D glow;
    [ExportGroup("Energy")]
    [Export]
    private float visionConeEnergy = 2;
    [Export]
    private float glowEnergy = 5;
    [Export]
    private float fadeSpeed = 0.5f;
    [Export]
    private Tween.TransitionType fadeTransition;



    public override void _Process(double delta)
    {
        parent.LookAt(GetGlobalMousePosition());

        if (stateMachine.currentState.Name != "Moving")
        {
            LightHandler(LightSwitchState.OFF, this, fadeSpeed);
            LightHandler(LightSwitchState.ON, glow, fadeSpeed, glowEnergy);

            return;
        }


        LightHandler(LightSwitchState.OFF, glow, fadeSpeed);
        LightHandler(LightSwitchState.ON, this, fadeSpeed, visionConeEnergy);
    }


    private void LightHandler(LightSwitchState state, PointLight2D light, float time, float energy = 0f)
    {
        Tween energyTween = CreateTween();

        energyTween.SetTrans(fadeTransition);

        switch (state)
        {
            case LightSwitchState.ON:
                energyTween.TweenProperty(light, "energy", energy, time);
                break;

            case LightSwitchState.OFF:
                energyTween.TweenProperty(light, "energy", 0, time);
                break;

            default:
                break;
        }
    }
}
