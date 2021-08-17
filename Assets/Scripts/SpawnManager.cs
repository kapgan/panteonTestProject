using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonGames
{
    public class SpawnManager : MonoBehaviour
    {
        
        [SerializeField] LeaderBoard leaderBoard;
        [SerializeField] StartObjectPoints starObjectPoints;
        [SerializeField] GameObject player;
        [SerializeField] Transform finish;
        private void Start()
        {
            GameObject[] ranking = new GameObject[11];
            Vector3[] points = starObjectPoints.Points;
            GameObject agent = starObjectPoints.Agent;
            for (int i = 0; i < points.Length - 1; i++)
            {
                var a = Instantiate(agent, points[i], Quaternion.identity);
                a.GetComponent<AgentScript>().Finish = finish.position;
                a.name = "Agent" + i;
                ranking[i] = a;
            }
            ranking[10] = player;
            leaderBoard.StartLeaderBoard(ranking);
        }
     
     
    }
}