using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVersionningPages : MonoBehaviour
{
    public DataTransferEvent datatotest;
    public int testDataInt;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
       {
           Debug.Log("EventFired");
            datatotest.Raise(testDataInt);
        }
    }
}
