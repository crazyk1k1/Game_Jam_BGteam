using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoireManager : MonoBehaviour
{
    public GameObject pageG;
    public GameObject pageD;
    public GameObject Grimoire;

    public Sprite[] pagesImcompleteSprite;
    public Sprite[] pagesCompleteSprite;

    private int indexPageI;
    private int indexPageC;
    private int indexButtonInput;

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
        indexButtonInput = 0;
        pageG.GetComponent<SpriteRenderer>().sprite = pagesImcompleteSprite[indexPageI];
        pageD.GetComponent<SpriteRenderer>().sprite = pagesImcompleteSprite[indexPageI+1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Grimoire.SetActive(!Grimoire.activeSelf);
        }

        if(indexButtonInput > 3)
        {
            indexButtonInput = 3;
        }

        if (indexButtonInput < 0)
        {
            indexButtonInput = 0;
        }
    }

    public void NextPage()
    {
        indexButtonInput++;
    }

    public void PreviousPage()
    {
        indexButtonInput--;
    }

    private void ModifPage()
    {

    }
}
