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
        //在一开始把txt存进gameDict
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
                    line.Trim();//去除首尾的空格
                }
                gameDict.Add(nowLines[0], nowLines[1]);
            }
        }
        //切换语言
        nowOption = LanguageOption.English;
        SwitchLanguage(nowOption);
    }
    private void OnEnable()
    {
        presceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        //当切换场景的时候加载一次，默认为English
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
        //当signal变化的时候加载一次
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
        //判断nowOption与preOption的关系
        if(nowOption == preOption)
        {
            return;
        }
        //先遍历所有的文字
        Scene scene = SceneManager.GetActiveScene();
        List<GameObject> allObj = new List<GameObject>(scene.GetRootGameObjects());
        List<GameObject> newObj = new List<GameObject>();
        //加上它的孙物体，递归查询
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
                //English对应前面的key，Chinese对应后面的value
                //当前是English，想要切换Chinese
                if (changeTo == LanguageOption.Chinese)
                {
                    if (gameDict.ContainsKey(singleText.text))
                    {
                        singleText.text = gameDict[singleText.text];
                    }
                }
                //当前是Chinese，想要切换English
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
