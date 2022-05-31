using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider _slider;
    [SerializeField] public Health _health;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }
    
    private void OnHealthChanged(float health)
    {
        StartCoroutine(ChangeHealth(health));
    }
        
    private IEnumerator ChangeHealth(float health)
    {
        while (_slider.value != _health.Value)
        {
            _slider.value = (Mathf.MoveTowards(_slider.value, _health.Value, Time.deltaTime * _health.RecoveryRate));
            yield return null;
        }
    }
}
