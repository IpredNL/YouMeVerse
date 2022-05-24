using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveSwitch() {


         if (gameObject.activeSelf) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false); // link deze met de hexabak en de blokjes worden ook gehide
            }
        } else {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
        }
    }
}
