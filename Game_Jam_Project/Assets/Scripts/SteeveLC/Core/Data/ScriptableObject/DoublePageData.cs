using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="Data/DoublePage")]
public class DoublePageData : ScriptableObject
{
     public PageSerialized currentPage;
   
    public List<PageSerialized> PageVersions = new List<PageSerialized>();

    public int currentversion = 0;

    public void PageNextversion()
    {
        if (currentversion < PageVersions.Count -1)
            {
            currentversion++;
            currentPage = PageVersions[currentversion];
            Debug.Log("PageUpdated");
            }
    }
    
}
