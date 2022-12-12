using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public QuestManager questManager;
    public PlayerManager player;
    public PlayerUIManager playerUI;
    public Transform playerDamagePanel;
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
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hitPoint > 0)
        {
            StartCoroutine(EnemyTurn());
            return;
        }

        StartCoroutine(EndBattle());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySE(1);

        enemy.Attack(player);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);

        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.RestartExploring();
    }
}