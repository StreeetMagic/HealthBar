using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _speed;
    private float _currentHealth;
    private int _maxHealth;
    private int _hitDamage;
    private bool _canChangeHealth;
    private float _healthChangeCooldown;
    private float _recoveryRate;

    private void Start()
    {
        _speed = 5;
        _hitDamage = 10;
        _canChangeHealth = true;
        _healthChangeCooldown = .5f;
        _recoveryRate = 30;
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);

        if (Input.GetKey(KeyCode.F) && _canChangeHealth)
            StartCoroutine(TakeDamage());

        if (Input.GetKey(KeyCode.G) && _canChangeHealth)
            StartCoroutine(Heal());

        _healthBar.SetHealth(Mathf.MoveTowards(_healthBar.GetHealth(), _currentHealth, Time.deltaTime * _recoveryRate));
    }

    private IEnumerator TakeDamage()
    {
        _canChangeHealth = false;
        _currentHealth -= _hitDamage;

        if (_currentHealth <= 0)
            Destroy(gameObject);

        yield return new WaitForSeconds(_healthChangeCooldown);
        _canChangeHealth = true;
    }

    private IEnumerator Heal()
    {
        _canChangeHealth = false;
        _currentHealth += _hitDamage;

        if (_currentHealth > 100)
            _currentHealth = 100;

        yield return new WaitForSeconds(_healthChangeCooldown);
        _canChangeHealth = true;
    }
}
