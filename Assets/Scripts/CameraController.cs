using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    public Pool pool;
    public float movementSpeed;
    public float rotatationSpeed;
    public float movementTime;

    public float LeftBound;
    public float RightBound;

    public Vector3 newPosition;
    public Quaternion newRotation;

    public bool CanMove;

    private void Start()
    {
        CanMove = true;
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
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
            SetMoveDirection(true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            SetMoveDirection(false);
        }

        if (Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width / 2)
        {
            SetMoveDirection(false);
        }
        else if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2)
        {
            SetMoveDirection(true);
        }


        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotatationSpeed);
    }

    private void SetMoveDirection(bool right)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            if (CanMove)
            {
                if (right)
                {
                    if (newPosition.x >= LeftBound)
                    {
                        newPosition += (transform.right * -movementSpeed);
                    }
                }
                else
                {
                    if (newPosition.x <= RightBound)
                    {
                        newPosition += (transform.right * movementSpeed);
                    }
                }
            }
        }
    }
    public void ZoomingCamera(float xPos, float yPos, float zPos, float angle)
    {
        newPosition = new Vector3(xPos, yPos, zPos);
        newRotation = Quaternion.Euler(angle, 0, 0);
    }
}
