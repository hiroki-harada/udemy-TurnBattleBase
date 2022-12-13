using System.Collections;
using UnityEngine;
using DG.Tweening;


public class QuestManager : MonoBehaviour
{

    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    public PlayerManager player;
    public PlayerUIManager playerUI;

    int[] encountEnemyTable = { -1, -1, -1, 0, -1, 0, -1,};

    int currentStageNumber = 0;
    void Start()
    {
        stageUI.UpdateUI(++currentStageNumber);
        DialogTextManager.instance.DisplayScenarios(new string[] {
            "You arrived at the forest."
        });

        playerUI.SetupUI(player);
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.DisplayScenarios(new string[] {
            "Searching . . ."
        });

        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale =new Vector3(1f, 1f, 1f));
        (questBG.GetComponent<SpriteRenderer>()).DOFade(/* opacity = */0, /* duration(sec) = */2f)
            .OnComplete(() => (questBG.GetComponent<SpriteRenderer>()).DOFade(/* opacity = */1, /* duration(sec) = */0f));
        yield return new WaitForSeconds(2f);

        stageUI.UpdateUI(++currentStageNumber);
        if (currentStageNumber >= encountEnemyTable.Length) 
        {
            Debug.Log("This Quest Was Cleared !");
            OnClearedQuest();
        }
        else if (encountEnemyTable[currentStageNumber] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.SwitchButtonActivate(true);
        }
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.SwitchButtonActivate(false);
        StartCoroutine(Searching());
    }

    public void OnBakToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.DisplayScenarios(new string[] {
            "A Monster appeared !"
        });

        GameObject enemyObj = Instantiate(enemyPrefab);
        battleManager.Setup(enemyObj.GetComponent<EnemyManager>());
    }

    public void RestartExploring()
    {
        stageUI.SwitchButtonActivate(true);
    }

    void OnClearedQuest()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        DialogTextManager.instance.DisplayScenarios(new string[] {
            @"You found a Chest !!\n
            You should return the Town !"
        });
        stageUI.ShowQuestClearText();
    }

    public void OnFailedQuest()
    {
        stageUI.ShowQuestFailedText();
    }
}