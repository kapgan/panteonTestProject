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
            player.Final = true;
            player.Animator.SetBool("Finish", true);
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
            agent.Ajan.enabled = false;
            agent.Anim.SetBool("Finish", true);
        }
    }
}

