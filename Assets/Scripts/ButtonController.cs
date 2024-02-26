using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    private DoorController doorController;
    public Vector3 pressedPosition;
    private Vector3 initialPosition;
    [SerializeField]
    private int pushSpeed;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (doorController.isOpen)
            transform.position = Vector3.Lerp(transform.position, pressedPosition, Time.deltaTime * pushSpeed);
        else
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * pushSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            doorController.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            doorController.CloseDoor();
        }
    }
}
