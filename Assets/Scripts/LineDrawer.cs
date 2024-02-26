using System.Collections.Generic; // Import this for using List and Queue
using UnityEngine;

public class LinesDrawer : MonoBehaviour {

    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    private int _cantDrawOverLayerIndex;

    [Space (30f)]
    public Gradient gravityLineColor;
    public Gradient antiGravityLineColor;
    private Gradient _lineColor;
    public float linePointsMinDistance;
    public float lineWidth;
    
    

    // Add a queue to hold lines
    private readonly Queue<Line> _linesQueue = new Queue<Line>();
    public int maxLines = 5; // Maximum number of lines before we start erasing the old ones

    private Line _currentLine;
    private Camera _cam;

    void Start() {
        _lineColor = gravityLineColor;
        _cam = Camera.main;
        _cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _lineColor = _lineColor.Equals(gravityLineColor) ? antiGravityLineColor : gravityLineColor;
        }
        if (Input.GetMouseButtonDown(0)) {
            BeginDraw();
        }

        if (_currentLine != null) {
            Draw();
        }

        if (Input.GetMouseButtonUp(0)) {
            EndDraw();
        }
    }
    
    #region Draw
    void BeginDraw() {
        _currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        //Set line properties
        _currentLine.UsePhysics(false);
        _currentLine.SetLineColor(_lineColor);
        _currentLine.SetPointsMinDistance(linePointsMinDistance);
        _currentLine.SetLineWidth(lineWidth);

        // Check if we need to remove the oldest line
        if (_linesQueue.Count >= maxLines) {
            Line oldestLine = _linesQueue.Dequeue();
            Destroy(oldestLine.gameObject);
        }

        _linesQueue.Enqueue(_currentLine);
    }
    // Draw ----------------------------------------------------
    void Draw() {
        Vector2 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
/* TODO: Fix Wrong Layer Error. most likely this is happening cause of  wrong parameter in Physics2D.CircleCast

        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);
        if (hit) {
            Debug.Log($"Hit: {hit.collider.name}, Layer: {LayerMask.LayerToName(hit.collider.gameObject.layer)}");
            EndDraw();
        } else */ 

            _currentLine.AddPoint(mousePosition);
    }

    // End Draw ------------------------------------------------
    void EndDraw ( ) {
        if ( _currentLine != null ) {
            if ( _currentLine.pointsCount < 2 ) {
                //If line has one point
                Destroy ( _currentLine.gameObject );
            } else {
                //Add the line to "CantDrawOver" layer
                _currentLine.gameObject.layer = _cantDrawOverLayerIndex;

                //Activate Physics on the line
                if(_lineColor.Equals(gravityLineColor))
                    _currentLine.UsePhysics ( true );

                _currentLine = null;
            }
        }
    }
    
    #endregion
    
    # region Debug
    void OnDrawGizmos() {
        if (_cam != null) {
            Vector2 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(mousePosition, lineWidth / 3f);
        }
    }
    #endregion

}