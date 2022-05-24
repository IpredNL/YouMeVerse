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
   // private int DesignNummer;
    //private int MethodeNummer;
    //private bool ActiveKern;
    //private bool ActiveDesign;
    //private bool ActiveMethode;
    public bool testCopy;

    public int NeedThisHex;

    // Start is called before the first frame update


    // Update is called once per frame
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
                /*if (SpawnPoint.GetComponent<SpawnHexInfo>().SpawnHexNummer == DetectieNummer)
                    if (SpawnPoint.GetComponent<SpawnHexInfo>().SpawnHexNummer == DetectieNummer) {
                    if (ActiveKern) {               // Kernwaarde
                        SpawnPoint.GetComponent<SpawnHexInfo>().spawnNewKernHex(KernNummer);
                    } else if (ActiveDesign) {      //Design thinking methode
                        SpawnPoint.GetComponent<SpawnHexInfo>().spawnNewDesignHex(DesignNummer);
                    } else if (ActiveMethode) {     // Methode kaarten
                        SpawnPoint.GetComponent<SpawnHexInfo>().spawnNewMethodeHex(MethodeNummer);
                    }
                }*/
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
            // KernNummer = 0; MethodeNummer = 0; DesignNummer = 0;
            //ActiveDesign = false; ActiveKern = false; ActiveMethode = false;
            NeedThisHex = 0;

        }
    }

    public void FindObject(Collider other) {
        if (other.CompareTag("Hexagon")) {
            int ActiveHexaNummer = other.GetComponent<spawnInfo>().hexIndex;
            NeedThisHex = ActiveHexaNummer;
            /*

            
            if (other.GetComponent<HexaInfo>().Kernwaarde) {
                KernNummer = ActiveHexaNummer - 100;
                ActiveKern = true;
                
            } else
            //Design thinking methode
            if (other.GetComponent<HexaInfo>().DesignThinking) {
                DesignNummer = ActiveHexaNummer - 50;
                ActiveDesign = true;
            } else
            // Methode kaarten
            if (other.GetComponent<HexaInfo>().Methode) {
                MethodeNummer = ActiveHexaNummer - 200;
                ActiveMethode = true;
            }*/
        }
    }
}
