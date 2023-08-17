using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CreateObstacles obstacleCreator;
    [SerializeField] private ShowGameOver canvas;
    private float[] lanes;
    private int currentLaneIndex = 1;
    private float currentSpeed;
    private void Awake()
    {
        currentSpeed = speed;
        lanes = obstacleCreator.GetLanes();
        transform.position = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);
    }
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeToRightLane();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeToLeftLane();
        }
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }
    private void ChangeToRightLane()
    {
        if (currentLaneIndex + 1 < lanes.Length)
        {
            currentLaneIndex++;
            transform.position = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);
        }
    }
    private void ChangeToLeftLane()
    {
        if (currentLaneIndex - 1 >= 0)
        {
            currentLaneIndex--;
            transform.position = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            currentSpeed = 0;
            canvas.ShowGameOverPanel();
        }
    }
}
