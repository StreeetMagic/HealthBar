using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider _slider;
    [SerializeField] public Health _health;

    private float _recoveryRate = 50;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }
    
    private void OnHealthChanged(float value)
    {
        StartCoroutine(Draw(value));
    }
        
    private IEnumerator Draw(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = (Mathf.MoveTowards(_slider.value, value, Time.deltaTime * _recoveryRate));
            yield return null;
        }
    }
}
