using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetBehaviour : MonoBehaviour
{
    public ObjectData targetWordSocket;
    public ObjectData targetVerbSocket;

    public GameEvent targetEvent;


    public void ActivateNextStep()
    {
        targetEvent.Raise();
    }
}
