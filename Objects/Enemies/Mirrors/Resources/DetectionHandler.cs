using Godot;


[GlobalClass]
public partial class DetectionHandler : Area2D
{
    public bool watched = false;

    public void IsBeingWatched(Player watcher)
    {
        watched = true;
    }

    public void IsNotBeingWatched()
    {
        watched = false;
    }
}
