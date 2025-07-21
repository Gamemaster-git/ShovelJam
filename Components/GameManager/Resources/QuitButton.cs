using Godot;

public partial class QuitButton : TextureButton
{
    public void OnPressed()
    {
        GetTree().Quit();
    }
}
