using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighlightWorldspaceText : MonoBehaviour,ILootable
{
    private TextMeshPro _txt;
    public Color txtColor;

    void Awake()
    {
        _txt = GetComponent<TextMeshPro>();
    }
    public void OnStartLook()
    {
        _txt.color = txtColor;
    }

    public void OnInteract()
    {

    }
    public void OnEndLook()
    {
        _txt.color = Color.white;
    }

}
