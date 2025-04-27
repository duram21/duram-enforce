using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public Sprite sprite;
    public string name;
    public float health;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    public EnemyData[] enemyDatas;
}
