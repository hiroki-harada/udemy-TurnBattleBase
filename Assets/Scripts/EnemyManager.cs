using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public new string name;
    public int hitPoint;
    public int attackPower;

    public void Attack(PlayerManager player)
    {
        player.OnGotDamage(attackPower);
    }

    public void OnGotDamage(int damage)
    {
        hitPoint -= damage;
        Debug.Log($"Enemy's HP was {hitPoint}");
    }

    public void OnClick()
    {
        Debug.Log("Enemy was Clicked");
    }

}
