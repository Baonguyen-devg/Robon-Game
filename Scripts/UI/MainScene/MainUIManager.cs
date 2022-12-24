using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    private float previousTimeScale = 1;
    public static bool gameIsPaused = false;
    public GameObject menuUI;
    public GameObject pauseUI;
    public GameObject hubUI;

    private void Update()
    {
        GetEscapeButton();
    }

    public void PlayGame()
    {
        this.hubUI.SetActive(true);
        GameManager.Instance.robonRespawn.RobonCompleteBox();
    }

    public void Replay()
    {
        GameManager.Instance.robonHealth.ReBorn();
        GameManager.Instance.robonRespawn.RobonCompleteBox();
    }

    private void GetEscapeButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) this.PauseGameUI();
    }

    public void ReloadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void PauseGameUI()
    {
        if (Time.timeScale > 0)
        {
            this.PauseGame();
        }else if (Time.timeScale == 0)
        {
            this.ResumeGame();
        }
    }

    public void PauseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        //Pause Audio
        gameIsPaused = true;
        this.pauseUI.SetActive(true);
    }
    
    
    public void ResumeGame()
    {
        Time.timeScale = previousTimeScale;
        //Active audio
        this.pauseUI.SetActive(false);
        gameIsPaused = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
