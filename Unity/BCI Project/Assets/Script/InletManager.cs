using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using LSL;
using Assets.LSL4Unity.Scripts.AbstractInlets;
namespace Assets.LSL4Unity.Scripts.Examples
{
    public class InletManager : MonoBehaviour
    {
        void Start()
        {
        }
        public void AStreamIsFound(LSLStreamInfoWrapper stream)
        {
            Debug.Log(string.Format("New LSL Stream {0} found for {1}", stream.Name, name));
            Debug.Log(string.Format("New stream has name {0} and type {1}", stream.Name, stream.Type));
        }
        public void AStreamGotLost(LSLStreamInfoWrapper stream)
        {
            Debug.Log(string.Format("LSL Stream {0} got lost for {1}", stream.Name, name));
            Debug.Log(string.Format("Lost stream had name {0} and type { 1}", stream.Name, stream.Type));
        }
    }
}