using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Configuration", menuName = "ScriptableObjects/Configuration", order = 1)]
public class Configuration : ScriptableObject
{
    [Range(0, 720)]
    public float maxAngle = 360f;
}
