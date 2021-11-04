using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform cameraOrbit;
    public Transform target;

    void Start()
    {
        cameraOrbit.position = target.position;
    }

    void Update()
    {
        var rotation = transform.rotation;
        rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        transform.rotation = rotation;

        transform.LookAt(target.position);
    }
}