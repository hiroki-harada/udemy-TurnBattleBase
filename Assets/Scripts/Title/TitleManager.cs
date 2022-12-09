using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
