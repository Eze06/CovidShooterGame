using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class targetMovement : MonoBehaviour
{

    private float lookRadius = 50f;
    private float movementSpeed = 0.3f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(target.position);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed);
        }

    }

    void onDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Player")
        {
            Destroy(gameObject);
        }
    }


}
