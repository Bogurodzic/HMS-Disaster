using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    [SerializeField] private GameObject _creditsPanel;
    private bool _isActive = false;

    public void ToggleCreditPanel()
    {
        _isActive = !_isActive;
        _creditsPanel.SetActive(_isActive);
    }
}
