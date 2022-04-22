using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenController : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneName);

    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    } 
    
    public void ToTitleScene()
    {
        GameController.instance.controlType = ControlType.Normal;
        SceneManager.LoadScene("Title");
    }

    public string GetsceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
