using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public GameObject canvas;

    public GameObject panelMenu;
    public GameObject panelOptions;
    public GameObject panelCredits;

    public GameManager gameManager;

    public void Start()
    {
        IniciarComponentes();
        canvas.SetActive(true);
        panelMenu.SetActive(true);
        panelOptions.SetActive(false);
        panelCredits.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
    }

    public void IniciarComponentes()
    {
        canvas = GameObject.Find("Canvas");
    }

    public void Iniciar()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
      
    }

    public void Options()
    { 
        panelMenu.SetActive(false);
        panelOptions.SetActive(true);
        panelCredits.SetActive(false);
    }

    public void Volver()
    {
        panelMenu.SetActive(true);
        panelOptions.SetActive(false);
        panelCredits.SetActive(false);
    }

    public void Credits()
    {
        panelMenu.SetActive(false);
        panelOptions.SetActive(false);
        panelCredits.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Resume()
    {
        gameManager.Resume();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
}

