using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonGames
{
    public class RotatingPlatformControl : MonoBehaviour
    {
        [SerializeField] RotateObject rotateValue;
        [SerializeField] float x;
        private void Update()
        {
            transform.Rotate(rotateValue.rotateVector * Time.deltaTime);
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.rigidbody)
            {
                Vector3 direction = rotateValue.rotateVector.z >= 0 ? new Vector3(-x, 0, 0) : new Vector3(x,0, 0);
                 collision.rigidbody.velocity = ((direction) * Time.deltaTime);
            }
        }
    }
}