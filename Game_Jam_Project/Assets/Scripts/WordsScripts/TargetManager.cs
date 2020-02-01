using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TargetManager : MonoBehaviour
{
    public ObjectData type;
    public GameObject player;
    public bool word;
    public bool verb;
    public bool canCoolDown;
    public string wordR;
    public string verbR;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<WordManager>().type.objectString == wordR)
        {
            word = true;
        }

        if (collision.gameObject.GetComponent<WordManager>().type.objectString == verbR)
        {
            verb = true;
        }
    }
}
