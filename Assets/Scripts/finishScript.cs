using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject draweblaWall;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Finish");

            other.gameObject.GetComponent<PlayerController>()._final = true;
            cam.depth += 1;
            draweblaWall.SetActive(true);
            foreach (var item in leadBoard)
            {
                item.enabled = false;
            }

        }
        else if (other.gameObject.tag == "agent")
        {
            other.gameObject.GetComponent<agentScript>().ajan.enabled = false;
        }
    }
}

