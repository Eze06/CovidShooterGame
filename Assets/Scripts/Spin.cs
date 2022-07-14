using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public Transform covidVaccine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        covidVaccine.Rotate(0f, 70f * Time.deltaTime, 0f);
        covidVaccine.Rotate(70f * Time.deltaTime, 0f, 0f);
        covidVaccine.Rotate(0f , 0f, 70f * Time.deltaTime);
    }
}
