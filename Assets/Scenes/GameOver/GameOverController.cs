using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject introSave;
    public GameObject introText;
    bool isSaveEnd = false;
    bool isInit = false;
    public DialogContent BeIntroDialogEn,
                         BeIntroDialogCn,
                         IntroDialogEn,
                         IntroDialogCn;
    public void Start()
    {
        CursorManager.Instance.ChangeSprite(FingerOption.zero);
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayBGM(BackgroundMusic.IntroScene);
        DialogManager.Instance.isIntroFinished = false;
        DialogManager.Instance.firstdialogFinished = false;
    }
    public void PlayTypping()
    {
        AudioManager.Instance.PlaySFX(SoundEffect.Typing);
    }
    public void Update()
    {
        introText.SetActive(true);
        if (LanguageManager.Instance.nowOption == LanguageOption.English)
        {
             DialogManager.Instance.Init("Intro", IntroDialogEn);
        }
         else if (LanguageManager.Instance.nowOption == LanguageOption.Chinese)
         {
                    DialogManager.Instance.Init("Intro", IntroDialogCn);
         }
        if (DialogManager.Instance.isIntroFinished)
        {
            TransManager.Instance.ChangeScene("LevelOne");
        }

    }
}
