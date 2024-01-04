using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : BaseBtn
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Canvas _inGameCanvas;

    public override void OnClick()
    {
        _pauseCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(true);
        Debug.Log("Resume");
    }
}
