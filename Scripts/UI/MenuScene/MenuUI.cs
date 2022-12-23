using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : RepeatMonobehaviour
{
    [SerializeField] protected TMP_InputField inputField;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInputName();
    }

    private void LoadInputName()
    {
        if (this.inputField != null) return;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterGame()
    {
        if (this.inputField.text.Length > 0)
        {
            SaveLoad.instance.RequestAddPalyer(inputField.text, 0, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Update()
    {
        this.EnterGameWithEnterKey();
    }

    public void EnterGameWithEnterKey()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            this.EnterGame();
        }
    }

    public void PlaySoundUI()
    {
        //PlaySound
        Debug.Log("PlaySoundUI");
    }
}