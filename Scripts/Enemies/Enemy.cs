using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{

    [Header("Enemy Props")]
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private SpriteRenderer _sp;


    public float Health {get; set;}
    public float Damage {get; set;}
    public Sprite EnemySprite {get; set;}
    public AnimationClip IdleAnim {get; set;}
    public AnimationClip WalkAnim {get; set;}
    public AnimationClip AttackAnim {get; set;}
    public AnimationClip DieAnim {get; set;}


    public void Init()
    {
        //Classic props Init

        Health = _enemyType.Health;
        Damage = _enemyType.Damage;
        EnemySprite = _enemyType.EnemySprite;
        _sp.sprite = EnemySprite;


        //Animation Init
        IdleAnim = _enemyType.AnimationType.Idle;
        WalkAnim = _enemyType.AnimationType.Walk;
        AttackAnim = _enemyType.AnimationType.Attack;
        DieAnim = _enemyType.AnimationType.Die;

    }

    public void TakeDamage(float damage, Vector3 point)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {
        
    }

}
