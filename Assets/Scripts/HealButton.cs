using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private float healValue = 10;
    
    public void OnButtonClick()
    {
        _health.Change(healValue);
    }
}
