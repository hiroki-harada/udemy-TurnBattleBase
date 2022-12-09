using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public AudioSource BGMSpeaker;
    public AudioClip[] BGMSource;
    public AudioSource SESpeaker;
    public AudioClip SESource;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlayBGM(string sceneName)
    {
        BGMSpeaker.Stop();

        switch (sceneName)
        {
            default:
            case "Title":
                BGMSpeaker.clip = BGMSource[0];
                break;
            case "Town":
                BGMSpeaker.clip = BGMSource[1];
                break;
            case "Quest":
                BGMSpeaker.clip = BGMSource[2];
                break;
            case "Battle":
                BGMSpeaker.clip = BGMSource[3];
                break;
        }

        BGMSpeaker.Play();
    }

    public void PlaySE()
    {
        SESpeaker.PlayOneShot(SESource);
    }
}
