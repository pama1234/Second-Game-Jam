using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Febucci.UI;

public class DialogManager : Singleton<DialogManager>
{
    public GameObject textObject;
    public TextMeshProUGUI text;
    public TextAnimator textAnimator;
    public TextAnimatorPlayer textAnimatorPlayer;
    public void Init()
    {
        //textObject = GameObject.FindWithTag("TEXT");
        //text = textObject.GetComponent<TextMeshProUGUI>();
        //textAnimatorPlayer = textObject.GetComponent<TextAnimatorPlayer>();
        //textAnimator = textObject.GetComponent<TextAnimator>();
        //text.text = "";
    }
    public void BeginDialog(DialogContent content)
    {
        //StartCoroutine(StartDialog(content));
    }
    public IEnumerator StartDialog(DialogContent content)
    {
        yield return null;
    }
}
