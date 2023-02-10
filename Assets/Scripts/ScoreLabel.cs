using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI _scoreLabel;
    private Statistics _statistics;

    private void Awake()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _statistics = FindObjectOfType<Statistics>();
        _statistics.OnChangeScore += ChangeScore;
    }

    

    private void ChangeScore()
    {
        _scoreLabel.text = $"Score: {_statistics.Points}";
    }

    //private void Update()
    // {
    //  _scoreLabel.text = $"Score: {Statistics.Instance.Points}";
    // }
}