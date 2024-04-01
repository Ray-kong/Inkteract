using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite unpushedSprite;
    public Sprite pushedSprite;
    public GameObject[] doors; 

    private DoorController doorController;
    [SerializeField]
    private int pushSpeed;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (doors.Length > 0)
        {
            if (doors[0].GetComponent<DoorController>().isOpen)
            {
                spriteRenderer.sprite = pushedSprite;
            }
            else
            {
                spriteRenderer.sprite = unpushedSprite;
            }
        } else
        {
            spriteRenderer.sprite = unpushedSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            foreach (GameObject door in doors)
            {
                door.GetComponent<DoorController>().OpenDoor();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            foreach (GameObject door in doors)
            {
                door.GetComponent<DoorController>().CloseDoor();
            }
        }
    }
}
