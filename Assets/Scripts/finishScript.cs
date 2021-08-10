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
            var player = other.gameObject.GetComponent<PlayerController>();

            player._final = true;
            player._animator.SetBool("finish", true);
            cam.depth += 1;
            draweblaWall.SetActive(true);
            foreach (var item in leadBoard)
            {
                item.enabled = false;
            }



        }
        else if (other.gameObject.tag == "agent")
        {

            var agent = other.gameObject.GetComponent<agentScript>();
            agent.ajan.enabled = false;
            agent.anim.SetBool("finish", true);
        }
    }
}

