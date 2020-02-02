using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PageSerialized
{
    [SerializeField] string pageName;
    [TextArea(1,10)] public string pagetext;
    public Sprite pageIllustration;
}
