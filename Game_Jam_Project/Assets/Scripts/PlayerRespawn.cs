using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Transform respawn;
    public bool canTeleport;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.Find("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -200)
        {
            canTeleport = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
        }
        if (canTeleport)
        {
            transform.position = respawn.position;
            gameObject.GetComponent<CharacterController>().enabled = true;
            canTeleport = false;
        }
    }
}
