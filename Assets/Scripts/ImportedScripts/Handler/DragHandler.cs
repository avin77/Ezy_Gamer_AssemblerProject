using UnityEngine;
using UnityEngine.EventSystems;

namespace ezygamers.dragndropv1
{
    //This class handle the drag logic of the GameObject
    //to the strategy defined by IDragHandler
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
       
        //it used for handling the drag operations 
        public IDragStrategy dragStrategy;

        //if the gamobject is UI element or Not
        [SerializeField] bool isUI;
        //this holds the initial position of the draggable object
        [SerializeField] private GameObject originalPos;

        [SerializeField] private bool toPop;
        public Vector3 targetScale = new Vector3(1.02f, 1.02f, 1.02f);
        public float pulseSpeed = 0.2f;

        private void Start()
        {

            if (isUI)
            {
                //create a new instance of UIDragFactory
                DragStrategyFactory factory= new UIDragFactory();
                //use the factory to create and assign a UIDragStrategy to dragStrategy
                dragStrategy = factory.CreateDraggable(this.gameObject);                
            }

            //TODO:create the strategy for Non UI Gameobject in else block

            if (toPop)
            {
                AnimationHelper.StartPulse(gameObject, targetScale, pulseSpeed);
            }
        }

        //when usen begins dragging a gameobject
        //if dragStrategy is assigned.
        public void OnBeginDrag(PointerEventData eventData)
        {
            AnimationHelper.StopPulse(gameObject);
            dragStrategy?.OnBeginDrag(eventData);
        }


        //when user is dragging the GameObject
        //if dragStrategy is assigned.
        public void OnDrag(PointerEventData eventData) => dragStrategy?.OnDrag(eventData);
        //when the user stops dragging the GameObject
        //if dragStrategy is assigned.
        public void OnEndDrag(PointerEventData eventData)
        {
            dragStrategy?.OnEndDrag(eventData);
            if (toPop)
            {
                AnimationHelper.StartPulse(gameObject, targetScale, pulseSpeed);
            }

            RectTransform draggedRect = this.GetComponent<RectTransform>();
            RectTransform originalRect = originalPos.GetComponent<RectTransform>();
            Vector2 currentPos = draggedRect.anchoredPosition;
            Vector2 targetPos = originalRect.anchoredPosition;

            // Use LeanTween to move to the anchored position
            LeanTween.value(gameObject, currentPos, targetPos, 0.5f)
                     .setOnUpdate((Vector2 pos) => {
                      draggedRect.anchoredPosition = pos;
                     });
        }
    }

}