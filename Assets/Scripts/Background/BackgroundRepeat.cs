using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float backgroundSpeed;
    
    private Vector3 _initialPosition;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    void Start()
    {
        _initialPosition = gameObject.transform.position;
    }

    void Update()
    {
        TranslateBackground();
        RepeatBackground();
    }

    public void TranslateBackground()
    {
        transform.Translate(0, backgroundSpeed * Time.deltaTime, 0);
    }

    public void RepeatBackground()
    {
        if ((_initialPosition.y + transform.position.y) >= _boxCollider2D.size.y / 2)
        {
            transform.position = _initialPosition;
        }
    }
}
