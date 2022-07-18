using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float vidaActual;
    public float vidaMaxima;
    public float velocidadVida;
    public float healCooldown;

    public Image barraDeVida;

    public GameObject damagedImage;

    public Canvas ui;

    public GameObject panelPlay;
    public GameObject panelPause;
    public GameObject panelLoose;

    public GameManager gameManager;

    public void Start()
    {
        panelPlay.SetActive(true);
        panelPause.SetActive(false);
        panelLoose.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
    }

    //IEnumerator Curarse()
    //{
    //    yield return new WaitForSeconds(2f);
    //    vidaActual = vidaActual + (Time.deltaTime * velocidadVida);
    //    yield return new WaitForSeconds(10f);
    //}

    public void TomarDañoPlayer(float daño)
    {
        vidaActual -= daño;

        healCooldown = 5;

        StartCoroutine (ReceivingDamage());
    }

    private void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;

        healCooldown -= Time.deltaTime;

        if (healCooldown < 0)
        {
            vidaActual = vidaActual + (Time.deltaTime * velocidadVida);
        }

        if (healCooldown < -1)
        {
            healCooldown = -1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameManager.StopTime();

            panelPlay.SetActive(false);
            panelPause.SetActive(true);
            panelLoose.SetActive(false);
        }

        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }

        else if ((vidaActual <= vidaMaxima) && (vidaActual > 0) && (Time.timeScale == 1))
        {
            gameManager.Resume();

            panelPlay.SetActive(true);
            panelPause.SetActive(false);
            panelLoose.SetActive(false);
        }

        else if ((vidaActual <= 0) && (Time.timeScale == 1))
        {
            gameManager.StopTime();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            panelPlay.SetActive(false);
            panelPause.SetActive(false);
            panelLoose.SetActive(true);
        }
    }

    IEnumerator ReceivingDamage()
    {
        damagedImage.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        damagedImage.SetActive(false);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            print("BossDamages");
            TomarDañoPlayer(10);
        }
    }
}

