using UnityEngine;

public interface IWallInteractor<T> where T : IInteractableWall
{
    public void Interact(T interactableWall, Vector3 contactPos);
}

public interface IInteractableWall
{
    public void IndicateDeform(Ball ball, Vector3 contactPos);    
}
