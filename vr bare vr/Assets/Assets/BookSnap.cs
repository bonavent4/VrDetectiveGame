using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSnap : MonoBehaviour
{
    public GameObject book;
    private bool snapped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == book.name)
        {
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

    public bool IsSnapped()
    {
        return snapped;
    }

    public void DetachBook()
    {
        snapped = false;
    }
}
