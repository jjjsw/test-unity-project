using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public float minY = -60f;
    public float maxY = 60f;

    private float rotationY; // pitch (up/down)
    private float rotationX; // yaw (left/right)

    private Quaternion initialRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Store initial rotation set in the editor
        initialRotation = transform.localRotation;

        // Initialize rotation values from current rotation
        Vector3 euler = transform.localEulerAngles;
        rotationX = euler.y;
        rotationY = euler.x;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        // Apply rotation starting from initial rotation
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.right);
        transform.localRotation = initialRotation * xQuaternion * yQuaternion;
    }
}
