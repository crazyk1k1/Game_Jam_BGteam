using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLocalisator : MonoBehaviour
{

    public KeyCode outlineKey;
    public GameObject[] word;
    public GameObject[] verb;
    public float TimeOutline;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(outlineKey))
        {
            outline();
        }
    }

    public void outline()
    {
        word = GameObject.FindGameObjectsWithTag("word");
        verb = GameObject.FindGameObjectsWithTag("Verb");

        foreach (GameObject go in word)
        {
            go.GetComponent<Outline>().enabled = true;
        }

        foreach (GameObject go in verb)
        {
            go.GetComponent<Outline>().enabled = true;
        }

        StartCoroutine(resetOutline());

    }

    public IEnumerator resetOutline()
    {
        yield return new WaitForSeconds(TimeOutline);

        foreach (GameObject go in word)
        {
            go.GetComponent<Outline>().enabled = false;
        }

        foreach (GameObject go in verb)
        {
            go.GetComponent<Outline>().enabled = false;
        }
    }
}
