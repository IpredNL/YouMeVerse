using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHexInfo : MonoBehaviour
{
    public int SpawnHexNummer;
    public HexManager _hexManager;
    public bool DebugThis;
    public int DebugNummer;
    public List<GameObject> SpawnedHex;
    public GameObject BigHexaPrefab;
    public void spawnThisHex(int hexaId) {
        string word = "unknown";
        string beschrijving = "Beschrijf mij wat?";
        int _material = 0;

        if (Database.data.TryGetValue(hexaId, out Database.Item item)) { // grote kans dat dit niet gebruikt word.
            word = item.text;
            _material = item.matId;
            beschrijving = item.beschrijving;
        }

        GameObject instance = GameObject.Instantiate(BigHexaPrefab, transform.position, Quaternion.Euler(new Vector3(0, 90, 0))); // bighexPrefab krijgt niet de waarde voor spawnInfo mee
        instance.GetComponent<spawnInfo>().hexIndex = hexaId;
        instance.GetComponent<AreaTrigger>().hexIndex = hexaId; // moet de waarde van de hexa doorgeven om beschrijving te koppelen.
        instance.GetComponent<AreaTrigger>().id = SpawnHexNummer;
        instance.GetComponent<ShowInhoud>().number = SpawnHexNummer;
        instance.transform.parent = transform;
    }
    public void DestroyHex() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

}
