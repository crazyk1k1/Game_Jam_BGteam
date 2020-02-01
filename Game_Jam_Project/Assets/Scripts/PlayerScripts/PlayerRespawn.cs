using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 respawnPoint;
    public bool teleport;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -150f)
        {
            teleport = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
        }
        if (teleport)
        {
            gameObject.transform.position = respawnPoint;
            gameObject.GetComponent<CharacterController>().enabled = true;
            teleport = false;
        }
    }
}
