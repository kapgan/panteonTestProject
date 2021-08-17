using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] Transform _finishTransform;
    [SerializeField] TMPro.TextMeshProUGUI[] leadBoard = new TMPro.TextMeshProUGUI[4];

    private GameObject[] ranking = new GameObject[11];
    private bool isStarted = false;
    private void Update()
    {
        if (isStarted)
        {
            leadBoardDisp();
        }
    }
    public void StartLeaderBoard(GameObject[] players)
    {
        isStarted = true;
        ranking = players;
    }
    void leadBoardDisp()
    {
        GameObject tmp;
        for (int i = 0; i < ranking.Length - 1; i++)
        {
            for (int j = i; j < ranking.Length; j++)
            {
                if (Vector3.Distance(ranking[i].transform.position, _finishTransform.position) > Vector3.Distance(ranking[j].transform.position, _finishTransform.position))
                {
                    tmp = ranking[j];
                    ranking[j] = ranking[i];
                    ranking[i] = tmp;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            leadBoard[i].text = (i + 1) + ". " + ranking[i].name;
        }

    }
}
