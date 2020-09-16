using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxRender : MonoBehaviour
{
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;
    public Material skybox6;
    public Material skybox7;

    calibrationMoyenne calibrationmoyenne;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skybox4;
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { RenderSettings.skybox = skybox1; }
        if (calibrationmoyenne.phase == 2) { RenderSettings.skybox = skybox2; }
        if (calibrationmoyenne.phase == 1) { RenderSettings.skybox = skybox3; }
        if (calibrationmoyenne.phase == 0) { RenderSettings.skybox = skybox4; }
        if (calibrationmoyenne.phase == -1) { RenderSettings.skybox = skybox5; }
        if (calibrationmoyenne.phase == -2) { RenderSettings.skybox = skybox6; }
        if (calibrationmoyenne.phase == -3) { RenderSettings.skybox = skybox7; }
    }
}
