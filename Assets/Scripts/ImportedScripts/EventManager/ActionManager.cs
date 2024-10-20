using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ezygamers.dragndropv1
{

    public class DragNDropActionManager : MonoBehaviour
    {
       
        [SerializeField] Image dropOutline;
        [SerializeField] Color dropColor;
        [SerializeField] Color outlinecolor;
        [SerializeField] Image dropAreaImage;
        Color originalColor;
        Color originalOutlineColor;

        private bool isActive = false; //to check if specific drop area is active
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
            if (isActive)
            {
                dropAreaImage.color = originalColor;
                dropOutline.color = originalOutlineColor;
                isActive = false;
                Debug.Log($"Remove Highlight {gameObject.name}");
            }
        }

        private void HighlightDropArea()
        {
            if (!isActive)
            {
                dropAreaImage.color = dropColor;
                dropOutline.color = outlinecolor;
                isActive = true;
                Debug.Log($"Highlight {gameObject.name}");
            }
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
