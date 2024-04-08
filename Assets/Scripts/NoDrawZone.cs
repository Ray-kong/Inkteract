using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnMouseEnter()
    {
        LinesDrawer._isOverNoDraw = true;
    }

    private void OnMouseExit()
    {
        LinesDrawer._isOverNoDraw = false;
    }
}
