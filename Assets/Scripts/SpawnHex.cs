using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHex : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMPro.TextMeshPro _text;
    [SerializeField] private Material[] _material;
    [SerializeField] private Material[] _material2;

    public void SetText(string str) {
        _text.text = str;
    }
    public void SetMaterial (int matID) {
        gameObject.GetComponent<Renderer>().material = _material[matID];
    }
}
