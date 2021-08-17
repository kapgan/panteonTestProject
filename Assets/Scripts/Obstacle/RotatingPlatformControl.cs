using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonGames
{
    public class RotatingPlatformControl : MonoBehaviour
    {
        [SerializeField] RotateObject rotateValue;

        private void Update()
        {
            transform.Rotate(rotateValue.rotateVector * Time.deltaTime);
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.rigidbody)
            {
                Vector3 direction = rotateValue.rotateVector.z >= 0 ? new Vector3(-rotateValue.rotateVector.z, 0, 0) : new Vector3(-rotateValue.rotateVector.z, 0, 0);
                 collision.rigidbody.velocity = ((direction*3) * Time.deltaTime);
            }
        }
    }
}