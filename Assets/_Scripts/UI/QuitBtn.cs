using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : BaseBtn
{
    public override void OnClick()
    {
        //if running in Unity Editor, quit play mode else quit application
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                Debug.Log("Quit");
        #else
                Application.Quit();
        #endif

    }
}