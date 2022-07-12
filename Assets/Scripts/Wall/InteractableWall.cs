using UnityEngine;
using System;

public class InteractableWall : MonoBehaviour, IInteractableWall
{
    public event Action<Ball, Vector3> onIndicateDeform;

    public void IndicateDeform(Ball _ball, Vector3 _contactPoint) 
    {
        if (onIndicateDeform != null)
            onIndicateDeform(_ball, _contactPoint);
    }
}
