using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurstomCursor : MonoBehaviour
{
    RectTransform canvasRect;

    // Start is called before the first frame update
    void Start()
    {
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        // Convert mouse position to Canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePosition, null, out Vector2 localPoint);

        // Set the position of the custom cursor to the converted position within the Canvas
        transform.localPosition = localPoint;
    }
}
