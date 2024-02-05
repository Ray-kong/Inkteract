using UnityEngine;
 
public class DrawManager : MonoBehaviour {
    private Camera _cam;
    [SerializeField] private Line linePrefab;
    // affects how densely points are placed on the line.
    public const float Resolution = .1f;
 
    private Line _currentLine;
    void Start()
    {
        _cam = Camera.main;   
    }
 
 
    void Update() {
        // Converts the mouse position from screen coordinates to world coordinates.
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        // Instantiates a new Line prefab at the mouse position with no rotation.
        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
 
        // Updates the current line's position with the new mouse position.
        if(Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);
    }
}