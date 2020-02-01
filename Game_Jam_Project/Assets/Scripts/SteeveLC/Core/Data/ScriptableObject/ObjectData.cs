using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName=("Data/Object"))]
public class ObjectData : ScriptableObject
{
    public ObjectType objectType;
    public string objectString;
}
