using Godot;

public partial class VisionCone : PointLight2D
{
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
            LightHandler("Off", this, fadeSpeed);
            LightHandler("On", glow, fadeSpeed, glowEnergy);

            return;
        }


        LightHandler("Off", glow, fadeSpeed);
        LightHandler("On", this, fadeSpeed, visionConeEnergy);
    }


    private void LightHandler(StringName state, PointLight2D light, float time, float energy = 0f)
    {
        Tween energyTween = CreateTween();

        energyTween.SetTrans(fadeTransition);

        switch (state)
        {
            case "On":
                energyTween.TweenProperty(light, "energy", energy, time);
                break;

            case "Off":
                energyTween.TweenProperty(light, "energy", 0, time);
                break;

            default:
                GD.PrintErr("Invalid state property for LightHandler, must be either 'On' or 'Off'.");
                break;
        }
    }
}
