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
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.parent = gameObject.transform;
                item.transform.position = gameObject.transform.position;

                isHoldingSomething = true;
            }
        }
        if (!hitAButton)
        {
            if (isHoldingSomething)
            {
                item.transform.parent = null;
                item.GetComponent<Rigidbody>().isKinematic = false;
                

                isHoldingSomething = false;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUp")
        {
            item = other.gameObject;

            hittingSomething = true;
            Debug.Log("hit something");
            gameObject.GetComponent<Renderer>().material.color = new Color(255f / 255f, 8f / 255f, 0f / 255f);

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PickUp")
        {
            hittingSomething = false;
            gameObject.GetComponent<Renderer>().material.color = new Color(24f / 255f, 255f / 255f, 0f / 255f);
        }
       
    }
}
