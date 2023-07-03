using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
public abstract class SaveBase
{
    protected JObject _items;
    protected string _root;
    protected SaveSettings _settings;
    protected void Load(bool rootMightNotExist)
    {
        //var json = 
    }
}
