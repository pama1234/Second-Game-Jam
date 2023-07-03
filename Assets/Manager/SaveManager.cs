using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    public void SaveSettings()
    {
        //ÿ�ζ��ڷ��ؿ�ͷ�����ʱ�����һ�μ��
        //TO DO: �������Ѿ�����json�ļ���ʱ�����úõ���

        //�����ǲ�����json�ļ��������µ�
        //SaveWriter.Create("Settings")
    }
    public void LoadSettings()
    {

    }
    //������ɾ��ĵĹ��ܲ���
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
