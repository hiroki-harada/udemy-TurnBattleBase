using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;

    int[] encountEnemyTable = { -1, -1, -1, 0, -1, 0, -1,};

    int currentStageNumber = 0;
    void Start()
    {
        stageUI.UpdateUI(++currentStageNumber);
    }

    public void OnNextButton()
    {
        stageUI.UpdateUI(++currentStageNumber);

        if (currentStageNumber >= encountEnemyTable.Length) Debug.Log("This Quest Was Cleared !");
        else if (encountEnemyTable[currentStageNumber] == 0) EncountEnemy();
    }

    void EncountEnemy()
    {
        stageUI.SwitchButtonActivate();
        GameObject enemyObj = Instantiate(enemyPrefab);
        battleManager.Setup(enemyObj.GetComponent<EnemyManager>());
    }
}