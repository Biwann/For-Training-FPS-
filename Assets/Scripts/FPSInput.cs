using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPS Input")]
public class FPSInput : MonoBehaviour
{

    [SerializeField] float _speed = 10f;
    [SerializeField] float _gravity = -9.8f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, _speed);  // ограничение движения по диагонали
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);  // преобразование к глобальным координатам

        _characterController.Move(movement);
    }
}
