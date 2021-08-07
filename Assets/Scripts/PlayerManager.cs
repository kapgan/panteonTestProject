using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] playerObject playerObject;

    public  List<Transform> startPoint = new List<Transform>();
    public Transform finish;
     float geriTepmeKatSayisi;
     float playerSpeed;
     float jumpPower;
    Vector3[] points;
    GameObject agent;
    private void Start()
    {
        points = playerObject._points;
        geriTepmeKatSayisi = playerObject._geriTepmeKatSayisi;
        playerSpeed = playerObject._playerSpeed;
        jumpPower = playerObject._jumpPower;
        agent = playerObject._agent;
        foreach(var point in points)
        {
            Debug.Log(point);
            var a=Instantiate(agent, point,Quaternion.identity);
           // a.transform.GetComponent<NavMeshAgent>().speed = 3.5f;
            //a.transform.GetComponent<NavMeshAgent>().SetDestination(finish.transform.position);
           
        }
    }
 
}
