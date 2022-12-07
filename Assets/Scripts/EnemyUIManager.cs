using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    public Text hpText;
    public Text nameText;

    public void UpdateUI()
    {
        hpText.text = $"HP : {hpText}";
    }
}
