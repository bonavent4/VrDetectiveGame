using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rotate : MonoBehaviour
{
    [SerializeField] XRController xrController;
    [SerializeField] InputHelpers.Axis2D analogstick;
    Vector2 analogdata;

    [SerializeField] Camera cam;
    [SerializeField] GameObject Player;

    [SerializeField] float speed;

    Quaternion rotation;

    private void Start()
    {

    }

    private void Update()
    {
        xrController.inputDevice.TryReadAxis2DValue(analogstick, out analogdata);

        // if(analogdata.x > 0 | analogdata.y > 0)
        //{
        //  Debug.Log(analogdata.x);
        // Player.transform.position.x += analogdata.x * speed * Time.deltaTime;
        rotation.eulerAngles += new Vector3(0, analogdata.x * speed * Time.deltaTime, 0);
        Player.transform.rotation = rotation;
        //Player.transform.position += cam.transform.right * analogdata.x * speed * Time.deltaTime;
        //}

    }
}
