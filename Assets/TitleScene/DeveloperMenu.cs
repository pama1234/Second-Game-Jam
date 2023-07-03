using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMenu : TitleMenuBase<DeveloperMenu>
{
    public void InitDialog()
    {

    }
    public override void OnBackPressed()
    {
        Close();
    }
}
