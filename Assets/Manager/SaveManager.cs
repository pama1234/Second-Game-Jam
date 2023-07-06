using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    public void Init()
    {
        if (!SaveWriter.LoadString("Settings.json"))
        {
            //���Ȳ����ڣ������SaveWriterд��Ĭ�ϻ�����
            SaveWriter.Create("Settings")
                      .Write("ResoOpt", "highReso")
                      .Write("SizeOpt", "highSize")
                      .Write("LangOpt", "engLang")
                      .Commit();
        }
        //��ϵͳ��ʼ����ʱ���ȡ�ļ�
        LoadSettings();
    }
    public void SaveSettings(List<string> settingsPref)
    {
        SaveWriter.Create("Settings")
                  .Write("ResoOpt", settingsPref[0])
                  .Write("SizeOpt", settingsPref[1])
                  .Write("LangOpt", settingsPref[2])
                  .Commit();
    }
    public void LoadSettings()
    {
        SaveReader.Create("Settings")
                  .Read<string>("ResoOpt", (r) =>
                    {
                        if (r == "highReso") Screen.SetResolution(1920, 1080, true);
                        else if (r == "lowReso") Screen.SetResolution(1280, 720, true);
                    })
                   .Read<string>("SizeOpt", (r) =>
                    {
                        if (r == "highSize") Screen.fullScreen = true;
                        else if (r == "lowReso") Screen.fullScreen = false;
                    })
                    .Read<string>("LangOpt", (r) =>
                    {
                        if (r == "engLang") LanguageManager.Instance.nowOption = LanguageOption.English;
                        else if (r == "chnLang") LanguageManager.Instance.nowOption = LanguageOption.Chinese;
                    });
    }
}
