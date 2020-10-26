using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public string targetName;
    private Transform objetoASeguir;

    private void Awake()
    {
        objetoASeguir = GameObject.Find(targetName).transform;
    }

    void Update()
    {
        transform.position = new Vector3(objetoASeguir.position.x, transform.position.y, objetoASeguir.position.z);
    }
}
