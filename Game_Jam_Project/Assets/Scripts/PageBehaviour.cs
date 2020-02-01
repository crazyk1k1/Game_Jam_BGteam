using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageBehaviour : MonoBehaviour
{
    public void ActivateVisual()
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
}
