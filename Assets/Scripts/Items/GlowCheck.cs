using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowCheck : MonoBehaviour
{
    private MeshRenderer _renderer;
    private bool _hasGlow;

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    public void ToggleGlow(bool x)
    {
        if (x)
        {
            _renderer.enabled = false;
            foreach (Transform child in this.transform)
            {
                if (child.gameObject.name == "GlowItem")
                    child.GetComponent<MeshRenderer>().enabled = true;
                _hasGlow = true;
            }
            if (!_hasGlow)
            {
                return;
            }
        }
        else
        {
            _renderer.enabled = true;
            foreach (Transform child in this.transform)
            {
                if (child.gameObject.name == "GlowItem")
                    child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
