using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReader : SaveBase
{
    private SaveReader(string root, SaveSettings settings)
    {
        _root = root;
        _settings = settings;
    }

}
