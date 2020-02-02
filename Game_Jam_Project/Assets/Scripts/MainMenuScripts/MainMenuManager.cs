using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject FonduLeave;
    public float timer;
    public bool goTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goTimer)
        {
            timer += 1 * Time.deltaTime;
        }
        if(timer >= 1.5f)
        {
            FonduLeave.SetActive(true);
        }
    }

    public void SetFondu()
    {
        goTimer = true;
    }
}
