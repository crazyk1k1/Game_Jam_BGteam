using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObject : MonoBehaviour
{
    private Vector3 pos;
    public float moveLimit;
    public float movePerFrame;
    private float posBegin;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        posBegin=pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = pos.y+movePerFrame;
        transform.position = pos;

        if (pos.y > posBegin+ moveLimit)
        {
            movePerFrame = -movePerFrame;
        }

        if (pos.y < posBegin- moveLimit)
        {
            movePerFrame = -movePerFrame;
        }
    }
}
