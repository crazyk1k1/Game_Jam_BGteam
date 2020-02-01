using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageBehaviour : MonoBehaviour
{
    public List<PageData> listPage;
    public int listPageLength;

    [SerializeField]
    PageData Page;
    
    public void CurrentObject(int index)
    {
        Page = listPage[index];
    }

    public void Start()
    {
        listPage.Capacity = listPageLength;
        Debug.Log(listPageLength);
    }
}
/*public void ActivateVisual()
    {
    if (gameObject.GetComponent<Image>() != null)
        {
            gameObject.GetComponent<Image>().enabled = true;
        
        }
    }

    public void DesactivateVisual()
    {
        if (gameObject.GetComponent<Image>() != null)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
    
    private void Update()
    {
        Page = listPage[];
    }
     */
