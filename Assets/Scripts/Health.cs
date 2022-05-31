using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public event UnityAction Changed;

    private float _value;
    private int _maxValue = 100;
    private float _recoveryRate = 30;

    public float Value => _value;
    public float RecoveryRate => _recoveryRate;

    private void Start()
    {
        _value = _maxValue;
    }

    public void Change(float value)
    {
        _value += value;
        
        Changed?.Invoke();

        if (_value > 100)
            _value = 100;
    }
}
