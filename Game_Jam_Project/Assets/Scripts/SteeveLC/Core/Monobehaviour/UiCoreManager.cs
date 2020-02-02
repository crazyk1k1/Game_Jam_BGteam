using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCoreManager : MonoBehaviour
{
    [SerializeField] GameObject uiGrimoireFull;
    [SerializeField] TMP_Text uiGrimoiretext;
    [SerializeField] Image uiGrimoireIllustration;

    [SerializeField] List<DoublePageData> allDoublePages;

    public DoublePageData currentDoublePageData;
    int pageNumber;

    bool grimoireIsOpen;

    bool inAnimation;

    [SerializeField] Sprite backupIllustration;

    [SerializeField] GameEvent fpsControllerActivate;
    [SerializeField] GameEvent fpsControllerDesactivate;

    [SerializeField] TMP_Text uiGrimoirePageLeftBottom;
     [SerializeField] TMP_Text uiGrimoirePageRightBottom;

    void Start()
    {
        
        pageNumber = 0;
        currentDoublePageData = allDoublePages[0];
        int j;
        int k;
        j = (pageNumber*2);
        k = (pageNumber*2)+1;
        uiGrimoirePageLeftBottom.text = j.ToString();
        uiGrimoirePageRightBottom.text = k.ToString();
        int i;
        for (i=0;i < allDoublePages.Count; i++)
        {
        allDoublePages[i].currentPage =  allDoublePages[i].PageVersions[0];
        allDoublePages[i].currentversion = 0;  
        }  
        PageRefresh();  
    }

    private void Update() 
    {
        OpenGrimoireInput();    
        MovePageInput();
    }

    void OpenGrimoireInput()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
             if(!grimoireIsOpen)
            {
                fpsControllerDesactivate.Raise();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                uiGrimoireFull.SetActive(true);
                grimoireIsOpen = true;
                
            }
            else
            {
                
                fpsControllerActivate.Raise();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                uiGrimoireFull.SetActive(false);
                grimoireIsOpen = false;
                
            }
        }
       
    }

    public void CloseUI()
    {
        if(grimoireIsOpen)
            {
                fpsControllerActivate.Raise();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                uiGrimoireFull.SetActive(false);
                grimoireIsOpen = false;
            }
    }

    void MovePageInput()
    {
        if(grimoireIsOpen && !inAnimation)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                BoutonPageGauche();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                BoutonPageDroite();
            }
        }
    }

    private IEnumerator tempoCouroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        PageRefresh();
        yield return null;
    }


    public void SelectPageForNextVersion(int i)
    {
        if(allDoublePages[i] != null)
        {
            Debug.Log(allDoublePages[i]);
            allDoublePages[i].PageNextversion();
            // Start Animation for change
            StartCoroutine(tempoCouroutine());
            Debug.Log("PageSelected");
        }
    }

    public void PageRefresh()
    {
        int j;
        int k;
        j = (pageNumber*2);
        k = (pageNumber*2)+1;
        uiGrimoirePageLeftBottom.text = j. ToString();
        uiGrimoirePageRightBottom.text = k.ToString();
        uiGrimoiretext.text = currentDoublePageData.currentPage.pagetext; 
        if(currentDoublePageData.currentPage.pageIllustration != null)
            uiGrimoireIllustration.sprite = currentDoublePageData.currentPage.pageIllustration;
        else
            uiGrimoireIllustration.sprite = backupIllustration;
        
         
    }

    public void BoutonPageGauche()
    {
        
        if(pageNumber > 0)
        {
            pageNumber--;
            currentDoublePageData = allDoublePages[pageNumber];
        }
        PageRefresh();

    }

    public void BoutonPageDroite()
    {  

        if(pageNumber < allDoublePages.Count -1)
        {
            pageNumber++;
            currentDoublePageData = allDoublePages[pageNumber];
        }
        PageRefresh();
    }

}
