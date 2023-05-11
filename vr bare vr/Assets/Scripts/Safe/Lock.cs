using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject destroyThis;
    [SerializeField] Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            anim.SetBool("Open", true);

            Destroy(destroyThis);
        }
    }
}
