using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _forwardspeed = 5f;
        [SerializeField]
        float _jumpSpeed = 5f;
      [SerializeField] float rotationSpeed=720;


        public bool _final = false;
        public float _playerXValue = 0;
        public float surtunme = 1;

        Rigidbody rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
      
        private void Update()
        {
            if (!_final)
            {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal")  - _playerXValue, 0, Input.GetAxis("Vertical"));
            m_Input.Normalize();

            // rb.MovePosition(transform.position + transform.TransformDirection(m_Input * Time.deltaTime * _forwardspeed));
            transform.Translate(m_Input * _forwardspeed * Time.deltaTime/surtunme, Space.World);

            if (m_Input != Vector3.zero)
            {
                //transform.forward = m_Input;
                Quaternion toRotation = Quaternion.LookRotation(m_Input, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
                
        }

    }



        private void OnCollisionStay(Collision collision)
        {
            if (Input.GetKey(KeyCode.Space))
            {
            rb.AddForce(new Vector3(0, _jumpSpeed/surtunme, 0), ForceMode.Impulse);
            //transform.velocity = Vector3.up * Time.deltaTime * _jumpSpeed;

        }
        }
    }
