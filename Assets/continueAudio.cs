using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
