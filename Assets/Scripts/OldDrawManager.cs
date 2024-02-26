using UnityEngine;
 
public class OldDrawManager : MonoBehaviour {
    /*
    private Camera _cam;
    [SerializeField] private Line blueLinePrefab;
    [SerializeField] private Line redLinePrefab;

    private Line currentLine;
    // affects how densely points are placed on the line.
    public const float Resolution = .1f;
 
    private Line _currentLine;
    void Start()
    {
        _cam = Camera.main;
        currentLine = redLinePrefab;
    }
 
 
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            currentLine = currentLine == redLinePrefab ? blueLinePrefab : redLinePrefab;
        }
        
        
        // Converts the mouse position from screen coordinates to world coordinates.
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        // Instantiates a new Line prefab at the mouse position with no rotation.
        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(currentLine, mousePos, Quaternion.identity);
 
        // Updates the current line's position with the new mouse position.
        if(Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);
    }
    */
}