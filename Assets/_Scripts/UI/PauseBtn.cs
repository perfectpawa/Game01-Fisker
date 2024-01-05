using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : BaseBtn
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Canvas _inGameCanvas;

    public override void OnClick()
    {
        _pauseCanvas.gameObject.SetActive(true);
        _inGameCanvas.gameObject.SetActive(false);
        GameManager.Instance.ChangeGameState(GameState.Pause);
    }
}