using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtn : BaseBtn
{
    public override void OnClick()
    {
        GameManager.Instance.ChangeGameState(GameState.Restart);
    }
}
