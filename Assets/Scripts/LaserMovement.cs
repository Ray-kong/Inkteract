using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject[] doors;
    bool onSensor;

    private void Start()
    {
        onSensor = false;
    }

    void Update()
    {

        // Check for obstacles in the path of the laser
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        lineRenderer.SetPosition(0, transform.position + new Vector3(0,0.5f,0));

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("LaserSensor"))
            {
                if (!onSensor)
                {
                    onSensor = true;
                    // Laser hit an obstacle, perform desired action (e.g., stop the laser)
                    // You can add code here to handle the obstacle interaction
                    Debug.Log("Laser hit a sensor!");
                    foreach (GameObject door in doors)
                    {
                        door.GetComponent<DoorController>().OpenDoor();
                    }
                }
            }
            else
            {
                if (hit.collider.CompareTag("Player"))
                {
                    GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().TriggerLevelLost();
                }
                onSensor = false;
                foreach (GameObject door in doors)
                {
                    door.GetComponent<DoorController>().CloseDoor();
                }
            }
            
        } else
        {
            lineRenderer.SetPosition(1, transform.up * 100);
            onSensor = false;
            foreach (GameObject door in doors)
            {
                door.GetComponent<DoorController>().CloseDoor();
            }
        }
    }
}
