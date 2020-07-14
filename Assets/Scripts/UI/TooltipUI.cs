using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TooltipUI : MonoBehaviour
{
    public static TooltipUI instance;
    private TextMeshProUGUI _tooltipText;


    void Awake()
    {
        instance = this;
        _tooltipText = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<TextMeshProUGUI>();
        _tooltipText.gameObject.SetActive(false);
    }
    public void OnEndLook()
    {
        _tooltipText.gameObject.SetActive(false);
    }
    public void OnStartLook()
    {
        _tooltipText.text = "PRESS " + MovementInput.instance.interact + " TO PICK UP";
        _tooltipText.gameObject.SetActive(true);
    }

}
