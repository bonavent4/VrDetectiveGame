using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandle : MonoBehaviour
{
    [SerializeField] Transform target;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(target.transform.position);
    }
}
