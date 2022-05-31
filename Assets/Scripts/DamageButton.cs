using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private float damageValue = -10;

    public void OnButtonClick()
    {
        _health.Change(damageValue);
    }
}
