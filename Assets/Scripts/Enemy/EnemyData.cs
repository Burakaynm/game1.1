using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyData",menuName = "ScriptableObject/EnemyData",order = 1)]
public class EnemyData : ScriptableObject
{
    public float followDistance = 50f;
    public float speed = 0.005f;
    public float attackRange = 0f;
    public float damage = 0f;
}
