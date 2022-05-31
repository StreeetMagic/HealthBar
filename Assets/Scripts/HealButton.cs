using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Health _health; 
    
    public void OnButtonClick()
    {
        _health.Heal();
    }
}
