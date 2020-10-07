using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    GameObject player;
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 vectorCanvasAlPlayer = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(vectorCanvasAlPlayer);
    }
}
