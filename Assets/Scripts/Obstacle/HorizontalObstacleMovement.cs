using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonGames
{
    public class HorizontalObstacleMovement : MonoBehaviour
    {
        [SerializeField] bool timer;
        [SerializeField] float time, interval;
        [SerializeField] float speed, forceSpeed;
        [SerializeField] RotateObject rotateValue;

        private Rigidbody _rb;

        void Start()
        {
            forceSpeed = speed;
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            transform.Rotate(rotateValue.rotateVector * Time.deltaTime);
            updateTimer();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
            {
                timer = true;
            }
        }
        void updateTimer()
        {
            _rb.velocity = Vector3.right * forceSpeed;
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
    }
}