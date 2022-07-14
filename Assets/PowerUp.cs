using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        Destroy(gameObject);
    }
}
