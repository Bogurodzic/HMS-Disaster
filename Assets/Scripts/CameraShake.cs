using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public float camShakeDuration;
    public float camShakeAmount;
    public float decrementFactor;

    private Vector3 _cameraOriginalPoint;
    void Start()
    {
        _cameraOriginalPoint = transform.position;
    }

    void Update()
    {
        if (camShakeDuration > 0)
        {
            camTransform.localPosition = new Vector3(_cameraOriginalPoint.x *  Random.insideUnitSphere.x + camShakeAmount, _cameraOriginalPoint.y *  Random.insideUnitSphere.y + camShakeAmount,_cameraOriginalPoint.z);
            camShakeDuration -= Time.deltaTime * decrementFactor;
        }
        else
        {
            camShakeDuration = 0f;
            camTransform.localPosition = _cameraOriginalPoint;
        }
    }

    public void Shake()
    {
        camShakeDuration = 1;
    }
}
