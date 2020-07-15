using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NoAmmoDisplay : MonoBehaviour
{
    public float destroyTime;
    public Color txtColor;

    private TextMeshProUGUI _ammoText;

    void Awake()
    {
        _ammoText = GetComponent<TextMeshProUGUI>();
        _ammoText.text = "NO AMMO!";
        _ammoText.color = txtColor;
        StartCoroutine(Animate());
        Destroy(gameObject, destroyTime);
    }

    IEnumerator Animate()
    {
        LeanTween.scale(gameObject, new Vector3(3f,3f,3f), destroyTime);
        yield return new WaitForSeconds(destroyTime);
        StopCoroutine(Animate());
    }
}
