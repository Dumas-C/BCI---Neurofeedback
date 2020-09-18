using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    calibrationMoyenne calibrationmoyenne;

    AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();

        calibrationmoyenne = GameObject.Find("Calibration").GetComponent<calibrationMoyenne>();

        m_MyAudioSource.mute = true; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrationmoyenne.phase == 3) { m_MyAudioSource.mute = false; }

        if (calibrationmoyenne.phase == 2) { m_MyAudioSource.mute = false; }

        if (calibrationmoyenne.phase == 1) { m_MyAudioSource.mute = false; }

        if (calibrationmoyenne.phase == 0) { m_MyAudioSource.mute = true; }

        if (calibrationmoyenne.phase == -1) { m_MyAudioSource.mute = true; }

        if (calibrationmoyenne.phase == -2) { m_MyAudioSource.mute = true; }

        if (calibrationmoyenne.phase == -3) { m_MyAudioSource.mute = true; }
    }
}
