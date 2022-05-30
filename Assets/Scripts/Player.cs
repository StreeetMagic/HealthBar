using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private int _speed;
    
    private void Start()
    {
        _speed = 5;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);
    }
}
