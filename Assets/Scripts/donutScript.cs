using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutScript : MonoBehaviour
{
   
    public bool timer;
    public float time,t;
    public float x,x2,y=0.5f,y2=-0.5f;
    void Start()
    {
        timer = true;

    }

    void FixedUpdate()
    {

        UpdateDonutMovement();
    }
   void UpdateDonutMovement()
    {
        if (transform.position.x < x & time == 0)
            transform.position = transform.position + new Vector3(y, 0, 0) * Time.fixedDeltaTime;
        else
        {
            time += Time.fixedDeltaTime;
            if (time >= t)
            {
                if (transform.position.x > x2)
                {
                    transform.position = transform.position + new Vector3(y2, 0, 0) * Time.fixedDeltaTime;
                }
                else
                    time = 0;
            }
        }
    }
}
