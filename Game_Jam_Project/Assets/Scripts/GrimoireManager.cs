using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoireManager : MonoBehaviour
{
    public GameObject pageG;
    public GameObject pageD;
    public GameObject Grimoire;

    public PageData BatonG;
    public PageData BatonD;
    public PageData StoneG;
    public PageData StoneD;
    public PageData MaisonG;
    public PageData MaisonD;
    public PageData RituelG;
    public PageData RituelD;

    /*public Sprite[] pagesImcompleteSprite;
    public Sprite[] pagesCompleteSprite;*/

    private int indexPageG;
    private int indexPageBaton;
    private int indexPageStone;
    private int indexPageMaison;
    private int indexPageRituel;
    

    public static GrimoireManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        /*indexButtonInput = 0;
        pageG.GetComponent<SpriteRenderer>().sprite = pagesImcompleteSprite[indexPageI];
        pageD.GetComponent<SpriteRenderer>().sprite = pagesImcompleteSprite[indexPageI+1];*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Grimoire.SetActive(!Grimoire.activeSelf);
        }

        
        /*if(indexButtonInput > 3)
        {
            indexButtonInput = 3;
        }

        if (indexButtonInput < 0)
        {
            indexButtonInput = 0;
        }*/
    }

    public void NextPage()
    {
        indexPageG++;
        if(indexPageG > pageG.GetComponent<PageBehaviour>().listPageLength)
        {
            indexPageG = pageG.GetComponent<PageBehaviour>().listPageLength;
        }
        pageG.GetComponent<PageBehaviour>().CurrentObject(indexPageG);
        pageD.GetComponent<PageBehaviour>().CurrentObject(indexPageG);
        Debug.Log("Next");
        Debug.Log(indexPageG);
    }

    public void PreviousPage()
    {
        indexPageG--;
        if (indexPageG < 0)
        {
            indexPageG = 0;
        }
        pageG.GetComponent<PageBehaviour>().CurrentObject(indexPageG);
        pageD.GetComponent<PageBehaviour>().CurrentObject(indexPageG);
        Debug.Log("Previous");
        Debug.Log(indexPageG);
    }

    public void BatonLvPageComplete()
    {
        if (indexPageBaton > 2)
        {
            indexPageBaton = 2;
        }
        BatonG.ChangeImage(indexPageBaton);
        BatonD.ChangeImage(indexPageBaton);
    }

    public void StoneLvPageComplete()
    {
        if (indexPageStone > 2)
        {
            indexPageStone = 2;
        }
        StoneG.ChangeImage(indexPageStone);
        StoneD.ChangeImage(indexPageStone);
    }

    public void MaisonLvPageComplete()
    {
        if(indexPageMaison > 2)
        {
            indexPageMaison = 2;
        }
        MaisonG.ChangeImage(indexPageMaison);
        MaisonD.ChangeImage(indexPageMaison);
    }

    public void RituelLvPageComplete()
    {
        if (indexPageRituel > 2)
        {
            indexPageRituel = 2;
        }
        RituelG.ChangeImage(indexPageRituel);
        RituelD.ChangeImage(indexPageRituel);
    }
}
