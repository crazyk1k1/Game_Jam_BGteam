using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGrabNShoot : MonoBehaviour
{

    public bool isMoving;
    public bool handing;
    public bool targetHit;
    public bool resetWord;
    public float shootForce;
    public List<GameObject> words;
    public List<GameObject> globalWords;
    public List<Transform> spawnWords;
    public Transform spawnShoot;

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
                RaycastHit hit;
                Ray ray;

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.gameObject.name == "Cube")
                        {
                            words.Add(hit.collider.gameObject);
                            isMoving = true;
                        }
                    }
                }
            }

            if (handing)
            {
                GameObject shootedWord = Instantiate(words[0], spawnShoot.position, transform.rotation);
                shootedWord.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                shootedWord.GetComponent<Rigidbody>().useGravity = true;
                shootedWord.GetComponent<MeshRenderer>().enabled = true;
                shootedWord.GetComponent<BoxCollider>().enabled = true;
                handing = false;
                //words.Clear();
            }
        }

        if (isMoving)
        {
            Grab();
        }

        OnTargetHit();
    }

    public void Grab()
    {
        words[0].transform.position = Vector3.MoveTowards(words[0].transform.position, gameObject.transform.position, 0.5f);
        if(Vector3.Distance(words[0].transform.position, gameObject.transform.position) <= 1f)
        {
            words[0].GetComponent<MeshRenderer>().enabled = false;
            words[0].GetComponent<BoxCollider>().enabled = false;
            handing = true;
        }
    }

    public void OnTargetHit()
    {
        if (targetHit)
        {
            words.Clear();
        }

        if (resetWord)
        {
            words[0].GetComponent<Rigidbody>().useGravity = false;
            words[0].GetComponent<MeshRenderer>().enabled = true;
            words[0].GetComponent<BoxCollider>().enabled = true;
            //words[0].transform.position = 
            int i;
            //for(i)
        }
    }

}
