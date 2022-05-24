using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class colorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer _meshRenderer = null;
    private XRBaseInteractable _interactable = null;
    private Material originalMaterial = null;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = _meshRenderer.material;

        _interactable = GetComponent<XRBaseInteractable>();
        _interactable.onHoverEntered.AddListener(SetSelectMaterial);
        _interactable.onHoverExited.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy() {
        _interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        _interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor) {
        _meshRenderer.material = selectMaterial;
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor) {
        _meshRenderer.material = originalMaterial;
    }
}
