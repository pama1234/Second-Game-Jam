using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Febucci.UI;
using UnityEngine.SceneManagement;

public class DialogManager : Singleton<DialogManager>
{
    public GameObject textObject;
    public TextMeshProUGUI text;
    public TextAnimator textAnimator;
    public TextAnimatorPlayer textAnimatorPlayer;
    public DialogContent DContent;
    public float textSpeed = 0.05f;
    public bool firstdialogFinished = false;
    public bool isIntroFinished = false;
    public bool textFinished;
    public bool cancelTyping;
    public int index;
    public void Init(string name,DialogContent dialogContent)
    {
        if(name == "Intro")
        {
            textObject = GameObject.FindWithTag("TEXT");
            DContent = dialogContent;
            BeginDialog(DContent);
        }
        if (name == "beforeIntro")
        {
            textObject = GameObject.FindWithTag("BETEXT");
            DContent = dialogContent;
            BeginDialog(DContent);
        }
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "IntroScene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textFinished && !cancelTyping)
                {
                    StartCoroutine(StartDialog(DContent.dialogList));
                }
                else if (!textFinished)
                {
                    cancelTyping = !cancelTyping;
                }
            }
        }
    }
    public void BeginDialog(DialogContent content)
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
        textAnimatorPlayer = textObject.GetComponent<TextAnimatorPlayer>();
        textAnimator = textObject.GetComponent<TextAnimator>();
        index = 0;
        StartCoroutine(StartDialog(content.dialogList));
    }
    public IEnumerator StartDialog(List<string> dialogs)
    {
        if (index < dialogs.Count)
        {
            yield return null;
            textFinished = false;
            text.text = "";
            //while (!cancelTyping && i < dialogs[index].Length)
            //{
            //    text.text += dialogs[index][i];
            //    i++;
            //    AudioManager.Instance.PlaySFX(SoundEffect.Typing);
            //    yield return new WaitForSeconds(textSpeed);
            //}
            text.text = dialogs[index];
            cancelTyping = false;
            textFinished = true;
            index++;
        }else if(index >= dialogs.Count && !firstdialogFinished)
        {
            firstdialogFinished = true;
        }else if(index >= dialogs.Count && !isIntroFinished)
        {
            isIntroFinished = true;
        }
    }
}
