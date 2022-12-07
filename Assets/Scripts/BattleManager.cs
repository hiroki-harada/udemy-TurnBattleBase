using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    public PlayerUIManager playerUI;
    EnemyManager enemy;
    public EnemyUIManager enemyUI;

    public void Setup(EnemyManager enemyManager)
    {
        playerUI.SetupUI(player);

        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        enemy.AddEventListenerOnClick(AttackToEnemy);
    }

    void AttackToPlayer()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void AttackToEnemy()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
    }
}