using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MianMenu>();
        Close(0);
    }
    public void ReTry()
    {
        LevelManager.Ins.LoadCurrentLevel();
        UIManager.Ins.OpenUI<GamePlay>();
        GameManager.Ins.IsPause = false;
        Close(0);
    }
}
