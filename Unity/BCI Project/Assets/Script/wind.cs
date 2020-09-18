using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;
    WindZone vent;

    // Start is called before the first frame update
    void Start()
    {
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();
        vent = GameObject.Find("WindZone").GetComponent<WindZone>();
        vent.windTurbulence = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { vent.windTurbulence = 1f; }
        
        if (calibrationmoyenne.phase == 2) { vent.windTurbulence = 1.75f; }
        
        if (calibrationmoyenne.phase == 1) { vent.windTurbulence = 2.5f; }
        
        if (calibrationmoyenne.phase == 0) { vent.windTurbulence = 3f; }
        
        if (calibrationmoyenne.phase == -1) { vent.windTurbulence = 4f; }
        
        if (calibrationmoyenne.phase == -2) { vent.windTurbulence = 8f; }
        
        if (calibrationmoyenne.phase == -3) { vent.windTurbulence = 15f; }
    }
}
