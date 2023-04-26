using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   
     [SerializeField]int howManyBooksNeeded;
    [SerializeField] int booksUHaveInPlace;

    bool done;

    [SerializeField] Animator doorAnim;

    public void BookInPlace()
    {
        booksUHaveInPlace++;
        if(howManyBooksNeeded == booksUHaveInPlace)
        {
            Debug.Log("u have all ín place yep");
            if (!done)
            {
                doorAnim.SetBool("OpenDoor", true);
                done = true;
            }
        }
    }
    public void BookNotInPlaceAnymore()
    {
        booksUHaveInPlace--;
        Debug.Log("minus 1");
    }
}
