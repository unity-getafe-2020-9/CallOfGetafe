using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    Light torch;

    private void Awake()
    {
        torch.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            torch.enabled = !torch.enabled;
        }    
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            torch.intensity = torch.intensity + 1;
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            torch.intensity = torch.intensity - 1;
        }
    }
}
