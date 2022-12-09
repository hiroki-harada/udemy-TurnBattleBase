using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public QuestManager questManager;
    public PlayerManager player;
    public PlayerUIManager playerUI;
    EnemyManager enemy;
    public EnemyUIManager enemyUI;

    void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }

    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");

        playerUI.SetupUI(player);

        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        enemyUI.gameObject.SetActive(true);
        enemy.AddEventListenerOnClick(AttackToEnemy);
    }

    void AttackToEnemy()
    {
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hitPoint > 0)
        {
            EnemyTurn();
            return;
        }

        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        EndBattle();
    }

    void EnemyTurn()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");

        questManager.RestartExploring();
    }
}