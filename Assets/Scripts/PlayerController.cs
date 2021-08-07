using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _forwardspeed = 5f;
   [SerializeField]
    float _jumpSpeed = 5f;
    public float fx=10;


    bool _final = false;
    public float _playerXValue = 0;
    private float surtunme =1;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!_final) {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal")/surtunme-_playerXValue, 0, Input.GetAxis("Vertical")/surtunme);
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * _forwardspeed);
        }
    
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RightRotateObstacle")
        {
            Debug.Log("Rigt Enter");
            _playerXValue = -1f;
        }
        else if (collision.gameObject.tag == "LeftRotateObstacle")
        {
            Debug.Log("Left Enter");
            _playerXValue = 1f;
        }
         if (collision.gameObject.tag == "SlopeRoad")
        {
            
            surtunme =2;
        }
        if (collision.gameObject.tag == "Ground")
        {
            _playerXValue = 0f;
        }
        if(collision.gameObject.tag == "ObstaclePushing")
        {
    
            Vector3 direction = (transform.position - collision.transform.position).normalized;

            rb.AddForce(direction*fx);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Final")
        {
            Debug.Log("Finish");
            _final = true;
        }
        
       }
        private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag =="RightRotateObstacle" || collision.gameObject.tag== "LeftRotateObstacle" )
        {
            _playerXValue = 0f;
        }
        if (collision.gameObject.tag == "SlopeRoad")
            surtunme = 1;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * Time.deltaTime * _jumpSpeed/surtunme;
            Debug.Log("zıpla");
        }
    }
}
