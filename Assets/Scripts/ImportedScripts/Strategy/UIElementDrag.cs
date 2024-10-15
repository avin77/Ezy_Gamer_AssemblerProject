using UnityEngine.EventSystems;
using UnityEngine;
using System;


namespace ezygamer.DropNDrag
{
    //this class implements the IDragStrategy interface to handle drap operation on UI element
    public class UIElementDrag :IDragStrategy
    {
      //reference of the element
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private bool isInDropZone = false;
        //store the intial position
        private Vector3 origanalPosition;
        //intialization through constructor with required components
        public UIElementDrag(RectTransform rectTransform,CanvasGroup canvasGroup){
            this.rectTransform=(rectTransform);
            this.canvasGroup = canvasGroup;
            origanalPosition =rectTransform.localPosition;
        }

       
        //when user start dragging the UI element
        public void OnBeginDrag(PointerEventData eventData)
        {

            Actions.onDragHighlight?.Invoke();
            //disable the raycast of dragged item
            canvasGroup.blocksRaycasts = false;
            //scale down the draggable element
            rectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            
        }
    
        //
        public void OnDrag(PointerEventData eventData)
        {
            //update the position of the UI
            rectTransform.position = Input.mousePosition ;
            if (eventData.pointerEnter && eventData.pointerEnter.GetComponent<DropHandler>())
            {
                if (!isInDropZone)
                {
                    //If newly entered a valid drop zone, trigger the drop area highlight
                    Actions.onDropHighlight?.Invoke();
                    isInDropZone = true;
                }
            }
            else if (isInDropZone)
            {
                //if leaving the valid drop zone, remove the highlight
                Actions.onDropRemoveHighlight?.Invoke();
                isInDropZone = false;
            }
        }

       

    //when user stops dragging
    public void OnEndDrag(PointerEventData eventData)
        {
            //enable the raycast for interaction
            canvasGroup.blocksRaycasts = true;
            
            // Check if it was dropped on a valid DropHandler
            if (!eventData.pointerEnter || !eventData.pointerEnter.GetComponent<DropHandler>())
            {
                // Snapback to original position if not dropped in a valid DropHandler
                rectTransform.anchoredPosition =origanalPosition ;
               
            }
            //reve
            rectTransform.localScale = new Vector3(1f, 1f, 1f);

            //remove the highlight of drop area
            Actions.onDragRemoveHighlight?.Invoke();
            
        }
    }
}
