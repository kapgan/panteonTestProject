using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformControl : MonoBehaviour
{
    [SerializeField] RotateObject _rotateValue;
    private void Update()
    {
        transform.Rotate(_rotateValue.rotateVector*Time.deltaTime);
      
    }
    


}
