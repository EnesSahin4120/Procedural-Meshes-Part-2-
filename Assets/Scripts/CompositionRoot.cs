using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private AnimationController characterAnimationController;
    private InputInfo inputInfo;

    private void Awake()
    {
        inputInfo = FindObjectOfType<InputInfo>();

        characterAnimationController.Init(inputInfo);
    }
}
