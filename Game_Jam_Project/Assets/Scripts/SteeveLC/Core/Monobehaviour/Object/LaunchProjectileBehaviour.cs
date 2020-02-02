using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaunchProjectileBehaviour : MonoBehaviour
{
    public ObjectData wordToLaunch;
    public ObjectData verbToLaunch;
    public TMP_Text wordToLaunchTxt;
    public TMP_Text verbToLaunchTxt;

    public GameObject wordAbsorbed;
    
    bool projectileFired; 

    bool resetAlready;

    [SerializeField] private float launchForce;

    [SerializeField] private Transform socket;

    private IEnumerator resetcoroutine()
    {
        yield return new WaitForSecondsRealtime(5f);
        if(!resetAlready)
            ResetProtocol();
        yield return null;
    }

    private void Update() 
    {
       if(!projectileFired)
       {
           transform.position = socket.position;
           transform.rotation = socket.rotation;
       } 
    }

    public void AddWord()
    {
        wordToLaunchTxt.text = wordToLaunch.objectString;
        wordToLaunchTxt.enabled = true;
    } 

    public void AddVerb()
    {
        verbToLaunchTxt.text = verbToLaunch.objectString;
        verbToLaunchTxt.enabled = true;
    }

    public void launchProtocol()
    {
        if(projectileFired == false)
        {
        projectileFired = true;
        resetAlready = false;
        wordAbsorbed.GetComponent<ObjectBehaviour>().HideWord();
        transform.position = socket.position;
        transform.rotation = socket.rotation;
        gameObject.GetComponent<Rigidbody>().AddForce(socket.forward * launchForce, ForceMode.Impulse);
        StartCoroutine(resetcoroutine());
        }
    }

    void ResetProtocol()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = socket.position;
        transform.rotation = socket.rotation;
        wordToLaunchTxt.enabled = false;
        verbToLaunchTxt.enabled = false;
        wordToLaunch = null;
        verbToLaunch = null;
        wordAbsorbed.GetComponent<ObjectBehaviour>().ResetWord();
        projectileFired = false;
    }

    public void ReleaseVerbProtocol()
    {
        verbToLaunchTxt.text = "";
        verbToLaunch = null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(projectileFired)
        {
        // Si la cible touché est 
        if(other.tag == "Target")
        {
            if(other.GetComponent<TargetBehaviour>()!= null)
            {
                if (other.GetComponent<TargetBehaviour>().targetWordSocket == wordToLaunch
                && other.GetComponent<TargetBehaviour>().targetVerbSocket == verbToLaunch)
                   other.GetComponent<TargetBehaviour>().ActivateNextStep();
                
            }
        }
        ResetProtocol();
        resetAlready = true;
        }
        
    }
}
