using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public SelectDetect _selectDetect;
    public SpawnHexInfo _spawnHexInfo;
    public Text InTrigger;
    public Text debugThis;
    public Text DebugNummer;
    public Text SpawnNummer;
    public Text SpawnDebug;
    public Text madeCopy;
    // Update is called once per frame
    void Update()
    {
        InTrigger.text = "InTrigger = " + _selectDetect.inTrigger;
        debugThis.text = "DebugThis = " + _selectDetect.debugThis;
        DebugNummer.text = "detectie = " + _selectDetect.KernNummer;
        madeCopy.text = "madeCopy = " + _selectDetect.testCopy;
        SpawnNummer.text = "SpawnNummer = " + _spawnHexInfo.DebugNummer;
        SpawnDebug.text = "SpawnDebug = " + _spawnHexInfo.DebugThis;

    }
}
