using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu]
public class DataTransferEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<DataTransferEventListner> eventListeners = 
        new List<DataTransferEventListner>();

        public  int dataCarried; // CHANGER ICI LE TYPE DE DATA 2/3


    public void Raise(int dataTransfer) // CHANGER ICI LE TYPE DE DATA 3/3
    {
        dataCarried = dataTransfer;
        for(int i = eventListeners.Count -1; i >= 0; i--)
            eventListeners[i].OnEventRaised();
    }


    public void RegisterListener(DataTransferEventListner listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(DataTransferEventListner listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
