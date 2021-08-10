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
            restart();
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelMenu()
    {

    }
}
