using Godot;

public abstract partial class Interactable : Area2D
{
    public enum PopUp
    {
        SHOW,
        HIDE,
    }

    public string Text;


    public virtual void Interaction() { }

    public static void InteractionPopUp(Control control, PopUp popUp)
    {
        Tween opacityTween = control.CreateTween();


        switch (popUp)
        {
            case PopUp.SHOW:
                opacityTween.TweenProperty(control, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
                break;
            case PopUp.HIDE:
                opacityTween.TweenProperty(control, "modulate:a", 0, Global.UserInterfaceAnimationSpeed);
                break;

            default:
                break;
        }
    }
}
