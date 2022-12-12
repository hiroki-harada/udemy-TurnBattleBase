using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

    int[] encountEnemyTable = { -1, -1, -1, 0, -1, 0, -1,};

    int currentStageNumber = 0;
    void Start()
    {
        stageUI.UpdateUI(++currentStageNumber);
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
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
    }

    public void OnBakToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        stageUI.SwitchButtonActivate();
        GameObject enemyObj = Instantiate(enemyPrefab);
        battleManager.Setup(enemyObj.GetComponent<EnemyManager>());
    }

    public void RestartExploring()
    {
        stageUI.SwitchButtonActivate();
    }

    void OnClearedQuest()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        stageUI.ShowQuestClearText();
    }
}