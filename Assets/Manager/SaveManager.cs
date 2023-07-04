using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
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

    }
}
