using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateValve : MonoBehaviour
{
    private Transform valveToRotate;
    private Vector3 startVectorRotation;

    public Configuration configuration;
    public Camera cam;

    public float currentRotation = .1f;

    void Awake()
    {
        cam = GameObject.Find("FPV Camera").GetComponent<Camera>();
        valveToRotate = transform.GetChild(0).transform;
    }
    
    private void OnMouseUp()
    {
        startVectorRotation = Vector3.zero;
    }

    private void OnMouseDrag()
    {

        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        
        if (Physics.Raycast (ray, out var hitInfo)) 
        {
            //текущий угол поворта модели и вектор, куда поворачивать
            Vector3 currentValveAngles = valveToRotate.eulerAngles;
            Vector3 targetVectorRotation = (hitInfo.point - valveToRotate.position).normalized;
            
            
            // инициализация для начала поворота после нажатия
            if (startVectorRotation == Vector3.zero)
            {
                startVectorRotation = targetVectorRotation;
            }
            
            targetVectorRotation.y = startVectorRotation.y;
            
            // угол между предыдущим и целевым углом (при первом запуске они равны)
            float angleDiff = Vector3.SignedAngle(startVectorRotation, targetVectorRotation, valveToRotate.up);
            
            startVectorRotation = targetVectorRotation;


            bool inAngleRange = (currentRotation + angleDiff >= 0f &&
                                 currentRotation + angleDiff <= configuration.maxAngle);
            if (inAngleRange)
            {
                currentRotation += angleDiff;
                valveToRotate.eulerAngles = new Vector3(currentValveAngles.x, currentValveAngles.y + angleDiff, currentValveAngles.z);    
            }
            
        }
    }
}
