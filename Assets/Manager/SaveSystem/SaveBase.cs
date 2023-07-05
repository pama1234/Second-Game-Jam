using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System;

public abstract class SaveBase
{
    protected JObject _items;
    protected string _root;
    protected SaveSettings _settings;
    public bool Exist(string key)
    {
        return _items[key] != null;
    }
    protected void Load(bool rootMightNotExist)
    {
        var json = FileAccess.LoadString(_root, false);
    }
    protected void Save()
    {
        string json = null;
        try
        {
            json = JsonSerialiser.Serialize(_items);
        }
        catch (Exception e)
        {
            Debug.LogError("Serialization failed");
        }
        if(!FileAccess.SaveString(_root, false, json))
        {
            Debug.LogError("Failed to write to file");
        }
    }

}
