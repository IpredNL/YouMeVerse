using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrab : XRGrabInteractable {
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntered(XRBaseInteractor interactor) {
        base.OnSelectEntered(interactor);
        if (interactor is XRDirectInteractor) {
            StoreInteractor(interactor);
            MatchAttachmentPoints(interactor);
        }
    }



    private void StoreInteractor(XRBaseInteractor interactor) {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.transform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor) {
        bool hasAttach = transform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor) {
        base.OnSelectExited(interactor);
        ResetAttachmentPoint(interactor);
        Clearinteractor(interactor);
    }

    private void ResetAttachmentPoint(XRBaseInteractor interactor) {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void Clearinteractor(XRBaseInteractor interactor) {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
