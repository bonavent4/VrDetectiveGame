using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSnap : MonoBehaviour
{
    public GameObject book;
    public int snapNumber;
    private bool snapped = false;

    private void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.tag == "PickUp")
            {
                //book.transform.position = transform.position;
                book = other.gameObject;
                snapped = true;
                book.transform.position = transform.position;

            }
        
    
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == book)
        {
            snapped = false;
        }
    }

    public void DetachBook()
    {
        snapped = false;
    }
}
