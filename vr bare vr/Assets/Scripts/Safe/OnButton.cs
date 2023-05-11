using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButton : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] bool isReturn;

    Animator anim;
    Safe safe;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        safe = FindObjectOfType<Safe>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PickUp>())
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PressButton"))
            {
                Debug.Log("animate button");
                anim.SetTrigger("Press");
                safe.pressed(number, isReturn);
            }
        }
    }
}
