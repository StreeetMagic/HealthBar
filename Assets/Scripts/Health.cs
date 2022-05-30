using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] private float _value;

    public event UnityAction Changed;

    private int _maxValue;
    private int _hitDamage;
    private float _recoveryRate;

    public float Value => _value;
    public float RecoveryRate => _recoveryRate;

    private void Start()
    {
        _hitDamage = 10;
        _recoveryRate = 30;
        _maxValue = 100;
        _value = _maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _value -= _hitDamage;
            Changed?.Invoke();

            if (_value <= 0)
                Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _value += _hitDamage;
            Changed?.Invoke();

            if (_value > 100)
                _value = 100;
        }
    }

}
