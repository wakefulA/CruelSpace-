using TMPro;
using UnityEngine;

public class UltaLabel : MonoBehaviour
{
    private TextMeshProUGUI _ultaPercentLabel;
    private SpecialForces _specialForces;
    private void Awake()
    {
        _ultaPercentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _specialForces = FindObjectOfType<SpecialForces>();
        _specialForces.OnUltaPercentChoose += ChangeScore;
    }

    private void ChangeScore(int percent)
    {
        _ultaPercentLabel.text = $"ULTA GO: {percent} %";
    }
}