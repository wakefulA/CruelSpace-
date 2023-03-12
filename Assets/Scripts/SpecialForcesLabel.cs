using TMPro;
using UnityEngine;

public class SpecialForcesLabel : MonoBehaviour
{
    private TextMeshProUGUI _ultaPercentLabel;

    [SerializeField] private SpecialForces _specialForces;

    private void Awake()
    {
        _ultaPercentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _specialForces.OnUltaPercentChoose += ChangeScore;
    }

    private void ChangeScore(int percent)
    {
        _ultaPercentLabel.text = $"Special Forces: {percent} %";
    }
}