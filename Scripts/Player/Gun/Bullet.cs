using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _damage;

    void Start()
    {
        Destroy(gameObject, _lifetime);
    }
    public void Init(Vector2 direction)
    {
        transform.right = direction;
        _rb.velocity = transform.right * _speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable) && !collision.gameObject.CompareTag("Player"))
        {
            damagable.TakeDamage(_damage, transform.position);
            Destroy(gameObject);
        }

    }
}
