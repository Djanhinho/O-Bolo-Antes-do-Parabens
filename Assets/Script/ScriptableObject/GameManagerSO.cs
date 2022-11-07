using UnityEngine;
using ScriptableObjectArchitecture;
using Trisibo;

[CreateAssetMenu]
public class GameManagerSO : ScriptableObject
{
    [Header("Scene Management")]
    public SceneField sceneThingy;

    [Header("Player status")]
    public IntVariable coins;
    
    [Header("Objects values")]
    public GameObjectVariable player;
    public GameObjectVariable enemy;
    public GameObjectVariable[] enemySpawn;

}

