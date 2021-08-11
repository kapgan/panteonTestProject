using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float forwardspeed = 5f;
    [SerializeField]    
    float jumpSpeed = 2f;
    [SerializeField]
    float rotationSpeed = 720;

    public Animator Animator;
    public float PlayerXValue = 0;
    public float Friction = 1;
    public bool Final = false;
    public bool IsGrounded = true;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Final)
        {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") - PlayerXValue, 0, Input.GetAxis("Vertical"));
            m_Input.Normalize();
            transform.Translate(m_Input * forwardspeed * Time.deltaTime / Friction, Space.World);

            if (m_Input != Vector3.zero)
            {
                Animator.SetBool("Running", true);
                Quaternion toRotation = Quaternion.LookRotation(m_Input, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
                Animator.SetBool("Running", false);

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                IsGrounded = false;
                rb.AddForce(new Vector3(0, jumpSpeed / Friction, 0),ForceMode.Impulse);
                Animator.SetTrigger("Jump");
               
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
     
    }

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = collision.gameObject.tag != "Agent" ? true : false;
    }
}
