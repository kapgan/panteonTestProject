﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float _forwardspeed = 5f;
    [SerializeField]
    float _jumpSpeed = 2f;
    [SerializeField] float rotationSpeed = 720;

    Animator _animator;
    public bool _final = false;
    public float _playerXValue = 0;
    public float surtunme = 1;
    public bool _isGrounded = true;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
      
        if (!_final)
        {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") - _playerXValue, 0, Input.GetAxis("Vertical"));
            m_Input.Normalize();
            // rb.MovePosition(transform.position + transform.TransformDirection(m_Input * Time.deltaTime * _forwardspeed));
            transform.Translate(m_Input * _forwardspeed * Time.deltaTime / surtunme, Space.World);

            if (m_Input != Vector3.zero)
            {
                _animator.SetBool("Running", true);
                //transform.forward = m_Input;
                Quaternion toRotation = Quaternion.LookRotation(m_Input, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
                _animator.SetBool("Running", false);

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _isGrounded = false;
                rb.AddForce(new Vector3(0, _jumpSpeed / surtunme, 0),ForceMode.Impulse);
                _animator.SetTrigger("Jump");
                Debug.Log("jump");
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
     
    }

    private void OnCollisionStay(Collision collision)
    {
        
        _isGrounded = collision.gameObject.tag != "agent" ? true : false;
      
    }
}
