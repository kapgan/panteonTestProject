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
    [SerializeField] float dx=300;
    float _playerXValue, surtunme = 2;
    public List<Transform> startPoint = new List<Transform>();

    void Start()
    {
      
        ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        ajan.SetDestination(finish.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //ajan.SetDestination(finish.transform.position);

        
    }
    void ajanBaslat()
    {
        transform.position = startPoint[Random.Range(1, 11)].position;
        ajan.enabled = true;
        ajan.SetDestination(finish.transform.position);

    }
    void sayac(float saniye)
    {
        float t = 0;

        do
        {
            t += Time.deltaTime;

        }
        while (t < saniye);
            
        ajanBaslat();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "korkuluk")
        {
            //ajan.enabled = false;
            Debug.Log("Restart");
            //transform.position = startPoint.position;
            ajan.enabled = false;
            //transform.position = startPoint.position;
            sayac(1.5f);
        }
        if (collision.gameObject.tag == "SlopeRoad")
        {
            
            ajan.speed  /=surtunme ;
        }
        if (collision.gameObject.tag == "Ground")
        {
            _playerXValue = 0f;
            
        }
        if (collision.gameObject.tag == "ObstaclePushing")
        {

            //Vector3 direction = (transform.position - collision.transform.position).normalized;
            ajan.enabled = false;
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * dx);
            sayac(1.5f);
        }
       

    }
    private void OnCollisionStay(Collision collision)
    {
       
         if (collision.gameObject.tag == "RightRotateObstacle")
        {
         
            
           
           transform.position = (transform.position + new Vector3(1, 0, 0) *Time.deltaTime);
            
        }
        else if (collision.gameObject.tag == "LeftRotateObstacle")
        {
    
            
            transform.position=(transform.position + new Vector3(-1, 0, 0)*Time.deltaTime );
           
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
