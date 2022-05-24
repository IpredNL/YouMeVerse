using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (leftTeleportRay) {
            leftTeleportRay.gameObject.SetActive(EnableLeftTeleport && checkIfActivated(leftTeleportRay));
        }
        if (rightTeleportRay) {
            rightTeleportRay.gameObject.SetActive(EnableRightTeleport && checkIfActivated(rightTeleportRay));
        }
    }

    public bool checkIfActivated(XRController controller) {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
