using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] private float _value;

    public event UnityAction<float> Changed;

    private int _maxValue = 100;
    private int _hitDamage = 10;
    private int _healValue = 10;
    private float _recoveryRate = 30;

    public float Value => _value;
    public float RecoveryRate => _recoveryRate;

    private void Start()
    {
        _value = _maxValue;
    }

    public void Heal()
    {
        _value += _healValue;
        Changed?.Invoke(_healValue);

        if (_value > 100)
            _value = 100;
    }

    public void Damage()
    {
        _value -= _hitDamage;
        Changed?.Invoke(_hitDamage);

        if (_value <= 0)
            Destroy(gameObject);
    }
}
