using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public SkinnedMeshRenderer newRenderer;
    private SkinnedMeshRenderer _renderer;
    private bool _hasChange;

    void Awake()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
    }
    public void ToggleMaterialChange(bool x)
    {
        if (x)
        {
            //_renderer.enabled = false;
            newRenderer.enabled = true;
            _hasChange = true;
            if (!_hasChange)
            {
                return;
            }
        }
        else
        {
            //_renderer.enabled = true;
            newRenderer.enabled = false;
        }
    }
}
