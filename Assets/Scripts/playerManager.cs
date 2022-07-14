using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    #region Singleton

    public static playerManager instance;

    void awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;


}
