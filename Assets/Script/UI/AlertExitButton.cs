using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertExitButton : MonoBehaviour
{
    public void Onckilck()
    {
        //print("aa");
        UIManger.ins.ExitAlert();
    }
}
