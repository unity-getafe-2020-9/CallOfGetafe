using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    private static int puntuacion = 0;
    private GameObject player;
    public enum Estado { Jugando, Pausado, Nightmare }
    private static Estado estado = Estado.Jugando;

    [SerializeField]
    private Text textoPausa;

    [SerializeField]
    private Text textoGameOver;

    [SerializeField]
    private GameObject panelMenu;

    public void HacerGameOver()
    {
        /*
         * - GameOver
                -> Paramos todo
                -> Mostramos GameOver
                -> Menú (Restart | Menú | Load)
        */
        DetenerJuego();
        textoGameOver.enabled = true;
        panelMenu.SetActive(true);
    }

    public static int GetPuntuacion()
    {
        return puntuacion;
    }
    public static void SetPuntuacion(int value)
    {
        puntuacion = value;
        GameObject.Find("TextPoints").GetComponent<Text>().text = puntuacion.ToString();
    }
    private void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estado == Estado.Jugando) {
                PausarJuego();
            } else if (estado == Estado.Pausado)
            {
                DespausarJuego();
            }
        }
    }
    public static void IncrementarPuntuacion(int puntos)
    {
        SetPuntuacion(GetPuntuacion() + puntos);
    }
    private void PausarJuego()
    {
        estado = Estado.Pausado;
        DetenerJuego();
        textoPausa.enabled = true;
    }

    private void DetenerJuego()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerManager>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;
    }

    private void DespausarJuego()
    {
        estado = Estado.Jugando;
        Time.timeScale = 1;
        player.GetComponent<PlayerManager>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        textoPausa.enabled = false;
    }

}
