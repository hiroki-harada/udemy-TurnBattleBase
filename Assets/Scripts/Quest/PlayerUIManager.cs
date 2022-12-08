using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Text hpText;
    public Text atText;

    public void SetupUI(PlayerManager player)
    {
        hpText.text = $"HP : {player.hitPoint}";
        atText.text = $"AT : {player.attackPower}";
    }

    public void UpdateUI(PlayerManager player)
    {
        hpText.text = $"HP : {player.hitPoint}";
    }
}