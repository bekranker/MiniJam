using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private Enemy _enemy;


    void Update()
    {
        Move();
    }
    public void Move()
    {
        
    }
    
}