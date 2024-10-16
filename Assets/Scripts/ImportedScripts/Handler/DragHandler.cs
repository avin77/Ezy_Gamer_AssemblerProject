using UnityEngine;
using UnityEngine.EventSystems;

namespace ezygamer.DropNDrag
{
    //This class handle the drag logic of the GameObject
    //to the strategy defined by IDragHandler
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
       
        //it used for handling the drag operations 
        public IDragStrategy dragStrategy;

        //if the gamobject is UI element or Not
        [SerializeField] bool isUI;

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
            
        }

        //when usen begins dragging a gameobject
        //if dragStrategy is assigned.
        public void OnBeginDrag(PointerEventData eventData) => dragStrategy?.OnBeginDrag(eventData);

        //when user is dragging the GameObject
        //if dragStrategy is assigned.
        public void OnDrag(PointerEventData eventData) => dragStrategy?.OnDrag(eventData);
        //when the user stops dragging the GameObject
        //if dragStrategy is assigned.
        public void OnEndDrag(PointerEventData eventData) => dragStrategy?.OnEndDrag(eventData);
    }

}
