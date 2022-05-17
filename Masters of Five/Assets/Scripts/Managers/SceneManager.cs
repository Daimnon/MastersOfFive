using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public void MoveToLobby()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void MoveToDuel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
