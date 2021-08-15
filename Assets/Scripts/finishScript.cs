using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard;
    [SerializeField] GameObject panel;


    public static event Action<bool> PlayerGameFinished;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerGameFinished?.Invoke(true);
            cam.depth += 1;
           // other.GetComponent<PlayerController>()._animator.SetBool("Finish", true);
            foreach (var item in leadBoard)
            {
                item.enabled = false;
            }
            panel.GetComponent<MenuScript>().Paint = true;
            panel.SetActive(true);
        }
        else if (other.gameObject.tag == "Agent")
        {
            var agent = other.gameObject.GetComponent<AgentScript>();
            agent.Agent.enabled = false;
            agent.Anim.SetBool("Finish", true);
        }
    }
}

