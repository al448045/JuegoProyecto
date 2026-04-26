using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject
{
    [field: SerializeField] public List<GameObject> EnemiesInWave { get; private set; }
    [field: SerializeField] public float WaveTimeToBeat { get; private set; }
}
