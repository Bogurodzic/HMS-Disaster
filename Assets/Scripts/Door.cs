using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject exitDoors;
    public DoorFloor doorFloor;
    [SerializeField] private GameObject _doorIndicator;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowDoorIndicator()
    {
        _doorIndicator.SetActive(true);
    }

    public void HideDoorIndicator()
    {
        _doorIndicator.SetActive(false);
    }
}
