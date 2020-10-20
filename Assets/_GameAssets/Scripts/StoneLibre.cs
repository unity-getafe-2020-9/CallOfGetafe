using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLibre : MonoBehaviour
{
    public Color colorBase;
    public float speed;
    Renderer r;
    Material m;
    void Start()
    {
        r = GetComponent<Renderer>();
        m = r.material;
    }

    // Update is called once per frame
    void Update()
    {
        float r = colorBase.r;
        float g = colorBase.g;
        float b = colorBase.b;
        float d = Mathf.Abs(Mathf.Sin(Time.time * speed));
        Color c = new Color(r * d, g * d, b * d);
        m.SetColor("_Color", c);
    }
}
