﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ConfigGame()
    {
        Debug.LogWarning("FALTA POR IMPLEMENTAR");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
