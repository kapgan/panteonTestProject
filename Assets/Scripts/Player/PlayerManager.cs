using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    public Transform FinishTransform;

    [SerializeField] StartObjectPoints starObjectPoints;
    [SerializeField] float agentSpeed;
    [SerializeField] GameObject player;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard = new TMPro.TextMeshProUGUI[4];

    Vector3[] points;
    GameObject agent;
    GameObject[] agents = new GameObject[10];
    GameObject[] siralama = new GameObject[11];


    private void Start()
    {
        points = starObjectPoints.Points;
        agent = starObjectPoints.Agent;
        for (int i = 0; i < points.Length - 1; i++)
        {
            var a = Instantiate(agent, points[i], Quaternion.identity);
            a.GetComponent<AgentScript>().Agent.speed = agentSpeed;
            a.name = "Agent" + i;
            agents[i] = a;
            siralama[i] = agents[i];
        }
        siralama[10] = player;
    }
    private void FixedUpdate()
    {
        if (leadBoard[1].enabled)
            leadBoardDisp();
    }
    void leadBoardDisp()
    {
            GameObject tmp;
            for (int i = 0; i < siralama.Length - 1; i++)
            {
                for (int j = i; j < siralama.Length; j++)
                {
                    if (Vector3.Distance(siralama[i].transform.position, FinishTransform.position) > Vector3.Distance(siralama[j].transform.position, FinishTransform.position))
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
