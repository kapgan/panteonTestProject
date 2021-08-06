using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Concurrent;
public class GameStatus : MonoBehaviour
{
    [SerializeField] List<Transform> startPoint= new List<Transform>();
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            restart();
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            transform.position = startPoint[Random.Range(1, 11)].position;
        }

    }
}
