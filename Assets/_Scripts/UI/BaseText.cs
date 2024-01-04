using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public TMP_Text Text { get => _text; set => _text = value; }
}
