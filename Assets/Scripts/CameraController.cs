using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float action_completeInSeconds;
    [SerializeField] private Transform lookAtWall_Transform;
    [SerializeField] private InteractableWall interactableWall;

    private void OnEnable()
    {
        interactableWall.onIndicateDeform += ChangeCameraView;
    }

    private void OnDisable()
    {
        interactableWall.onIndicateDeform -= ChangeCameraView;
    }

    private void ChangeCameraView(Ball targetBall, Vector3 targetContactPoint) 
    {
        StartCoroutine(Move_and_Look(lookAtWall_Transform, action_completeInSeconds));
    }

    //Sinusodial Ease In-Out Function
    public IEnumerator Move_and_Look(Transform _target, float completeInSeconds)
    {
        Vector3 start = transform.position;
        Vector3 startDir = transform.forward;
        Vector3 diff = _target.position - start;
        Vector3 diffDir = _target.forward - startDir;

        float t = 0f;
        while (t < completeInSeconds)
        {
            t += Time.deltaTime;
            transform.forward = -diffDir / 2f * (Mathf.Cos(Mathf.PI * t / completeInSeconds) - 1) + startDir;
            transform.position = -diff / 2f * (Mathf.Cos(Mathf.PI * t / completeInSeconds) - 1) + start;
            yield return null;
        }
        yield break;
    }
}
