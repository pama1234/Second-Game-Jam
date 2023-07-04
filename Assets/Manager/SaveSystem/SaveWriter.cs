using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWriter : SaveBase
{
    private SaveWriter(string root, SaveSettings settings)
    {
        _root = root;
        _settings = settings;
    }
    //����Ϊ��������ڣ���root�洢��Ϣ���ȷ�˵����"Settings"���ߵ�ǰ"SceneName";
    public static SaveWriter Create(string root)
    {
        return Create(root, new SaveSettings());
    }
    public static SaveWriter Create(string root, SaveSettings settings)
    {
        SaveWriter saveWriter = new SaveWriter(root, settings);
        return null;
    }
    public SaveWriter Write<T>(string key, T value)
    {
        _items.Add(key, JsonSerialiser.SerializeKey(value));
        return this;
    }
    public void Commit()
    {

    }
}
