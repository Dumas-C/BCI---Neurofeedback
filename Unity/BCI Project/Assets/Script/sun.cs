using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;

    Quaternion target_angle_40 = Quaternion.Euler(40, 0, 0);
    Quaternion target_angle_55 = Quaternion.Euler(55, 0, 0);
    Quaternion target_angle_70 = Quaternion.Euler(70, 0, 0);
    Quaternion target_angle_90 = Quaternion.Euler(90, 0, 0);
    Quaternion target_angle_110 = Quaternion.Euler(110, 0, 0);
    Quaternion target_angle_130 = Quaternion.Euler(130, 0, 0);
    Quaternion target_angle_160 = Quaternion.Euler(160, 0, 0);

    Quaternion current_angle;


    // Start is called before the first frame update
    void Start()
    {
        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();

        current_angle = target_angle_90;

    /* Transformation selon x uniquement :
      Phase 3 : 160
      Phase 2 : 130
      Phase 1 : 110
      Phase 0 : 90
     Phase -1 : 70
      Phase -2 : 55
      Phase -3 : 40
     */ 


    }

    // Update is called once per frame
    void Update()
    {
        
        if (calibrationmoyenne.phase == 3) 
        {
            current_angle = target_angle_160;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        
        if (calibrationmoyenne.phase == 2) 
        {
            current_angle = target_angle_130;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        if (calibrationmoyenne.phase == 1) 
        {
            current_angle = target_angle_110;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        if (calibrationmoyenne.phase == 0) 
        {
            current_angle = target_angle_90;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        if (calibrationmoyenne.phase == -1) 
        {
            current_angle = target_angle_70;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        if (calibrationmoyenne.phase == -2) 
        {
            current_angle = target_angle_55;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }

        if (calibrationmoyenne.phase == -3)
        {
            current_angle = target_angle_40;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current_angle, 0.05f);
        }
    }
}
