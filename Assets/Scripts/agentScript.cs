using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class agentScript : MonoBehaviour
{
   
    Rigidbody rb;
    NavMeshAgent ajan;
    public float fx=300;
    Vector3 direction,final=new Vector3(0,3,30);
    float  surtunme = 2;
    [SerializeField] playerObject playerObject;
    void Start()
    { 
        ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        ajan.SetDestination(final);

    }

    void devam()
    {
        ajan.enabled = true;
        ajan.SetDestination(final);
    }
    void yenile()
    {
        transform.position=playerObject._points[Random.Range(1,10)];
       
        ajan.enabled = true;
        ajan.SetDestination(final);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "korkuluk")
        {
          ajan.enabled = false;
            yenile();
        }
        if (collision.gameObject.tag == "SlopeRoad")
        {
            ajan.speed  /=surtunme ;
        }
  
        if (collision.gameObject.tag == "ObstaclePushing")
        {
            //ajan.enabled = false;
            direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * fx);
            // devam();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
       
         if (collision.gameObject.tag == "RightRotateObstacle")
        {
           transform.position = (transform.position + new Vector3(1.5f, 0, 0) *Time.deltaTime);
        }
        else if (collision.gameObject.tag == "LeftRotateObstacle")
        {
            transform.position=(transform.position + new Vector3(-1.5f, 0, 0)*Time.deltaTime );
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "SlopeRoad")
        {
           
            ajan.speed *= surtunme;
        }
    }
}
