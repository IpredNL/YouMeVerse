using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInhoud : MonoBehaviour
{
    public int number; // wordt dit nummer al gecombineerd naar id?
    //public Controller _controller; // dit moet een verwijzing naar een button op de controller worden (hand_prescence).
    public bool NeedCheck;
    public GameObject Inhoud;

    private void Start() {
        GameEvents._current.OnTileTriggerEnter += OnTilePlayerEnter;
        GameEvents._current.OnTileTriggerExit += OnTilePlayerExit;
    }

    private void OnTilePlayerEnter(int id) {
        if (id == this.number) {
                Inhoud.SetActive(true);
        }
    }
    private void OnTilePlayerExit(int id) {
        if (id == this.number) {
            Inhoud.SetActive(false);
        }
    }
    private void OnDestroy() {
        GameEvents._current.OnTileTriggerEnter -= OnTilePlayerEnter;
        GameEvents._current.OnTileTriggerExit -= OnTilePlayerExit;
    }
}
