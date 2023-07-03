using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    List<SettingBtnCust> firstButtons = new List<SettingBtnCust>();
    List<SettingBtnCust> secondButtons = new List<SettingBtnCust>();
    SettingBtnCust[] storageButtons;
    public void SaveSettings()
    {
        //应该传到SaveManager里面，先做简易版（。。）
        foreach (var singleBtn in storageButtons)
        {
            if (singleBtn.isPressed)
            {
                switch (singleBtn.nowOptions)
                {
                    case SettingBtnCust.E_nowOptions.highReso:
                        break;
                    case SettingBtnCust.E_nowOptions.lowReso:
                        break;
                    case SettingBtnCust.E_nowOptions.highSize:
                        break;
                    case SettingBtnCust.E_nowOptions.lowSize:
                        break;
                    case SettingBtnCust.E_nowOptions.EngLang:
                        break;
                    case SettingBtnCust.E_nowOptions.ChnLang:
                        break;
                    default:
                        break;
                }
            }
        }
    }
public void SetButtons()
    {
        Transform[] parentTrans = { gameObject.transform.Find("ResoSetting"),gameObject.transform.Find("SizeSetting"),gameObject.transform.Find("LangSetting")};
        foreach (var singleTrans in parentTrans)
        {
           storageButtons = singleTrans.gameObject.transform.GetComponentsInChildren<SettingBtnCust>();
           firstButtons.Add(storageButtons[0]);
           secondButtons.Add(storageButtons[1]);
        }
        for (int i = 0; i < firstButtons.Count; i++)
        {
            int j = 2 * i;
            firstButtons[i].nowOptions = (SettingBtnCust.E_nowOptions)j;
            firstButtons[i].isFirst = true;
            //注册事件
            firstButtons[i].PressedBtn += SettingPressedBtn;
            firstButtons[i].UnPressedBtn += SettingUnpressedBtn;
            firstButtons[i].HighlightedBtn += SettingHighlightedButton;
        }
        for (int i = 0; i < secondButtons.Count; i++)
        {
            int j = 1 + (2 * i);
            secondButtons[i].nowOptions = (SettingBtnCust.E_nowOptions)j;
            secondButtons[i].isFirst = false;
            //注册事件
            secondButtons[i].PressedBtn += SettingPressedBtn;
            secondButtons[i].UnPressedBtn += SettingUnpressedBtn;
            secondButtons[i].HighlightedBtn += SettingHighlightedButton;
        }
    }
    public void SettingHighlightedButton(SettingBtnCust settingBtnCust)
    {
        if (settingBtnCust.isHighlighted)
        {
            ColorBlock cb = new ColorBlock();
            if (!settingBtnCust.isPressed)
            {
                cb.normalColor = new Color(1f, 1f, 1f, 0.6f); cb.highlightedColor = new Color(1f, 1f, 1f, 0.5f); cb.pressedColor = Color.red; cb.colorMultiplier = 1f; cb.fadeDuration = 0.1f;
                settingBtnCust.colors = cb;
                settingBtnCust.GetComponentInChildren<Text>().color = Color.white;
            }
        }else if (!settingBtnCust.isHighlighted)
        {
            if (!settingBtnCust.isPressed)
            {
                settingBtnCust.GetComponentInChildren<Text>().color = Color.white;
                SettingUnpressedBtn(settingBtnCust);
            }
        }
    }
    public void SettingUnpressedBtn(SettingBtnCust settingBtnCust)
    {
        ColorBlock cb = new ColorBlock();
        cb.normalColor = Color.clear; cb.colorMultiplier = 1f; cb.fadeDuration = 0.1f;
        settingBtnCust.colors = cb;
        settingBtnCust.GetComponentInChildren<Text>().color = Color.white;
    }
    public void SettingPressed(SettingBtnCust settingBtnCust)
    {
        ColorBlock cb = new ColorBlock();
        cb.normalColor = Color.white; cb.selectedColor = new Color(1f, 1f, 1f, 1f); cb.highlightedColor = new Color(1f, 1f, 1f, 1f); cb.pressedColor = Color.red; cb.colorMultiplier = 1f; cb.fadeDuration = 0.1f;
        settingBtnCust.colors = cb;
        settingBtnCust.GetComponentInChildren<Text>().color = Color.black;
    }
    public void SettingPressedBtn(SettingBtnCust settingBtnCust)
    {
        SettingBtnCust targetCust;
        SettingBtnCust untargetCust;
        if (!settingBtnCust.initial)
        {
            //实现二选一
            if (secondButtons.Exists(t => t.Equals(settingBtnCust)))
            {
                int index = secondButtons.FindIndex(t => t.Equals(settingBtnCust));
                targetCust = secondButtons[index];
                targetCust.isPressed = true;
                SettingPressed(targetCust);
                untargetCust = firstButtons[index];
                untargetCust.isPressed = false;
                SettingUnpressedBtn(untargetCust);
            }
            else
            {
                int index = firstButtons.FindIndex(t => t.Equals(settingBtnCust));
                targetCust = firstButtons[index];
                targetCust.isPressed = true;
                SettingPressed(targetCust);
                untargetCust = secondButtons[index];
                untargetCust.isPressed = false;
                SettingUnpressedBtn(untargetCust);
            }//targetCust即为待选择的对象
        }else if (settingBtnCust.initial) {
            SettingPressed(settingBtnCust);
        }

    }
}
