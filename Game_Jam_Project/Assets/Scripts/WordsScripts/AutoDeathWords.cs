using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeathWords : MonoBehaviour
{
    public GameObject player;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<WordGrabNShoot>().resetWord = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if(timer >= 5)
        {
            player.GetComponent<WordGrabNShoot>().resetWord = true;
            Destroy(gameObject);
        }
    }
}
