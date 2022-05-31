using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void OnButtonClick()
    {
        _health.Damage();
    }
}
