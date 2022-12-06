using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // status
    int hitPoint;
    int attackPower;

    // attack function
    public void Attack(UnitManager target)
    {
        target.OnGotDamage(attackPower);
    }

    // damage function
    void OnGotDamage(int damage)
    {
        hitPoint -= damage;
        Debug.Log($"{name} got {damage} damages");
    }
}