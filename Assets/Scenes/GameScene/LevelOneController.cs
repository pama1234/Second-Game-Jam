using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneController : MonoBehaviour
{
    public GameObject levelOneText;
    public GameObject CNTMP, EGTMP;
    public DataController dataController;
    public DialogContent LevelOneCN, LevelOneEg;
    public DialogContent LevelOneUPCN, LevelOneUPEG;
    public GameObject IntroTouch;
    public GameObject IntroTouchTwo;
    public bool onlyOnce = false;
    public bool onlyOnceTW = false;
    public void Start()
    {
        //先把关键参数设置default形态
        CursorManager.Instance.ResetDuality();
        dataController.SetInital();
        IntroTouchTwo.SetActive(false);
        IntroTouch.SetActive(false);
        DialogManager.Instance.isBEfinished = false;
        AudioManager.Instance.StopBGM();
        CursorManager.Instance.ChangeSprite(FingerOption.five);
        AudioManager.Instance.PlayBGM(BackgroundMusic.LevelOneScene);
        if(LanguageManager.Instance.nowOption == LanguageOption.English)
        {
            EGTMP.SetActive(true);CNTMP.SetActive(false);
            DialogManager.Instance.Init("levelOne", LevelOneEg);
        }else if(LanguageManager.Instance.nowOption == LanguageOption.Chinese)
        {
            EGTMP.SetActive(false); CNTMP.SetActive(true);
            DialogManager.Instance.Init("levelOne", LevelOneCN);
        }
    }
    public void Update()
    {
        if (DialogManager.Instance.isBEfinished == true && !onlyOnce)
        {
            if (!IntroTouch.activeInHierarchy)
            {
                IntroTouch.SetActive(true);
                onlyOnce = true;
            }
        }
        else if(!IntroTouch.activeInHierarchy && !onlyOnceTW)
        {
            //下一阶段的对话
            if (LanguageManager.Instance.nowOption == LanguageOption.English)
            {
                EGTMP.SetActive(true); CNTMP.SetActive(false);
                DialogManager.Instance.Init("levelOneTW", LevelOneUPEG);
            }
            else if (LanguageManager.Instance.nowOption == LanguageOption.Chinese)
            {
                EGTMP.SetActive(false); CNTMP.SetActive(true);
                DialogManager.Instance.Init("levelOneTW", LevelOneUPCN);
            }
            IntroTouchTwo.SetActive(true);
            onlyOnceTW = false;
        }
    }
}
