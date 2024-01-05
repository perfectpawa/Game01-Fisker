using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : BaseBtn
{
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _inGameCanvas;

    public override void OnClick()
    {
        _mainMenuCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(true);
        GameManager.Instance.ChangeGameState(GameState.InGame);
    }
}
