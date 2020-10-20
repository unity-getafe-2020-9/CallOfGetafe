using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    public Text textAmmo;
    public Text textChargers;
    public AudioClip acShoot;
    public AudioClip acReload;
    public AudioClip acStuck;
    [Tooltip("Tiempo de espera entre disparos en segundos")]
    public float cadency;//Tiempo entre disparos (segundos)
    public int maxAmmoByCharger;//Número de balas por cargador
    public int maxCharger;//Número de cargadores posibles
    public int ammos;//Número de balas en el cargador "activo"
    public int chargers;//Número de cargadores
    private AudioSource audioSource;//AudioSource del objeto "Arsenal"
    private bool isWaiting = false;//Determina si está esperando que pase el tiempo de cadencia

    private void Awake()
    {
        textAmmo = GameObject.Find("TextAmmo").GetComponent<Text>();
        textChargers = GameObject.Find("TextChargers").GetComponent<Text>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void AgregarCargadores(int nc)
    {
        chargers += nc;//chargers = chagers + nc;
        chargers = Mathf.Min(chargers, maxCharger);
        RefreshUI();
    }


    public void TryShoot()
    {
        if (CanShoot())
        {
            Shoot();
        } else
        {
            PlayStuckSound();
        }
    }

    public void Reload()
    {
        if (chargers > 0)
        {
            PlayReloadSound();
            ammos = maxAmmoByCharger;
            chargers--;
            RefreshUI();
        }
    }

    public virtual void Shoot() {
        isWaiting = true;
        Invoke("ReactivarArma", cadency);
        PlayShootSound();
        ammos--;
        RefreshUI();
}
    public bool CanShoot()
    {
        /*
        * ammos > 0 && cadencia (1 segundo entre disparos)
        */
        if (isWaiting==false && ammos > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(acShoot);
    }
    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(acReload);
    }

    public void PlayStuckSound()
    {
        audioSource.PlayOneShot(acStuck);
    }

    private void ReactivarArma()
    {
        isWaiting = false;
    }

    private void RefreshUI()
    {
        textAmmo.text = ammos.ToString();
        textChargers.text = chargers.ToString();
    }
}
