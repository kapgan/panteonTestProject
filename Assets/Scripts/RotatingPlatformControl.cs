using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformControl : MonoBehaviour
{
    [SerializeField]  RotateObject _rotateValue;
  
    private void Update()
    {
 
        transform.Rotate(_rotateValue.rotateVector*Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody)
        {
            Vector3 direction = _rotateValue.rotateVector.z >= 0 ? new Vector3(-100,0,0) : new Vector3(100,0,0);
            collision.rigidbody.velocity=( (direction) * Time.deltaTime);
          
        }
    }


}
