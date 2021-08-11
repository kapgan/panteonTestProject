using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject draweblaWall;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard;
    [SerializeField] GameObject panel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            player._final = true;
            player._animator.SetBool("Finish", true);
            cam.depth += 1;
            draweblaWall.SetActive(true);
            foreach (var item in leadBoard)
            {
                item.enabled = false;
            }
            panel.SetActive(true);
        }
        else if (other.gameObject.tag == "Agent")
        {
            var agent = other.gameObject.GetComponent<AgentScript>();
            agent.ajan.enabled = false;
            agent.anim.SetBool("Finish", true);
        }
    }
}

