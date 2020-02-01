using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGrab : MonoBehaviour
{

    public bool isMoving;
    public List<GameObject> words;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        if (isMoving)
        {
            Grab();
        }
    }

    public void Grab()
    {
        words[0].transform.position = Vector3.MoveTowards(words[0].transform.position, gameObject.transform.position, 0.5f);
        if(Vector3.Distance(words[0].transform.position, gameObject.transform.position) <= 1f)
        {
            words[0].GetComponent<MeshRenderer>().enabled = false;
            words[0].GetComponent<BoxCollider>().enabled = false;
        }
    }

}
