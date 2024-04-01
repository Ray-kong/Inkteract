using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Vector3 initialPosition;
    public float slideSpeed = 2.0f;
    public float slideDistance;
    public bool slideIsUpwards = true;

    public bool isOpen = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isOpen)
            if (slideIsUpwards)
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition + new Vector3(0, slideDistance, 0), Time.deltaTime * slideSpeed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition - new Vector3(0, slideDistance, 0), Time.deltaTime * slideSpeed);
            }
        else
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * slideSpeed);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
