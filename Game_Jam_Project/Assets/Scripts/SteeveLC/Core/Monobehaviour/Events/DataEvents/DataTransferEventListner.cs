using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransferEventListner : MonoBehaviour
{
    [Tooltip("Event to register with.")]
        public DataTransferEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public DataTransferResponse Response;


        [SerializeField]
        [TextArea(2,10)]
        private string eventDescription;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke(Event.dataCarried);
        }
}
