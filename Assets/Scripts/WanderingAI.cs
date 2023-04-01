using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] float _defaultSpeed = 3f;
    float _speed;
    [SerializeField] float _obstacleRange = 5f;
    public bool Alive;

    bool canShoot = false;

    void Start()
    {
        if (gameObject.GetComponent<EnemyShoot>() != null)
            canShoot = true;
        _speed = _defaultSpeed;
        Alive = true;
    }
    void Update()
    {
        if (Alive)
        {
            Wandering();
        }
    }
    void Wandering()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        CheckWalls();
    }
    void CheckWalls()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        _speed = _defaultSpeed;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>() && canShoot == true)
            {
                _speed = 0f;
            }
            else if (hit.distance < _obstacleRange)
            {
                ReactToWall();
            }
        }
    }
    void ReactToWall()
    {
        float angle = Random.Range(1, 3);
        transform.Rotate(0, 90 * angle, 0);
    }
}
