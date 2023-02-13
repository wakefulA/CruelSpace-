using TMPro;
using UnityEngine;

public class UltaLabel : MonoBehaviour
{
    private TextMeshProUGUI _ultaPercentLabel;
    private Ulta _ulta;
    private void Awake()
    {
        _ultaPercentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _ulta = FindObjectOfType<Ulta>();
        _ulta.OnUltaPercentChoose += ChangeScore;
    }

    private void ChangeScore(int percent)
    {
        _ultaPercentLabel.text = $"ULTA GO: {percent} %";
    }
}