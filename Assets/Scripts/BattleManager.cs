using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public UnitManager player;
    public UnitManager enemy;
    void Start() {}

    public void OnAttackButton()
    {
        player.Attack(enemy);
        enemy.Attack(player);
    }
}