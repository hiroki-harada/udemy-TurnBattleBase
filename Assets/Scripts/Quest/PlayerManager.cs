using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hitPoint;
    public int attackPower;

    public int Attack(EnemyManager enemy)
    {
        enemy.OnGotDamage(attackPower);
        return attackPower;
    }

    public void OnGotDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0) hitPoint = 0;
        Debug.Log($"Player's HP was {hitPoint}");
    }
}