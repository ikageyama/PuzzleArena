using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Scriptable/PlayerDataAsset")]
public class PlayerDataAsset : ScriptableObject
{
    public List<PlayerData> playerdataList = new List<PlayerData>();
}

[System.Serializable]
public class PlayerData
{
    [SerializeField] string playername;
    [SerializeField] int maxHP;
    [SerializeField] int hp;
    [SerializeField] int def;
    [SerializeField] int atk;
    [SerializeField] int speed;
    [SerializeField] List<int> skill = new List<int>();


    public string PlayerName => playername;

    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Def
    {
        get { return def; }
        set { def = value; }
    }

    public int Atk
    {
        get { return atk; }
        set { atk = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public List<int> Skill
    {
        get { return skill; }
        set { skill = value; }
    }
}