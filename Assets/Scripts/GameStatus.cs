using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Concurrent;

public class GameStatus : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
       public void QuitGame()
    {
        Application.Quit();
    }

}  