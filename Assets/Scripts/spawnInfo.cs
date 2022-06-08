using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnInfo : MonoBehaviour
{
    public int hexIndex;
    public GameObject outsideHex;

    void Start() {

        string word = "HexIndex";

        int _material = 0;
        if (Database.data.TryGetValue(hexIndex, out Database.Item item)) {
            word = item.text;
            _material = item.matId;
        }
        gameObject.GetComponent<SpawnHex>().SetText(word);
        outsideHex.GetComponent<SpawnHex>().SetMaterial(_material);
    }
}
