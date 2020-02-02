using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject FonduLeave;
    public GameObject FonduEnter;
    public GameObject mainMenuSection;
    public GameObject helpSection;
    public float timer;
    public float enterTimer;
    public bool goTimer;
    public bool onHelpMenu;
    public bool goPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        enterTimer += 1 * Time.deltaTime;

        if(enterTimer >= 2)
        {
            FonduEnter.SetActive(false);
        }
        if (goTimer)
        {
            timer += 1 * Time.deltaTime;
        }
        if(timer >= 1.5f)
        {
            FonduLeave.SetActive(true);
        }

        if (onHelpMenu)
        {
            mainMenuSection.SetActive(false);
            helpSection.SetActive(true);
        }
        else
        {
            mainMenuSection.SetActive(true);
            helpSection.SetActive(false);
        }
        if (goPlay)
        {
            mainMenuSection.SetActive(false);
        }
    }

    public void SetFondu()
    {
        goTimer = true;
        goPlay = true;
    }

    public void HelpMenu()
    {
        onHelpMenu = !onHelpMenu;
    }


}
