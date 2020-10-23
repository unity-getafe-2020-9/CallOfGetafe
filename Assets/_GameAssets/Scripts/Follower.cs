using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform objetoASeguir;
    
    void Update()
    {
        transform.position = new Vector3(objetoASeguir.position.x, transform.position.y, objetoASeguir.position.z);
    }
}
