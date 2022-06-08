using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBeschrijving : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshPro _beschrijving;

    public void SetBeschrijving(string str) {
             _beschrijving.text = str;
    }
}
