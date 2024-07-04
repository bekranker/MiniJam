using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrichMachine : MonoBehaviour, IDamagable
{
    [SerializeField] private float _MaxHealth;
    private float _currentHealth;


    void Start()
    {
        Init();
    }


    public void Init()
    {
        _currentHealth = _MaxHealth;
    }
    public void Die()
    {
        
    }

    public void TakeDamage(float damage, Vector3 point)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
            return;
        }
    }
}
