using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // status
    public int hitPoint;
    public int attackPower;

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

        if (hitPoint <= 0)
        {
            hitPoint = 0;
            Debug.Log($"{name} was fainted !");
        }
    }
}