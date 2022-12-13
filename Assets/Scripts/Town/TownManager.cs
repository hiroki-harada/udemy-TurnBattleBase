using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    void Start()
    {
        DialogTextManager.instance.DisplayScenarios(new string[] {
            "You arrived at the Town."
        });
    }
    public void OnClickToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
