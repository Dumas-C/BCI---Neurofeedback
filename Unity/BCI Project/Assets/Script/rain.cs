using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class rain : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;
    RainScript pluie;
    // Start is called before the first frame update
    void Start()
    {
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();
        pluie = GameObject.Find("RainPrefab").GetComponent<RainScript>();
        pluie.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { pluie.enabled = false; }
        
        if (calibrationmoyenne.phase == 2) { pluie.enabled = false; }
        
        if (calibrationmoyenne.phase == 1) { pluie.enabled = false; }
        
        if (calibrationmoyenne.phase == 0) { pluie.enabled = true; }
        
        if (calibrationmoyenne.phase == -1) { pluie.enabled = true; }
        
        if (calibrationmoyenne.phase == -2) { pluie.enabled = true; }
        
        if (calibrationmoyenne.phase == -3) { pluie.enabled = true; }
    }
}
