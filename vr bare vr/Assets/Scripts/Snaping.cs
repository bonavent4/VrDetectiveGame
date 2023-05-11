using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaping : MonoBehaviour
{

    [SerializeField] int Number;
    GameObject theItem;
  public void Snap(GameObject item)
    {
        theItem = item;
        item.transform.parent = gameObject.transform.parent.transform;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = gameObject.transform.position;

        if(item.GetComponent<Grabable>().theNumber == Number)
        {
            Debug.Log("a Match");
            FindObjectOfType<Manager>().BookInPlace();
            item.GetComponent<Grabable>().snaping = gameObject.GetComponent<Snaping>();
        }
        
    }
    public void offShelf()
    {
        FindObjectOfType<Manager>().BookNotInPlaceAnymore();
        theItem.GetComponent<Grabable>().snaping = null;
    }
}
