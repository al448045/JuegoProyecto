using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject
{
    [field: SerializeField] public GameObject[] EnemiesInWave { get; private set; }
    [field: SerializeField] public WaveManager waveManager;

}
