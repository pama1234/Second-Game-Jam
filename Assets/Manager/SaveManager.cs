using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    public void SaveSettings()
    {
        //每次都在返回开头界面的时候进行一次检查
        //TO DO: 当我们已经存在json文件的时候按配置好的来

        //当我们不存在json文件，创建新的
        //SaveWriter.Create("Settings")
    }
    public void LoadSettings()
    {

    }
    //进行增删查改的功能操作
    private const string _defaultExtension = ".json";
    private static string StorageLocation
    {
        get
        {
            return Application.persistentDataPath;
        }
    }
    private static string BasePath => Path.Combine(StorageLocation, "Save");
    private static void CreateRootFolder()
    {
        if (!Directory.Exists(BasePath))
        {
            Directory.CreateDirectory(BasePath);
        }
    }

}
