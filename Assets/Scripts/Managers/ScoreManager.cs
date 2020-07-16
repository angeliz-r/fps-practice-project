using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    protected int _score;
    protected bool _isStarted;
    [SerializeField] private TextMeshPro _scoreText;
    void Awake ()
    {
        instance = this;
    }

    public void AddScore (int add)
    {
        if (_isStarted)
        {
            _score += add;
            _scoreText.text = _score.ToString();
        }
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    public void ToggleIsStarted(bool x)
    {
        _isStarted = x;
    }
}
