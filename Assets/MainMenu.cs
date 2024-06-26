using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int targetSceneIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

    public void ClickFunction()
    {
        Debug.Log("Button was clicked");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
