using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class agentScript : MonoBehaviour
{
    [SerializeField] GameObject finish;
    Rigidbody rb;
    NavMeshAgent ajan;
    [SerializeField] float fx=300;
    Vector3 direction;
    float  surtunme = 2;
    public List<Transform> startPoint = new List<Transform>();
    void Start()
    {
      
        ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        ajan.SetDestination(finish.transform.position);
    }

  
    void ajanBaslat(bool sifirla)
    {
        if(sifirla==true)
        transform.position = startPoint[Random.Range(1, 11)].position;
        ajan.enabled = true;
        
        ajan.SetDestination(finish.transform.position);

    }
    void sayac(float saniye,bool sifirla)
    {
        float t = 0;

        do
        {
            t += Time.fixedDeltaTime;
          
        }
        while (t < saniye);
            if(t>=saniye)
        ajanBaslat(sifirla);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "korkuluk")
        {
      
            ajan.enabled = false;
       
            sayac(1.5f,true);
        }
        if (collision.gameObject.tag == "SlopeRoad")
        {
            
            ajan.speed  /=surtunme ;
        }
  
        if (collision.gameObject.tag == "ObstaclePushing")
        {

       
            ajan.enabled = false;
             direction = (transform.position - collision.transform.position).normalized;
     

        
            rb.AddForce(direction*fx);
            sayac(1.5f,false);
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
