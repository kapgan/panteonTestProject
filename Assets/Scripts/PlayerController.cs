using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _forwardspeed = 5f;
    [SerializeField] float _rotateSpeed = 5f;
    [SerializeField] float _jumpSpeed = 5f;

    bool _final = false;
    private float _zPos = 0;
    public float _playerXValue = 0;

    [SerializeField] bool _isGrounded = true;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!_final) { 
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal")-_playerXValue, 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * _forwardspeed);
        }
        //rb.MovePosition(new Vector3((Input.GetAxis("Horizontal") - _playerXValue) * Time.deltaTime * _forwardspeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * _rotateSpeed));
        //  transform.Translate((Input.GetAxis("Horizontal")-_playerXValue) * Time.deltaTime*_forwardspeed, 0, Input.GetAxis("Vertical") * Time.deltaTime*_rotateSpeed);
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
         if (collision.gameObject.tag == "Ground")
        {
            _playerXValue = 0f;
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
        if (collision.gameObject.tag =="RightRotateObstacle" || collision.gameObject.tag== "LeftRotateObstacle"|| collision.gameObject.tag == "Ground")
        {
            _playerXValue = 0f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * Time.deltaTime * _jumpSpeed;
        }
    }
}
