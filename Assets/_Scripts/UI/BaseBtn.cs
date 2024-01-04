using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected TMP_Text _text;
    public abstract void OnClick();

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

}
