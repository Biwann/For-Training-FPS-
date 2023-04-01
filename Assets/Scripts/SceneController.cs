using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    GameObject _enemy;

    // Update is called once per frame
    void Update()
    {
        EnemySpawner();
    }

    void EnemySpawner()
    {
        if (_enemy == null)
            SpawnEnemy(new Vector3(0, 1, 0));
    }

    void SpawnEnemy(Vector3 position)
    {
        _enemy = Instantiate(_enemyPrefab);
        _enemy.transform.position = position;
    }
}
