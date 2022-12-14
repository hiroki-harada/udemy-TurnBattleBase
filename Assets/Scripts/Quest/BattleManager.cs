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

    bool isEnableAttackToEnemy;

    void Start()
    {
        enemyUI.gameObject.SetActive(false);
        isEnableAttackToEnemy = true;
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
        if (!isEnableAttackToEnemy) return;
        StopAllCoroutines();
        isEnableAttackToEnemy = false;

        SoundManager.instance.PlaySE(1);
        int damage = player.Attack(enemy);
        enemyUI.UpdateUI(enemy);

        DialogTextManager.instance.DisplayScenarios(new string[] {
            $"Player attacked a Monster !\nMonster got {damage} damages !"
        });

        if (enemy.hitPoint > 0)
        {
            StartCoroutine(EnemyTurn());
            return;
        }

        StartCoroutine(EndBattle());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlaySE(1);

        int damage = enemy.Attack(player);

        DialogTextManager.instance.DisplayScenarios(new string[] {
            $"Monster attacked the Player !\nPlayer got {damage} damages !"
        });

        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
        isEnableAttackToEnemy = true;

        if (player.hitPoint <= 0) {
            StartCoroutine(OnLostBattle());
        }
    }

    IEnumerator OnLostBattle()
    {
        yield return new WaitForSeconds(2f);

        DialogTextManager.instance.DisplayScenarios(new string[] {
            "You have no strength to fight left ..."
        });

        yield return new WaitForSeconds(3f);
        questManager.OnFailedQuest();
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);

        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);

        isEnableAttackToEnemy = true;
        SoundManager.instance.PlayBGM("Quest");

        DialogTextManager.instance.DisplayScenarios(new string[] {
            "The Monster ran away ..."
        });

        questManager.RestartExploring();
    }
}