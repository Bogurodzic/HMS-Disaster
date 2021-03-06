using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepText : MonoBehaviour
{
    [SerializeField] private Text _text;

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
        _text.text = Score.deep + "ft";
    }
}
