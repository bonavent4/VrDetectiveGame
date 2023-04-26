using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    public bool grapped;

    public int theNumber;

    public Snaping snaping;

    public void TakeOffShelf()
    {
        if(snaping != null)
        {
            snaping.offShelf();
        }
        
    }
}
