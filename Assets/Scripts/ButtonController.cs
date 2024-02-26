using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    private DoorController doorController;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.OpenDoor();
            Debug.Log("PlayerEnter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.CloseDoor();
        }
    }
}
