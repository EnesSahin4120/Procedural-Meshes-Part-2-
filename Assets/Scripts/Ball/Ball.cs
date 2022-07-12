using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(50,250)]
    public float throwingFactor; 

    [SerializeField] private AnimationController characterAnimationController;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        characterAnimationController.onIndicateBallMoving += Move;
    }

    private void OnDisable()
    {
        characterAnimationController.onIndicateBallMoving -= Move;
    }

    private void Move()
    {
        transform.SetParent(null);
        _rb.isKinematic = false;
        _rb.AddForce(throwingFactor * Vector3.forward, ForceMode.Impulse);
    }
}
