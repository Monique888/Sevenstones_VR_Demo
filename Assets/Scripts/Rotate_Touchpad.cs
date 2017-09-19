using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Touchpad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float rotSpeed = 50;

        if (GvrController.IsTouching)
        {
            Vector2 touchPos = GvrController.TouchPos;

            float rotX = Input.GetAxis("touchDelta.x") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("touchDelta.y") * rotSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotX);
            transform.Rotate(Vector3.right, rotY);
        }
    }
}
