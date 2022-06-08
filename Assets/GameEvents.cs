using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents _current;

    private void Awake() {
        _current = this;
    }
    public event Action<int> OnTileTriggerEnter;
    public void TileTriggerEnter(int id) {
        if (OnTileTriggerEnter != null) {
            OnTileTriggerEnter(id);
        }
    }
    public event Action<int> OnTileTriggerExit;
    public void TileTriggerExit(int id) {
        if (OnTileTriggerExit != null) {
            OnTileTriggerExit(id);
        }
    }
}

