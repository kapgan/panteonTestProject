using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonGames
{
    public class DonutScript : MonoBehaviour
    {
        [SerializeField] float time, t;
        [SerializeField] float x, x2, y = 0.5f, y2 = -0.5f;
        [SerializeField] float donutSpeed=1f;

        void FixedUpdate()
        {
            UpdateDonutMovement();
        }
        void UpdateDonutMovement()
        {
            if (transform.position.x < x & time == 0)
                transform.position = transform.position + new Vector3(y, 0, 0) * Time.fixedDeltaTime*donutSpeed;
            else
            {
                time += Time.fixedDeltaTime;
                if (time >= t)
                {
                    if (transform.position.x > x2)
                    {
                        transform.position = transform.position + new Vector3(y2, 0, 0) * Time.fixedDeltaTime * donutSpeed;
                    }
                    else
                        time = 0;
                }
            }
        }
    }
}