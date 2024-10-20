using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace ezygamers.dragndropv1
{
    //this class implements the IDragStrategy interface to handle drap operation on UI element
    public class UIElementDrag : IDragStrategy
    {
        //reference of the element
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        //private bool isInDropZone = false;
        //store the intial position
        private Vector3 origanalPosition;
        private GameObject currentDropArea = null;

        //intialization through constructor with required components
        public UIElementDrag(RectTransform rectTransform, CanvasGroup canvasGroup)
        {
            this.rectTransform = (rectTransform);
            this.canvasGroup = canvasGroup;
            origanalPosition = rectTransform.localPosition;
        }

        //when user start dragging the UI element
        public void OnBeginDrag(PointerEventData eventData)
        {

            Actions.onDragHighlight?.Invoke();
            //disable the raycast of dragged item
            canvasGroup.blocksRaycasts = false;
            //scale down the draggable element
            rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        }

        //
        public void OnDrag(PointerEventData eventData)
        {
            //update the position of the UI
            rectTransform.position = Input.mousePosition;

            GameObject newDropArea = null;
            if (eventData.pointerEnter != null)
            {
                // Try to get DropHandler from the current object or its parents
                var dropHandler = eventData.pointerEnter.GetComponent<DropHandler>();
                if (dropHandler == null)
                {
                    dropHandler = eventData.pointerEnter.GetComponentInParent<DropHandler>();
                }

                if (dropHandler != null)
                {
                    newDropArea = dropHandler.gameObject;
                }
            }

            // Handle drop area changes
            if (newDropArea != currentDropArea)
            {
                // Remove highlight from previous drop area
                if (currentDropArea != null)
                {
                    Actions.onDropRemoveHighlight?.Invoke(currentDropArea);
                    //isInDropZone = false;
                }

                // Add highlight to new drop area
                if (newDropArea != null)
                {
                    Actions.onDropHighlight?.Invoke(newDropArea);
                    //isInDropZone = true;
                }

                currentDropArea = newDropArea;
            }
        }

        //when user stops dragging
        public void OnEndDrag(PointerEventData eventData)
        {
            //enable the raycast for interaction
            canvasGroup.blocksRaycasts = true;

            bool validDrop = false;
            if (eventData.pointerEnter != null)
            {
                var dropHandler = eventData.pointerEnter.GetComponent<DropHandler>();
                if (dropHandler == null)
                {
                    dropHandler = eventData.pointerEnter.GetComponentInParent<DropHandler>();
                }
                validDrop = dropHandler != null;
            }

            if (!validDrop)
            {
                rectTransform.anchoredPosition = origanalPosition;
            }

            // Remove all highlights
            if (currentDropArea != null)
            {
                Actions.onDropRemoveHighlight?.Invoke(currentDropArea);
                currentDropArea = null;
                //isInDropZone = false;
            }

            Actions.onDragRemoveHighlight?.Invoke();
            rectTransform.localScale = Vector3.one;
        }
    }
}