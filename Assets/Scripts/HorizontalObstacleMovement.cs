using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
   Rigidbody rb;
    [SerializeField]float speed,forceSpeed;
    public bool timer;
    public float time, interval;
    void Start()
    {
        forceSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = Vector3.right * forceSpeed;
        if (timer)
        {
            time += Time.deltaTime;
            if (time > interval)
            { 
                if (forceSpeed > 0)
                {
                    forceSpeed = -speed;
                    timer = false;
                    time = 0;
                }
                else if (forceSpeed < 0)
                {
                    forceSpeed = speed;
                    timer = false;
                    time = 0;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "kenar" || collision.gameObject.tag=="Obstacle")
        {
            timer = true;
        }
    }
}
