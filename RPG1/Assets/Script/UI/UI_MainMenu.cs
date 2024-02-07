using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] string sceneName = "level_1";
    [SerializeField] GameObject continueButton;

    private void Start()
    {
        if (SaveManager.instance.HasSaveData()== false)
            continueButton.SetActive(false);
    }
    public void ContinueGame()
    {
         SceneManager.LoadScene(sceneName);
    }
    public void NewGame()
    {
        SaveManager.instance.DeleteSavedDate();
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("exit game");
    }
}
