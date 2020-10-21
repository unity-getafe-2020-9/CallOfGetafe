using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        //GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.blue);
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
}
