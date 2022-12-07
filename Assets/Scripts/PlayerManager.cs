using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hitPoint;
    public int attackPower;

    public void Attack(EnemyManager enemy)
    {
        enemy.OnGotDamage(attackPower);
    }

    public void OnGotDamage(int damage)
    {
        hitPoint -= damage;
        Debug.Log($"Player's HP was {hitPoint}");
    }
}