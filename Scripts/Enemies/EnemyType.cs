using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/EnemyType", order = 1)]
public class EnemyType : ScriptableObject
{
    public AnimationTypes AnimationType;
    public Sprite EnemySprite;
    public float Health;
    public float Damage;

}
[CreateAssetMenu(fileName = "AnimationTypes", menuName = "ScriptableObjects/AniamtionTypes", order = 1)]
public class AnimationTypes : ScriptableObject
{
    public AnimationClip Idle;
    public AnimationClip Walk;
    public AnimationClip Attack;
    public AnimationClip Die;
}