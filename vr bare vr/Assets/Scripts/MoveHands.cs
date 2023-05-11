using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHands : MonoBehaviour
{
    [SerializeField] GameObject handToFollow;

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = (handToFollow.transform.position - gameObject.transform.position) / Time.deltaTime;
    }
}
