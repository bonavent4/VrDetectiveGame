using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PickUp : MonoBehaviour
{
    [SerializeField] XRController RightHandController;
    [SerializeField] InputHelpers.Button button;
    [SerializeField] bool hitAButton;

    //[SerializeField] GameObject RightController;
    //[SerializeField] Material CubeMat;

    bool hittingSomething;

    GameObject item;
    bool isHoldingSomething;

    bool touchingSnapingPoint;

    GameObject snapThing;

    [SerializeField] LayerMask nonTouch;
    [SerializeField] LayerMask DoTouch;

    // hold a door
    [SerializeField] bool opendoor;
    GameObject DoorHandleHolder;

    bool isOnHand;
    
    

    void Update()
    {
        RightHandController.inputDevice.IsPressed(button, out hitAButton);
        if (hitAButton)
        {
            Debug.Log("pressed: " + button);
        }

        

        if(hittingSomething)
        {
            if (hitAButton)
            {
                if (!isHoldingSomething)
                {
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.parent = gameObject.transform;
                    item.transform.position = gameObject.transform.position;

                    item.GetComponent<Outline>().enabled = false;

                    //item.layer = LayerMask.NameToLayer("NonTouch");

                    item.GetComponent<Grabable>().TakeOffShelf();

                    isHoldingSomething = true;
                }
                
            }
        }
        if (!hitAButton)
        {
           
             if (isHoldingSomething)
            {
                if (touchingSnapingPoint)
                {
                    snapThing.GetComponent<Snaping>().Snap(item);
                }
                else if (item.transform.parent == gameObject.transform)
                {
                        item.transform.parent = null;
                        item.GetComponent<Rigidbody>().isKinematic = false;
                   // item.layer = LayerMask.NameToLayer("smth");

                }
                

               
                


                isHoldingSomething = false;

            }
        }

        // Hold a Door
        if(hitAButton && opendoor && (Vector3.Distance(DoorHandleHolder.transform.position, DoorHandleHolder.transform.parent.transform.position) < 1f))
        {
                DoorHandleHolder.transform.position = gameObject.transform.position;
            isOnHand = true;
        }
        else
        {
            // 
            if (isOnHand)
            {
               // if (DoorHandleHolder != null)
               // {



                    DoorHandleHolder.transform.position = DoorHandleHolder.transform.parent.transform.position;

                    DoorHandleHolder.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    DoorHandleHolder.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    DoorHandleHolder.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    DoorHandleHolder.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    DoorHandleHolder.transform.parent.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    DoorHandleHolder.transform.parent.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    //opendoor = false;
                  //  DoorHandleHolder = null;
                    isOnHand = false;
               // }
            }
            

        }
       /* if ((Vector3.Distance(DoorHandleHolder.transform.position, DoorHandleHolder.transform.parent.transform.position) > 1f))
        {
            opendoor = false;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Grabable>())
        {
            if (!other.gameObject.GetComponent<Grabable>().grapped)
            {
                if (!isHoldingSomething)
                {
                    if (item != null)
                    {
                        item.GetComponent<Outline>().enabled = false;
                    }

                    item = other.gameObject;

                    hittingSomething = true;
                   // Debug.Log("hit something");
                    gameObject.GetComponent<Renderer>().material.color = new Color(255f / 255f, 8f / 255f, 0f / 255f);

                    item.GetComponent<Outline>().enabled = true;

                   // other.gameObject.GetComponent<Grabable>().grapped = true;
                }
            }
        }

        if (other.gameObject.tag == "snapping")
        {
            snapThing = other.gameObject;
            touchingSnapingPoint = true;
            //Debug.Log("snapsmth works");
            
        }


        // Hold A Door
        //if (FindObjectOfType<Safe>().isCorrect)
      //  {
            if (other.gameObject.tag == "HandleHolder")
            {
                Debug.Log("hitDoor");
                DoorHandleHolder = other.gameObject;
                opendoor = true;
            }
      //  }
       
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Grabable>())
        {
            
                hittingSomething = false;
                gameObject.GetComponent<Renderer>().material.color = new Color(24f / 255f, 255f / 255f, 0f / 255f);

                item.GetComponent<Outline>().enabled = false;
            //other.gameObject.GetComponent<Grabable>().grapped = false;


        }
        if (other.gameObject.GetComponent<Snaping>())
        {
            touchingSnapingPoint = false;
        }

        // Hold A Door
       // if (FindObjectOfType<Safe>().isCorrect)
       // {
            if (other.gameObject.tag == "HandleHolder")
            {
                if (!hitAButton)
                {
                    opendoor = false;
                    isOnHand = false;
                    DoorHandleHolder = null;
                }
            }
       // }
       

    }
}
