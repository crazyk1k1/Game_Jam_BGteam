using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = ("Data/Page"))]
public class PageData : ScriptableObject
{
    public Sprite currentImage;
    public List<Sprite> images = new List<Sprite>();

    public void ChangeImage(int index)
    {
        currentImage = images[index];
    }

    public void Awake()
    {
        currentImage = images[0];
    }


}   
