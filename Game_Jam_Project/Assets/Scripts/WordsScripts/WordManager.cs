using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public GameObject player;
    public ObjectData type;
    public Vector3 spawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawnPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && collision.gameObject.GetComponent<TargetManager>().type == type)
        {
            player.GetComponent<WordGrabNShoot>().targetHit = true;
            Destroy(gameObject);
        }

        else
        {
            if(!collision.gameObject.CompareTag("Verb") && !collision.gameObject.CompareTag("word"))
            {
                player.GetComponent<WordGrabNShoot>().resetWord = true;
                Destroy(gameObject);
            }
        }

        if (!collision.gameObject.CompareTag("Target") && !collision.gameObject.CompareTag("word") && !collision.gameObject.CompareTag("Verb"))
        {
            player.GetComponent<WordGrabNShoot>().resetWord = true;
            Destroy(gameObject);
        }
    }
}
