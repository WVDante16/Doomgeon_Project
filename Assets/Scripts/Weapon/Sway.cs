using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sway : MonoBehaviour
{
    private Quaternion _OriginLocalRotation;

    private void Start()
    {
        _OriginLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        updateSway();
    }

    private void updateSway()
    {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");
        
        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 1.45f, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(-t_yLookInput * 1.45f, Vector3.right);
        Quaternion t_targerRotation = _OriginLocalRotation * t_xAngleAdjustment * t_xAngleAdjustment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targerRotation, Time.deltaTime * 20f);
            
    }
}
