using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void ContinueButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
    }
}
