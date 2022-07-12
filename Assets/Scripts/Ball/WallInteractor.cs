using UnityEngine;

public class WallInteractor : MonoBehaviour, IWallInteractor<InteractableWall>
{
    private Ball ball;

    private void Awake()
    {
        ball = GetComponent<Ball>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.TryGetComponent(out InteractableWall interactableWall))
        {
            Vector3 posOfContact = other.contacts[0].point;
            Interact(interactableWall, posOfContact);
        }
    }

    public void Interact(InteractableWall _interactableWall, Vector3 _posOfContact) 
    {
        _interactableWall.IndicateDeform(ball, _posOfContact);
    }
}
