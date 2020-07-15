using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    protected int score;
    [SerializeField] private TextMeshPro _scoreText;

    void Awake ()
    {
        instance = this;
    }

    public void AddScore (int add)
    {
        score += add;
        _scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        _scoreText.text = score.ToString();
    }
}
