using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private int indexPageG = 0;
    private int indexPageBaton = 0;
    private int indexPageStone = 0;
    private int indexPageMaison = 0;
    private int indexPageRituel = 0;
    

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

        if (Input.GetKeyDown(KeyCode.K))
        {
            BatonLvPageComplete();
            Debug.Log("là");
        }

        if(indexPageG == 0)
        {
            BatonLvPageComplete();
            pageG.GetComponent<Image>().sprite = BatonG.currentImage;
            pageD.GetComponent<Image>().sprite = BatonD.currentImage;
        }

        if(indexPageG == 1)
        {
            StoneLvPageComplete();
            pageG.GetComponent<Image>().sprite = StoneG.currentImage;
            pageD.GetComponent<Image>().sprite = StoneD.currentImage;
        }

        if(indexPageG == 2)
        {
            MaisonLvPageComplete();
            pageG.GetComponent<Image>().sprite = MaisonG.currentImage;
            pageD.GetComponent<Image>().sprite = MaisonD.currentImage;
        }

        if(indexPageG == 3)
        {
            RituelLvPageComplete();
            pageG.GetComponent<Image>().sprite = RituelG.currentImage;
            pageD.GetComponent<Image>().sprite = RituelD.currentImage;
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
        if(indexPageG > 3)
        {
            indexPageG = 3;
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
        pageG.GetComponent<Image>().sprite = BatonG.currentImage;
        //pageD.GetComponent<Sprite>().Equals(BatonD.currentImage);
    }

    public void StoneLvPageComplete()
    {
        if (indexPageStone > 2)
        {
            indexPageStone = 2;
        }
        StoneG.ChangeImage(indexPageStone);
        StoneD.ChangeImage(indexPageStone);
        //pageG.GetComponent<Sprite>().Equals(StoneG.currentImage);
        //pageD.GetComponent<Sprite>().Equals(StoneD.currentImage);
    }

    public void MaisonLvPageComplete()
    {
        if(indexPageMaison > 2)
        {
            indexPageMaison = 2;
        }
        MaisonG.ChangeImage(indexPageMaison);
        MaisonD.ChangeImage(indexPageMaison);
        //pageG.GetComponent<Sprite>().Equals(MaisonG.currentImage);
        //pageD.GetComponent<Sprite>().Equals(MaisonD.currentImage);
    }

    public void RituelLvPageComplete()
    {
        if (indexPageRituel > 2)
        {
            indexPageRituel = 2;
        }
        RituelG.ChangeImage(indexPageRituel);
        RituelD.ChangeImage(indexPageRituel);
        //pageG.GetComponent<Sprite>().Equals(RituelG.currentImage);
        //pageD.GetComponent<Sprite>().Equals(RituelD.currentImage);
    }
}
