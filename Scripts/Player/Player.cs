using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{


    [Header("Player Props")]
    [SerializeField] private float MaxHealth;
    [Header("Components")]
    [SerializeField] private SpriteRenderer _sp;

    private float _currentHealth;


    void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void Die()
    {
        throw new System.NotImplementedException();
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
    private void TakeDamageEffect()
    {

    }
}
