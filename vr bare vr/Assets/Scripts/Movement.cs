using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Movement : MonoBehaviour
{
    [SerializeField] XRController xrController;
    [SerializeField] InputHelpers.Axis2D analogstick;
    Vector2 analogdata;

    [SerializeField] Camera cam;
    [SerializeField] GameObject Player;

    [SerializeField] float speed;

    private void Update()
    {
        xrController.inputDevice.TryReadAxis2DValue(analogstick, out analogdata);

        if(analogdata.x > 0)
        {
            // Player.transform.position.x += analogdata.x * speed * Time.deltaTime;
           // Player.transform.forward +=
        }
    }
}
