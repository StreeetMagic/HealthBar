using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public event UnityAction <float> Changed;

    public float _value;
    private int _maxValue = 100;
    
    private void Start()
    {
        _value = _maxValue;
    }

    public void Change(float value)
    {
        _value += value;
        
        if (_value > 100)
            _value = 100;

        if (_value < 0)
        {
            Destroy(gameObject);
        }
        
        Changed?.Invoke(_value);

    }
}
