using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI _scoreLabel;

    [SerializeField] private Statistics _statistics;

    private void Awake()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _statistics.OnChangeScore += ChangeScore;
        ChangeScore();
    }

    private void ChangeScore()
    {
        _scoreLabel.text = $"Score: {_statistics.Points}";
    }
}