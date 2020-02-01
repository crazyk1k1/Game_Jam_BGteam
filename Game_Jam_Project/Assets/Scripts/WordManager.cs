using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public GameObject player;

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
        if (collision.gameObject.name == "Sphere")
        {
            player.GetComponent<WordGrabNShoot>().targetHit = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.name != "Sphere")
        {
            player.GetComponent<WordGrabNShoot>().resetWord = true;
            Destroy(gameObject);
        }
    }
}
