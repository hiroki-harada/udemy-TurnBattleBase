using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject backToTownButton;

    public void UpdateUI(int currentStageNumber)
    {
        stageText.text = $"ステージ : {currentStageNumber}";
    }

    public void SwitchButtonActivate()
    {
        nextButton.SetActive(!nextButton.activeSelf);
        backToTownButton.SetActive(!backToTownButton.activeSelf);
    }
}
