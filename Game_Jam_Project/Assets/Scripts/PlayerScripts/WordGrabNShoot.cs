using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGrabNShoot : MonoBehaviour
{

    public bool isMoving;
    public bool verbIsMoving;
    public bool handing;
    public bool targetHit;
    public bool resetWord;
    public float shootForce;
    public List<GameObject> words;
    public List<GameObject> verbs;
    public List<GameObject> globalWords;
    public List<Transform> spawnWords;
    public Transform spawnWordShoot;
    public Transform spawnVerbShoot;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!handing)
            {
                resetWord = false;
                RaycastHit hit;
                Ray ray;

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.gameObject.CompareTag("word"))
                        {
                            words.Add(hit.collider.gameObject);
                            isMoving = true;
                        }
                    }
                }
            }
            if (handing)
            {
                Shoot();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray;
            if (!verbIsMoving)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {

                        if (hit.collider.gameObject.CompareTag("Verb"))
                        {
                            verbs.Add(hit.collider.gameObject);
                            verbIsMoving = true;
                        }
                    }
                }
            }
        }

        if (isMoving)
        {
            Grab();
        }

        if (verbIsMoving)
        {
            GrabVerb();
        }

        if(words.Count <= 0 || verbs.Count <= 0)
        {
            resetWord = false;
        }
        
        OnTargetHit();
    }

    public void Grab()
    {
        words[0].transform.position = Vector3.MoveTowards(words[0].transform.position, gameObject.transform.position, 1f);
        if(Vector3.Distance(words[0].transform.position, gameObject.transform.position) <= 1f)
        {
            words[0].GetComponent<MeshRenderer>().enabled = false;
            words[0].GetComponent<BoxCollider>().enabled = false;
            handing = true;
            isMoving = false;
        }
    }

    public void GrabVerb()
    {
        verbs[0].transform.position = Vector3.MoveTowards(verbs[0].transform.position, gameObject.transform.position, 1f);
        if (Vector3.Distance(verbs[0].transform.position, gameObject.transform.position) <= 1f)
        {
            verbs[0].GetComponent<MeshRenderer>().enabled = false;
            verbs[0].GetComponent<BoxCollider>().enabled = false;
            verbIsMoving = false;
        }
    }

    public void Shoot()
    {
        GameObject shootedWord = Instantiate(bulletPrefab, spawnWordShoot.position, spawnWordShoot.rotation);
        shootedWord.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootForce, ForceMode.Impulse);
        shootedWord.GetComponentInChildren<Text>().text = words[0].name;
        shootedWord.GetComponent<WordManager>().type = words[0].GetComponent<WordManager>().type;
        handing = false;

        if (words[0] && verbs[0])
        {
            GameObject shootedWordTwo = Instantiate(bulletPrefab, spawnVerbShoot.position, spawnVerbShoot.rotation);
            shootedWordTwo.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootForce, ForceMode.Impulse);
            shootedWordTwo.GetComponentInChildren<Text>().text = verbs[0].name;
            shootedWordTwo.GetComponent<WordManager>().type = verbs[0].GetComponent<WordManager>().type;
            handing = false;
        }
    }

    public void OnTargetHit()
    {
        if (targetHit)
        {
            words.Clear();
            verbs.Clear();
            targetHit = false;
        }

        if (resetWord)
        {

            int i;
            for (i = 0; i < globalWords.Count; i++)
            {
                if (words[0] == globalWords[i])
                {
                    words[0].transform.position = words[0].GetComponent<WordManager>().spawnPoint;
                    words[0].GetComponent<Rigidbody>().useGravity = false;
                    words[0].GetComponent<MeshRenderer>().enabled = true;
                    words[0].GetComponent<BoxCollider>().enabled = true;
                }
            }

            int a;
            for (a = 0; a < globalWords.Count; a++)
            {
                if (words[0] == globalWords[a])
                {
                    verbs[0].transform.position = verbs[0].GetComponent<WordManager>().spawnPoint;
                    verbs[0].GetComponent<Rigidbody>().useGravity = false;
                    verbs[0].GetComponent<MeshRenderer>().enabled = true;
                    verbs[0].GetComponent<BoxCollider>().enabled = true;
                }
            }
            
            words.Clear();
            verbs.Clear();
            handing = false;
            resetWord = false;
        }
    }

}
