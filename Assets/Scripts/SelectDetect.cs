using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class SelectDetect : MonoBehaviour {
    public XRSocketInteractor _SocketInteractor;
    public int DetectieNummer;
    public MeshRenderer _meshRenderer;
    private bool madeCopy;
    public bool inTrigger;
    public bool debugThis;
    public int DebugNummer;
    public int KernNummer;
    public bool testCopy;

    public int NeedThisHex;

    void Update()
    {
        if (inTrigger && !_meshRenderer.enabled && !madeCopy) {
            madeCopy = true;
            GameObject[] SpawnLocation;
            SpawnLocation = GameObject.FindGameObjectsWithTag("SpawnLocation");
            foreach(GameObject SpawnPoint in SpawnLocation) {
                if (SpawnPoint.GetComponent<SpawnHexInfo>().SpawnHexNummer == DetectieNummer) {
                    SpawnPoint.GetComponent<SpawnHexInfo>().spawnThisHex(NeedThisHex);
                }
            }           
        } else if (!inTrigger && _meshRenderer.enabled && madeCopy) {
            GameObject[] SpawnLocation;
            SpawnLocation = GameObject.FindGameObjectsWithTag("SpawnLocation");
            foreach (GameObject SpawnPoint in SpawnLocation) {
                if (SpawnPoint.GetComponent<SpawnHexInfo>().SpawnHexNummer == DetectieNummer) {
                    SpawnPoint.GetComponent<SpawnHexInfo>().DestroyHex();
                }
            }
            madeCopy = false;
            debugThis = false;
        }
        testCopy = madeCopy;

    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hexagon")) {
            inTrigger = true;
            FindObject(other);
        }


    }
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Hexagon")) {
            inTrigger = false;
            NeedThisHex = 0;

        }
    }

    public void FindObject(Collider other) {
        if (other.CompareTag("Hexagon")) {
            int ActiveHexaNummer = other.GetComponent<spawnInfo>().hexIndex;
            NeedThisHex = ActiveHexaNummer;
 
        }
    }
}
