using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _forwardspeed = 5f;

     float _playerXValue = 0;

    private void Update()
    {
            transform.Translate((Input.GetAxis("Horizontal")-_playerXValue) * Time.deltaTime, 0, _forwardspeed * Time.deltaTime);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RightRotateObstacle")
        {
            Debug.Log("Rigt Enter");
            _playerXValue = collision.transform.rotation.z;
        }
        else if (collision.gameObject.tag == "LeftRotateObstacle")
        {
            Debug.Log("Left Enter");
            _playerXValue = collision.transform.rotation.z;
        }
        if (collision.gameObject.tag == "Ground")
        {
            _playerXValue = 0f;
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "RightRotateObstacle")
        {
            Debug.Log("Rigt Exit");
           
        }
        else if (collision.gameObject.tag == "LeftRotateObstacle")
        {
            Debug.Log("Left Exit");
           
        }
    }
}
