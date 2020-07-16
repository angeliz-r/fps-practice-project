using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartGameUI : MonoBehaviour,IDamageable
{
    public TextMeshPro titleText;
    public GameObject startGame;
    public GameObject gameModes;

    public void DealDamage(int damage)
    {
        titleText.text = "SELECT MODE";
        gameModes.SetActive(true);
        startGame.SetActive(false);
    }

}
