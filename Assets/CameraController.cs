using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;

    public float LeftBound;
    public float RightBound;

    [HideInInspector]
    Vector3 newPosition;


    private void Start()
    {
        newPosition = transform.position;
    }

    private void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    newPosition += (transform.forward * movementSpeed);
        //}
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    newPosition += (transform.forward * -movementSpeed);
        //}
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (newPosition.x >= LeftBound)
            {
                newPosition += (transform.right * -movementSpeed);
            }
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (newPosition.x <= RightBound)
            {
                newPosition += (transform.right * movementSpeed);
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
