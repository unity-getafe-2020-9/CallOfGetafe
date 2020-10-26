﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHUD : MonoBehaviour
{
    private static CanvasHUD _instance;
    private void Awake()
    {
        //Patrón Singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
