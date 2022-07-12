using UnityEngine;
using System;

public class InputInfo : MonoBehaviour
{
    public event Action onPressDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Press();
    }

    public void Press()
    {
        if (onPressDown != null)
            onPressDown();
    }
}