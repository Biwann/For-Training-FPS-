using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] GameObject _bulletPrefab;
    GameObject _bullet;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_bullet == null)
                {
                    _bullet = Instantiate(_bulletPrefab);

                    _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1f);
                    _bullet.transform.rotation = transform.rotation;
                }
            }
        }
    }
}
