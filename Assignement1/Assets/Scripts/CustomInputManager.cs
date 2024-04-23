using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager : MonoBehaviour
{
    public static CustomInputManager Instance { get; private set; }

    public CustomInputs customInputsBindings { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            SetupSingleton();
        }
    }

    private void SetupSingleton()
    {
        customInputsBindings = new CustomInputs();
        customInputsBindings.Enable();
    }
}
