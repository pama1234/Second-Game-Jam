using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
public enum LanguageOption
{
    English,
    Chinese,
}
public class LanguageManager : Singleton<LanguageManager>
{
    public LanguageOption nowOption;
    public LanguageOption preOption;
    public bool setChange = false;
    Dictionary<string, string> gameDict;
    string nowsceneName = "";
    string presceneName = "";
    private void Start()
    {
        //��һ��ʼ��txt���gameDict
        gameDict = new Dictionary<string, string>();
        string path = "Language";
        TextAsset targetAsset = Resources.Load<TextAsset>(path);
        string[] lines = targetAsset.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                continue;
            }
            else
            {
                string[] nowLines = lines[i].Split(':');
                foreach (string line in nowLines)
                {
                    line.Trim();//ȥ����β�Ŀո�
                }
                gameDict.Add(nowLines[0], nowLines[1]);
            }
        }
        //�л�����
        nowOption = LanguageOption.English;
        SwitchLanguage(nowOption);
    }
    private void OnEnable()
    {
        presceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        //���л�������ʱ�����һ�Σ�Ĭ��ΪEnglish
        nowsceneName = SceneManager.GetActiveScene().name;
        if(presceneName != nowsceneName)
        {
            presceneName = nowsceneName;
            SwitchLanguage(nowOption);
        }
        if(nowOption != preOption)
        {
            setChange = true;
        }
        //��signal�仯��ʱ�����һ��
        if (setChange)
        {
            setChange = false;
            SwitchLanguage(nowOption);
        }
    }
    private void FindAll(Transform parent, ref List<GameObject> newObj)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform temp = parent.GetChild(i);
            newObj.Add(temp.gameObject);
            if(temp.childCount > 0)
            {
                FindAll(temp, ref newObj);
            }
        }
    }
    private void SwitchLanguage(LanguageOption changeTo)
    {
        //�ж�nowOption��preOption�Ĺ�ϵ
        if(nowOption == preOption)
        {
            return;
        }
        //�ȱ������е�����
        Scene scene = SceneManager.GetActiveScene();
        List<GameObject> allObj = new List<GameObject>(scene.GetRootGameObjects());
        List<GameObject> newObj = new List<GameObject>();
        //�������������壬�ݹ��ѯ
        foreach (GameObject singleObj in allObj)
        {
            newObj.Add(singleObj);
            FindAll(singleObj.transform, ref newObj);
        }
        foreach (GameObject singleObj in newObj)
        {
            Text singleText = singleObj.GetComponent<Text>();
            if(singleText != null && singleText.text != null)
            {
                //English��Ӧǰ���key��Chinese��Ӧ�����value
                //��ǰ��English����Ҫ�л�Chinese
                if (changeTo == LanguageOption.Chinese)
                {
                    if (gameDict.ContainsKey(singleText.text))
                    {
                        singleText.text = gameDict[singleText.text];
                    }
                }
                //��ǰ��Chinese����Ҫ�л�English
                else if (changeTo == LanguageOption.English)
                {
                    string firstKey = gameDict.FirstOrDefault(pair => pair.Value == singleText.text).Key;
                    if(firstKey != null)
                    {
                        singleText.text = firstKey;
                    }
                }
            }
        }
        if (nowOption == LanguageOption.English) preOption = LanguageOption.English;
        else if (nowOption == LanguageOption.Chinese) preOption = LanguageOption.Chinese;
    }
}
