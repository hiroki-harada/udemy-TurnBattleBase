using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject backToTownButton;
    public GameObject questClearText;
    public GameObject questClearImage;

    void Start()
    {
        questClearText.SetActive(false);
        questClearImage.SetActive(false);
    }

    public void UpdateUI(int currentStageNumber)
    {
        stageText.text = $"ステージ : {currentStageNumber}";
    }

    public void SwitchButtonActivate(bool isActive)
    {
        nextButton.SetActive(isActive);
        backToTownButton.SetActive(isActive);
    }

    public void ShowQuestClearText()
    {
        questClearText.SetActive(true);
        questClearImage.SetActive(true);
        nextButton.SetActive(false);
        backToTownButton.SetActive(true);
    }

    public void ShowQuestFailedText()
    {
        nextButton.SetActive(false);
        backToTownButton.SetActive(true); 
    }
}
