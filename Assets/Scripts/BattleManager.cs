using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public UnitManager player;
    public UnitManager enemy;
    void Start() {}

    public void OnAttackButton()
    {
        player.Attack(enemy);
        if (enemy.hitPoint == 0) RestartBattle();
        enemy.Attack(player);
        if (player.hitPoint == 0) RestartBattle();
    }

    void RestartBattle()
    {
        Debug.Log("the battle was ended !");
        // reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}