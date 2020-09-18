using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using THOR;

public class thunder : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;

    THOR_Thunderstorm thor;

    // Start is called before the first frame update
    void Start()
    {
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();
        thor = GameObject.Find("THOR_Thunderstorm").GetComponent<THOR_Thunderstorm>();

        thor.probability = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { thor.probability = 0f; }

        if (calibrationmoyenne.phase == 2) { thor.probability = 0f; }

        if (calibrationmoyenne.phase == 1) { thor.probability = 0f; ; }

        if (calibrationmoyenne.phase == 0) { thor.probability = 0f; }

        if (calibrationmoyenne.phase == -1) { thor.probability = 0f; }

        if (calibrationmoyenne.phase == -2) { thor.probability = 0.5f; }

        if (calibrationmoyenne.phase == -3) { thor.probability = 1f; }
    }
}
