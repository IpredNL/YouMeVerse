using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Hand_presence : MonoBehaviour {
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    public HandHeldController _handHeldcontroller;
    [SerializeField]
    private GameObject HandHeldObject;
    private static bool buttonPressed;
    public Transform handHeldLocation;

    private static bool needTheConconsole;

    private int limbIndex;

    // private debugScript _debugScript;

    // Start is called before the first frame update
    void Start() {
        TryInitialize();

        if (name.ToLower().StartsWith("left")) {
            // 0 = links
            limbIndex = 0;
        } else {
            // 1 = rechts
            limbIndex = 1;
        }
        Debug.Log("handtest>" + name+" limbIndex:"+limbIndex);

       
        //  _debugScript = GameObject.FindGameObjectWithTag("debugger").GetComponent<debugScript>();
        // _debugScript.debugger();
    }

    void TryInitialize() {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices) {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0) {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab) {
                spawnedController = Instantiate(prefab, transform);
            } else {
                Debug.LogError("Het overeenkomende model van de controller is niet gevonden");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    void UpdateHandAnimation() {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        } else {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        } else {
            handAnimator.SetFloat("Grip", 0);
        }
    }
    // Update is called once per frame
    void Update() {
        if (!targetDevice.isValid) {
            TryInitialize();
        } else {
            if (showController) {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            } else {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue == true && limbIndex == 1) {
            needTheConconsole = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue == true && !buttonPressed) {
            if (HandHeldObject.scene.IsValid()) {
                _handHeldcontroller.ActiveSwitch();
            } else if (!needTheConconsole) {
                GameObject instance = Instantiate(HandHeldObject,handHeldLocation.position, handHeldLocation.rotation); // transform.position kan wellicht gekoppeld worden aan een transform -> moet dan in left en right prefab.
                instance.transform.parent = transform;
                needTheConconsole = true;
            }
            buttonPressed = true;
        }
        if (buttonPressed && secondaryButtonValue == false) {
            buttonPressed = false;
        }

        /* targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
         if (secondaryButtonValue == true) {
             _debugScript = GameObject.FindGameObjectWithTag("debugger").GetComponent<debugScript>();
             _debugScript.debugger();
         }
        */
    }
}
