using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Scriptable/EnemyDataAsset")]
public class EnemyDataAsset : ScriptableObject
{
    public List<EnemyData> enemydataList = new List<EnemyData>();
}

[System.Serializable]
public class EnemyData
{
    [SerializeField] string enemyname;
    [SerializeField] int maxHP;
    [SerializeField] int def;
    [SerializeField] int atk;
    [SerializeField] int speed;

    public string EnemyName => enemyname;
    public int MaxHP => maxHP;
    public int Def => def;
    public int Atk => atk;
    public int Speed => speed;
}