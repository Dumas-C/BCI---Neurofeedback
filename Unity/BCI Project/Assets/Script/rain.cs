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
        pluie.RainIntensity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { pluie.RainIntensity = 0f; }
        
        if (calibrationmoyenne.phase == 2) { pluie.RainIntensity = 0f; }
        
        if (calibrationmoyenne.phase == 1) { pluie.RainIntensity = 0f; }
        
        if (calibrationmoyenne.phase == 0) { pluie.RainIntensity = 0.5f; }
        
        if (calibrationmoyenne.phase == -1) { pluie.RainIntensity = 1f; }
        
        if (calibrationmoyenne.phase == -2) { pluie.RainIntensity = 1f; }
        
        if (calibrationmoyenne.phase == -3) { pluie.RainIntensity = 1f; }
    }
}
