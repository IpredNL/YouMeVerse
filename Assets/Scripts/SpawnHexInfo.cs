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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnThisHex(int hexaId) {
        string word = "unknown";
        int _material = 0;

        if (Database.data.TryGetValue(hexaId, out Database.Item item)) {
            word = item.text;
            _material = item.matId;
        }

        GameObject instance = GameObject.Instantiate(BigHexaPrefab, transform.position, Quaternion.Euler(new Vector3(0, 90, 0))); // bighexPrefab krijgt niet de waarde voor spawnInfo mee
        instance.GetComponent<spawnInfo>().hexIndex = hexaId;
        instance.transform.parent = transform;
        // instance.GetComponent<SpawnHex>().SetText(word);
        //  instance.GetComponent<SpawnHex>().SetMaterial(_material);
    }
    // hieronder word de oude methode van spawnen besproken.
    // de methode hierboven is sneller en gaat uit van één enkele prefab die gebruik maakt van de Database.cs


   /* public void spawnNewKernHex(int kernNummer) {
        DebugNummer = kernNummer;
        DebugThis = true;
         GameObject instance = Instantiate(_hexManager.KernwaardeHex[kernNummer-1],transform.position, Quaternion.Euler(new Vector3(90, 0, 90))); //orgineel was 90,0,90 voor socketsnap
        instance.transform.parent = transform;
    }
    public void spawnNewDesignHex(int designNummer) {
            GameObject instance = Instantiate(_hexManager.DesignThinkingHex[designNummer-1],transform.position, Quaternion.Euler(new Vector3(90, 0, 90)));
        instance.transform.parent = transform;
    }
    public void spawnNewMethodeHex(int methodeNummer) {
        GameObject instance = Instantiate(_hexManager.MethodeHex[methodeNummer-1], transform.position, Quaternion.Euler(new Vector3(90, 0, 90)));
        instance.transform.parent = transform;
    }*/
    public void DestroyHex() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

}
