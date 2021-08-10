using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerObject playerObject;
    public Transform finish;
    [SerializeField] float agentSpeed;

    Vector3[] points;
    GameObject agent;

    [SerializeField] GameObject player;

    GameObject[] agents = new GameObject[10];
    GameObject[] siralama = new GameObject[11];

    float distance;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard = new TMPro.TextMeshProUGUI[4];
    private void Start()
    {
        points = playerObject._points;
        agent = playerObject._agent;
        for (int i = 0; i < points.Length - 1; i++)
        {
            var a = Instantiate(agent, points[i], Quaternion.identity);
            a.GetComponent<AgentScript>().ajan.speed = agentSpeed;
            a.name = "Agent" + i;
            agents[i] = a;
            siralama[i] = agents[i];
        }
        siralama[10] = player;
    }
    private void FixedUpdate()
    {
        leadBoardDisp();
    }
    void leadBoardDisp()
    {
        if (leadBoard[1].enabled)
        {
            GameObject tmp;
            for (int i = 0; i < siralama.Length - 1; i++)
            {
                for (int j = i; j < siralama.Length; j++)
                {
                    if (Vector3.Distance(siralama[i].transform.position, finish.position) > Vector3.Distance(siralama[j].transform.position, finish.position))
                    {
                        tmp = siralama[j];
                        siralama[j] = siralama[i];
                        siralama[i] = tmp;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                leadBoard[i].text = (i + 1) + ". " + siralama[i].name;
            }
        }
    }
}
