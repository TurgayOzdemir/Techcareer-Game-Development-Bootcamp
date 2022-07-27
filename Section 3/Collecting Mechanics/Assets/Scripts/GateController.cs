using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    [SerializeField] TMP_Text _gateValueText = null;
    [SerializeField] private enum gateType
    {
        PositiveGate,
        NegativeGate,
    }
    [SerializeField] private gateType _gateType;

    [SerializeField] private int _gateValue;

    private void Start()
    {
        randomGateNumber();
    }

    public int GetGateValue() { return _gateValue; }

    private void randomGateNumber()
    {
        switch (_gateType)
        {
            case gateType.PositiveGate:
                _gateValue = Random.Range(1, 10);
                _gateValueText.text = _gateValue.ToString();
                break;
            case gateType.NegativeGate:
                _gateValue = Random.Range(-10, -1);
                _gateValueText.text = _gateValue.ToString();
                break;
        }
    }
}
