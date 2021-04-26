using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private ShipDeepController _shipDeepController;

    void Start()
    {
        ReloadText();
    }

    void Update()
    {
        ReloadText();
    }

    private void ReloadText()
    {
        _text.text = _shipDeepController.GetCurrentDeep() + "ft";
    }
}
