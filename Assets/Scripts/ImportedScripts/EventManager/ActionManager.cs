using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ezygamer.DropNDrag
{

    public class DragNDropActionManager : MonoBehaviour
    {
       
        [SerializeField] Image dropOutline;
        [SerializeField] Color dropColor;
        [SerializeField] Color outlinecolor;
        [SerializeField] Image dropAreaImage;
        Color originalColor;
        Color originalOutlineColor;
        private void Start()
        {
            originalColor = dropAreaImage.color;
            originalOutlineColor = dropOutline.color;
        }

        private void OnEnable()
        {
          
          
            Actions.onDragHighlight += HighlightDragItem;
            Actions.onDragRemoveHighlight += RemoveHighlightDragItem;
            Actions.onDropHighlight += HighlightDropArea;
            Actions.onDropRemoveHighlight += RemoveHighlightDropArea;



        }
        private void OnDisable()
        {
            //for outline
            Actions.onDragHighlight -= HighlightDragItem;
            Actions.onDragRemoveHighlight -= RemoveHighlightDragItem;

            //for drop area
            Actions.onDropHighlight -= HighlightDropArea;
            Actions.onDropRemoveHighlight -= RemoveHighlightDropArea;
        }


        private void RemoveHighlightDropArea()
        {
            dropAreaImage.color = originalColor;
            dropOutline.color = originalOutlineColor;
            Debug.Log("NotHighlight");
        }

        private void HighlightDropArea()
        {
            dropAreaImage.color = dropColor;
            dropOutline.color = outlinecolor;
            Debug.Log("areaHighlight");
        }

       

        private void RemoveHighlightDragItem()
        {
            if (dropOutline != null)
            {
                dropOutline.enabled = false;
            }
        }

        private void HighlightDragItem()
        {
            if (dropOutline != null)
            {
                dropOutline.enabled = true;
            }
        }

      


    }
}
