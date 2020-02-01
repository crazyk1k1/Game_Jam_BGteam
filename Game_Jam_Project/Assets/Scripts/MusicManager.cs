using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> listClip;
    private int indexMusic;
    public AudioSource music;
    AudioClip currentClip;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.M))
        {
            indexMusic = 2;
            Music();
        }*/
    }

    public void Music()
    {
        music.Stop();
        currentClip = listClip[indexMusic];
        music.clip = currentClip;
        music.Play();
    }
}
