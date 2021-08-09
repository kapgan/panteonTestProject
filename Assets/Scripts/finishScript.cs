using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
    public class finishScript : MonoBehaviour
    {   [SerializeField] Camera cam;
    [SerializeField] GameObject draweblaWall;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Finish");
                other.gameObject.GetComponent<PlayerController>()._final = true;
              cam.depth += 1;
            draweblaWall.SetActive ( true);
        }

        }
    } 

