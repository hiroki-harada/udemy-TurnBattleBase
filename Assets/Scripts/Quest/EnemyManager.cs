using System;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    Action onClickAction;

    public new string name;
    public int hitPoint;
    public int attackPower;
    public GameObject gotDamageEffect;

    public int Attack(PlayerManager player)
    {
        player.OnGotDamage(attackPower);
        return attackPower;
    }

    public void OnGotDamage(int damage)
    {
        Instantiate(gotDamageEffect, this.transform, false);
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
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
