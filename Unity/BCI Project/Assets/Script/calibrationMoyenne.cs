using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;

public class calibrationMoyenne : MonoBehaviour
{
    private ExampleFloatInlet inlet;

    private List<float> calibrationList = new List<float>();
    private List<float> moyenneMouvante = new List<float>();

    private double averageCalibration;
    private double averageMoyenne = 0;

    private float timecountCalibration;
    private float timecountDiscovery;
    private float timecountSeconde;

    private float starttimeCalibration;
    private float starttimeDiscovery;
    private float starttimeSeconde;

    private float longueurList;
    private float valeurSupprime;

    private int compteur;
    public int phase;

    public float calibrationTime = 30.0f;
    public float discoveryTime = 10.0f;
    public float secondeTime = 5.0f;

    private int a = 0;

    public double pourcentage = 0.25;

    // Start is called before the first frame update
    void Start()
    {
        inlet = FindObjectOfType<ExampleFloatInlet>();

        starttimeCalibration = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timecountCalibration = Time.time - starttimeCalibration;
        if ((inlet.lastSample.Count() > 0) && (inlet.lastSample[0] > 0) && (timecountCalibration < calibrationTime))
        {
            calibrationList.Add(inlet.lastSample[0]);
        }

        if ((timecountCalibration > calibrationTime) && (a == 0))
        {
            averageCalibration = calibrationList.Average();
            //Debug.Log(averageCalibration);
            starttimeDiscovery = Time.time;
            a += 1;            
        }

        timecountDiscovery = Time.time - starttimeDiscovery;

        if ((inlet.lastSample.Count() > 0) && (inlet.lastSample[0] > 0) && (timecountDiscovery < discoveryTime))
        {
            moyenneMouvante.Add(inlet.lastSample[0]);
        }

        if ((timecountDiscovery > discoveryTime) && (a == 1))
        {
            averageMoyenne = moyenneMouvante.Average();
            a += 1;
            starttimeSeconde = Time.time;

        }

        timecountSeconde = Time.time - starttimeSeconde;

        if ((averageMoyenne != 0) && (timecountSeconde > secondeTime))
        {
            longueurList = moyenneMouvante.Count();
            valeurSupprime = (int)longueurList / 2;

            for (compteur = 0; compteur <= valeurSupprime; compteur++)
            {
                moyenneMouvante.RemoveAt(0);
                moyenneMouvante.Add(inlet.lastSample[0]);
            }

            averageMoyenne = moyenneMouvante.Average();
            //Debug.Log(averageMoyenne);

            if (averageMoyenne < (1 - 3 * pourcentage) * averageCalibration)
            {
                //Debug.Log("-75%");
                phase = -3;
            }

            if ((averageMoyenne >= (1 - 3 * pourcentage) * averageCalibration) && (averageMoyenne < (1 - 2 * pourcentage) * averageCalibration))
            {
                //Debug.Log("-50%");
                phase = -2;
            }

            if ((averageMoyenne >= (1 - 2 * pourcentage) * averageCalibration) && (averageMoyenne < (1 - pourcentage) * averageCalibration))
            {
                //Debug.Log("-25%");
                phase = -1;
            }

            if ((averageMoyenne >= (1 - pourcentage) * averageCalibration) && (averageMoyenne < (1 + pourcentage) * averageCalibration))
            {
                //Debug.Log("Entre les deux");
                phase = 0;
            }

            if ((averageMoyenne >= (1 + pourcentage) * averageCalibration) && (averageMoyenne < (1 + 2 * pourcentage) * averageCalibration))
            {
                //Debug.Log("+25%");
                phase = 1;
            }

            if ((averageMoyenne >= (1 + 2 * pourcentage) * averageCalibration) && (averageMoyenne < (1 + 3 * pourcentage) * averageCalibration))
            {
                //Debug.Log("+50%");
                phase = 2;
            }

            if ((averageMoyenne >= (1 + 3 * pourcentage) * averageCalibration))
            {
                //Debug.Log("+75%");
                phase = 3;
            }

            Debug.Log(phase);
            //Debug.Log(phase);
            starttimeSeconde = Time.time;
        }
    }
}
