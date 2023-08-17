using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationSpeed;
    private Vector3 rotationAxis;
    void Start()
    {
        rotationAxis = Vector3.right;
    }

    void Update()
    {
        transform.Rotate(rotationAxis * RotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
}
