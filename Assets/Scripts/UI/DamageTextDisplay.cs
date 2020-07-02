using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageTextDisplay : MonoBehaviour
{
    public float destroyTime;
    public Vector3 offset;
    public Color damageColor;

    private TextMeshPro _dmgText;

    void Awake()
    {
        _dmgText = GetComponent<TextMeshPro>();
        transform.localPosition += offset;
        StartCoroutine(Animate());
        Destroy(gameObject, destroyTime);
    }

    public void Initialize(int dmgValue)
    {
        _dmgText.text = dmgValue.ToString();
    }

    IEnumerator Animate()
    {
        LeanTween.moveY(gameObject, offset.y + 1.5f, destroyTime);
        yield return new WaitForSeconds(destroyTime);
        StopCoroutine(Animate());
    }
}
