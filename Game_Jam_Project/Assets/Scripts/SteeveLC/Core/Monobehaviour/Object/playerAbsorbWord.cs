using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAbsorbWord : MonoBehaviour
{
    public Transform launchPosition;
    public GameObject launchProjectile;

    bool asWordInHold;

    [SerializeField] bool asVerbInHold;

    [SerializeField] private bool wordMoves;
    [SerializeField] private bool verbMoves;

    private GameObject wordToMove;

    [SerializeField] private float absorbSpeed;

    void Update() 
    {
        LeftClicInput();
        RightClicInput();
        MoveWord(wordToMove);
    }
    
    private IEnumerator temporaryCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        verbMoves = false;
        yield return null;
    }
        

    // Le déplacement ne marche pas  - le reste fonctionne
    void MoveWord(GameObject other)
    {
        if(wordMoves && wordToMove != null)
        {
        other.transform.position = Vector3.MoveTowards(other.transform.position,gameObject.transform.position, absorbSpeed*Time.deltaTime);
        //Debug.Log(Vector3.Distance(gameObject.transform.position,other.transform.position));
        if(Vector3.Distance(gameObject.transform.position,other.transform.position) <= 1f)
        {
            launchProjectile.GetComponent<LaunchProjectileBehaviour>().wordToLaunch = other.GetComponent<ObjectBehaviour>().objectData;
            launchProjectile.GetComponent<LaunchProjectileBehaviour>().AddWord();
            launchProjectile.GetComponent<LaunchProjectileBehaviour>().wordAbsorbed = other;
            other.GetComponent<ObjectBehaviour>().HideWord();
            wordMoves = false;
            Debug.Log("WordMovedFinished");
        }
        }
    }
        


    void LeftClicInput()
    {
        // Si clic gauche et n'a pas de mot en stock : récupère sur le 
        if (Input.GetMouseButtonDown(0) && asWordInHold == false)
        {
            RaycastHit hit;
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              {
                 if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    
                       if (hit.collider.gameObject.tag =="word" 
                    && hit.collider.gameObject.GetComponent<ObjectBehaviour>()!=null)
                       {
                            hit.collider.gameObject.GetComponent<ObjectBehaviour>().DesactivateTrigger();
                            wordMoves = true;
                            wordToMove = hit.collider.gameObject;
                            asWordInHold = true;
                       }
                   }
              }
        }

        // Si clic gauche et à mot en stock : lance le LaunchPrototol sur le projectile 
        if (Input.GetMouseButtonDown(0) && asWordInHold && wordMoves == false)
        {   
        launchProjectile.GetComponent<LaunchProjectileBehaviour>().launchProtocol();
        asVerbInHold = false;
        asWordInHold = false;
        Debug.Log ("WordShot");
        }
    }
       
     void RightClicInput()
    {

        
        // Si clic droit : stock le verb dans le Launch Projectile 
         if (Input.GetMouseButtonDown(1) && !asVerbInHold && wordMoves == false)
        {
            Debug.Log("Absorbverb");
         RaycastHit hit;
         Ray ray;
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.CompareTag("Verb") 
                    && hit.collider.gameObject.GetComponent<ObjectBehaviour>()!=null)
                    {
                        launchProjectile.GetComponent<LaunchProjectileBehaviour>().verbToLaunch = hit.collider.gameObject.GetComponent<ObjectBehaviour>().objectData;
                        launchProjectile.GetComponent<LaunchProjectileBehaviour>().AddVerb();
                        asVerbInHold = true;
                        verbMoves = true;
                        StartCoroutine(temporaryCoroutine());
                        Debug.Log("AsVerbInHold");
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && asVerbInHold && wordMoves == false && verbMoves == false)
        {   
            Debug.Log("Releaseverb");
            launchProjectile.GetComponent<LaunchProjectileBehaviour>().ReleaseVerbProtocol();
            asVerbInHold = false;
        }

        

    }

        
}

