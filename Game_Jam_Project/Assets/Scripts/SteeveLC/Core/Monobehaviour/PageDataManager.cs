using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageDataManager : MonoBehaviour
{
    public DoublePageData currentDoublePageData;

    void Start()
    {
        currentDoublePageData.currentPage = currentDoublePageData.PageVersions[0];       
    }

    int currentversion = 0;

    public void PageNextVersion()
    {
        currentversion++;
        currentDoublePageData.currentPage = currentDoublePageData.PageVersions[currentversion];
    }
}
