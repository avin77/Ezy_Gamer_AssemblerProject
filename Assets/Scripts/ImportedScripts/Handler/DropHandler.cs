using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;


namespace ezygamer.DropNDrag
{
    public class DropHandler : MonoBehaviour, IDropHandler
    {
        private CMSGameEventManager eventManager;

        [Inject]
        public void Construct(CMSGameEventManager eventManager)
        {
            this.eventManager = eventManager;
        }


        // This method is called when an object is dropped onto this GameObject
        public void OnDrop(PointerEventData eventData)
        {
            //retrieve the DragHandler component from the object being dragged
            DragHandler draggableHandler = eventData.pointerDrag?.GetComponent<DragHandler>();


            if (draggableHandler != null)
            {

                //Get the transform of the draggableHandler GameObject
                var draggadGamObject = draggableHandler.gameObject.transform;
                // Set the parent of the dragged object to this GameObject
                draggadGamObject.SetParent(this.transform);
                // Reset the local position of the dragged object to zero
                draggadGamObject.transform.localPosition = Vector3.zero;
                Debug.Log("ItemDropped");

                eventManager.OptionSelected("answer"); //triggering the event -rohan37kumar
                Debug.Log("action called");
            }
        }

    }
}
