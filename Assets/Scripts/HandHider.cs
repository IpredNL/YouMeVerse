using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    private SkinnedMeshRenderer _meshRenderer = null;
    private XRDirectInteractor _interactor = null;

    private void Awake() {
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _interactor = GetComponent<XRDirectInteractor>();

        _interactor.onHoverEntered.AddListener(Hide);
        _interactor.onHoverExited.AddListener(Show);
    }

    private void OnDestroy() {
        _interactor.onHoverEntered.RemoveListener(Hide);
        _interactor.onHoverExited.RemoveListener(Show);
    }

    private void Show (XRBaseInteractable interactable) {
        _meshRenderer.enabled = true;
    }
    private void Hide (XRBaseInteractable interactable) {
        _meshRenderer.enabled = false;
    }
}
