using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public ObjectData objectData;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    private void Start()
    {
        spawnPosition = gameObject.transform.position;
        spawnRotation = gameObject.transform.rotation;
    }

    public void ActivateVisual()
    {
        if(gameObject.GetComponent<MeshRenderer>() != null)
            gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void DesactivateVisual()
    {
        if(gameObject.GetComponent<MeshRenderer>() != null)
            gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


    public void ActivateTrigger()
    {
        if(gameObject.GetComponent<BoxCollider>() != null)
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

      public void DesactivateTrigger()
    {
        if(gameObject.GetComponent<BoxCollider>() != null)
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void ResetWord()
    {
        gameObject.transform.position = spawnPosition;
        gameObject.transform.rotation = spawnRotation;
        ActivateVisual();
        ActivateTrigger();
    }

    public void HideWord()
    {
        DesactivateVisual();
        DesactivateTrigger();
    }

    public void SetTrigger()
    {
        if(gameObject.GetComponent<BoxCollider>() != null)
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    public void SetCollider()
    {
        if(gameObject.GetComponent<BoxCollider>() != null)
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

}
