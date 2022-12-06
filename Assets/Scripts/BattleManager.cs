using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public UnitManager player;
    public UnitManager enemy;
    void Start()
    {
        player.Attack(enemy);
        enemy.Attack(player);
    }
}