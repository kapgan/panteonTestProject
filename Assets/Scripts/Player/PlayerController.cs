
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    #region Fields

    public float PlayerXPush = 0;
    public float PlayerMoveFriction = 1;

    [SerializeField] private float forwardspeed = 5f;
    [SerializeField] private float jumpSpeed = 2f;
    [SerializeField] private float rotationSpeed = 720;
    [SerializeField] private Animator _animator;

    private bool IsGrounded = true;
    private bool _finished = false;
    private Rigidbody _rb;



    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        FinishScript.PlayerGameFinished += GameFinish;
    }

    private void Update()
    {
        if (!_finished)
        {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") - PlayerXPush, 0, Input.GetAxis("Vertical"));
            m_Input.Normalize();
            transform.Translate(m_Input * forwardspeed * Time.deltaTime / PlayerMoveFriction, Space.World);

            if (m_Input != Vector3.zero)
            {
                _animator.SetBool("Running", true);
                Quaternion toRotation = Quaternion.LookRotation(m_Input, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                _animator.SetBool("Running", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                IsGrounded = false;
                _rb.AddForce(new Vector3(0, jumpSpeed / PlayerMoveFriction, 0), ForceMode.Impulse);
                _animator.SetTrigger("Jump");
            }
        }
    }
    public void GameFinish(bool t)
    {
        try
        {
            _animator.SetTrigger("Finish");
        }
        catch (System.Exception) { }
        _finished = t;
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
