using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public int id; // nummer van de spawn tile
    public int hexIndex; // nummer van de hexagon

    public void Start() {
        string beschrijving = "HexBeschrijving";

        if (Database.data.TryGetValue(hexIndex, out Database.Item item)) {
            beschrijving = item.beschrijving;
        }
        gameObject.GetComponent<spawnBeschrijving>().SetBeschrijving(beschrijving);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameEvents._current.TileTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            GameEvents._current.TileTriggerExit(id);
        }

    }
}
