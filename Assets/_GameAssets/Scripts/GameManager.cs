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
    public enum Estado { Jugando, Pausado, Nightmare, GameOver }
    private static Estado estado = Estado.Jugando;

    [SerializeField]
    private Text textoPausa;

    [SerializeField]
    private Text textoGameOver;

    [SerializeField]
    private GameObject panelMenu;

    public static bool hasKey = false;

    private static GameManager _instance;

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
    private void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estado == Estado.Jugando)
            {
                PausarJuego();
            }
            else if (estado == Estado.Pausado)
            {
                DespausarJuego();
            }
        }
    }

    public static void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void HacerGameOver()
    {
        print("Game over");
        //Cambiamos el estado
        estado = Estado.GameOver;
        
        //Poner el timescale a 0 y desactivar los scripts del player
        DetenerJuego();

        //Mostrar el texto del game over
        textoGameOver.enabled = true;

        //Activar el menú
        panelMenu.SetActive(true);
        
        //Desbloqueamos el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
