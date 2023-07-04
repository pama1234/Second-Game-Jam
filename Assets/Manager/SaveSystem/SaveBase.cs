using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
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
        //var json = 
    }
    protected void Save()
    {
        //string json;
    }
}
