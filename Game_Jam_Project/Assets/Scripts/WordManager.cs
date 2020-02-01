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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Shpere")
        {
            player.GetComponent<WordGrabNShoot>().targetHit = true;
            Destroy(gameObject);
        }

        if (other.name != "Shpere")
        {
            player.GetComponent<WordGrabNShoot>().resetWord = true;
            Destroy(gameObject);
        }
    }
}
