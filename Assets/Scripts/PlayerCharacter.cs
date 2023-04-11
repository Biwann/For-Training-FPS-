using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private int _health;
    void Start()
    {
        _health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int dmg)
    {
        _health -= dmg;
        Debug.Log("Health: " + _health);
    }
}
