using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform targetCamera;
    private Quaternion initialLocalRotation;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main.transform;

        // store manual rotation set in editor
        initialLocalRotation = transform.localRotation;
    }

    void Update()
    {
        // apply camera rotation * initial offset
        transform.rotation = targetCamera.rotation * initialLocalRotation;
    }
}
