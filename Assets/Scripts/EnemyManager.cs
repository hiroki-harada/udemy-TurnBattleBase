using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Action onClickAction;

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
        if (hitPoint <= 0) hitPoint = 0;
        Debug.Log($"Enemy's HP was {hitPoint}");
            
    }

    public void AddEventListenerOnClick(Action action)
    {
        onClickAction += action;
    }

    public void OnClick()
    {
        Debug.Log("Enemy was Clicked");
        onClickAction();
    }

}
