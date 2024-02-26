using System.Collections.Generic;
using UnityEngine;
 
public class OldLine : MonoBehaviour {
    /*
    [SerializeField] private new LineRenderer renderer;
    [SerializeField] private new EdgeCollider2D collider;
 
    // A list to keep track of the points that make up the line.
    private readonly List<Vector2> _points = new();
    void Start() {
        // Adjusts the collider's position to account for the parent object's position.
        collider.transform.position -= transform.position;
    }
    
 
    public void SetPosition(Vector2 pos) {
        if(!CanAppend(pos)) return;
 
        _points.Add(pos);
 
        renderer.positionCount++;
        renderer.SetPosition(renderer.positionCount-1,pos);
 
        // Updates the collider's points to match the new shape of the line.
        collider.points = _points.ToArray();
    }
 
    private bool CanAppend(Vector2 pos) {
        // If no points have been set, the first point can always be added.
        if (renderer.positionCount == 0) return true;
 
        // Checks if the distance between the last point in the line and the new point is greater than a defined resolution.
        // This prevents points that are too close together from being added, which can improve performance and visual quality.
        return Vector2.Distance(renderer.GetPosition(renderer.positionCount - 1), pos) > OldDrawManager.Resolution;
    }
    */
}