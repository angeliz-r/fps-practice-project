using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;
    public GameObject pauseMenu;

    void Awake()
    {
        instance = this;
    }

    void Update() => CheckPause();


    void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
}
