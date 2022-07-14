using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAppearance : MonoBehaviour
{

    public Transform text;
    public float lookRadius = 30f;
    public GameObject TextAppear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(text.position, transform.position);

        if (distance <= lookRadius)
        {
            TextAppear.SetActive(true);
        }
    }


    void onDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
