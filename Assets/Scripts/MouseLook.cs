using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    [SerializeField] RotationAxes _axes = RotationAxes.MouseXAndY;

    [SerializeField] float _sensitivityX = 5f;
    [SerializeField] float _sensitivityY = 5f;

    [SerializeField] float _minimumVert = -90f;
    [SerializeField] float _maximumVert = 90f;

    float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    private void Update()
    {
        switch (_axes)
        {
            case RotationAxes.MouseXAndY:
                MouseXRotation();
                MouseYRotation();
                break;

            case RotationAxes.MouseX:
                MouseXRotation();
                break;

            case RotationAxes.MouseY:
                MouseYRotation();
                break;
        }
    }
    void MouseXRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityX, 0);
    }

    void MouseYRotation()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityY;
        _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);

        float rotationY = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
