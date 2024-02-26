using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 openPosition;
    public float slideSpeed = 2.0f;

    private bool isOpen = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isOpen)
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * slideSpeed);
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
