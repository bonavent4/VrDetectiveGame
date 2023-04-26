using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PickUp : MonoBehaviour
{
    [SerializeField] XRController RightHandController;
    [SerializeField] InputHelpers.Button button;
    bool hitAButton;

    //[SerializeField] GameObject RightController;
    //[SerializeField] Material CubeMat;

    bool hittingSomething;

    GameObject item;
    bool isHoldingSomething;

    bool touchingSnapingPoint;

    GameObject snapThing;

    [SerializeField] LayerMask nonTouch;
    [SerializeField] LayerMask DoTouch;

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
        //Debug.Log(other.gameObject.name);
        
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
       
    }
}
