using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ralentizador : MonoBehaviour
{
    [SerializeField]
    private float slowWalkSpeed;
    private float walkSpeed;
    FirstPersonController fpc;
    // Start is called before the first frame update
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        walkSpeed = fpc.m_WalkSpeed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name== "Old_Bridge")
        {
            fpc.m_WalkSpeed = slowWalkSpeed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Old_Bridge")
        {
            fpc.m_WalkSpeed = walkSpeed;
        }
    }
}
