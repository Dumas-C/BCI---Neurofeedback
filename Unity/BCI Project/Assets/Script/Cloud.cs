using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;


public class Cloud : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;




    // Start is called before the first frame update
    void Start()
    {
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(calibrationmoyenne.phase);
    }
}
