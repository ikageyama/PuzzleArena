using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnOrderManager : MonoBehaviour
{

    [SerializeField] EnemyDataAsset enemyDataAsset;
    [SerializeField] PlayerDataAsset playerDataAsset;

    [SerializeField] StageManager stagemanager;

    public List<(int speed, GameObject actor)> turnOrderList = new List<(int speed, GameObject actor)>();

    [SerializeField] List<int> random = new List<int>();
    public void TurnOrder()
    {
        turnOrderList.Clear();

        for(int i = 0; i < random.Count; i++)
        {
            random[i] = Random.Range(60, 140);
        }

        //プレイヤー
        turnOrderList.Add((playerDataAsset.playerdataList[0].Speed * random[0], stagemanager.playerobj[0]));
        turnOrderList.Add((playerDataAsset.playerdataList[1].Speed * random[1], stagemanager.playerobj[1]));
        //敵
        foreach (var enemyobj in stagemanager.enemyobj)
        {
            int enemySpeed = enemyDataAsset.enemydataList[enemyobj.GetComponent<EnemyManager>().enemytype].Speed * 100;
            turnOrderList.Add((enemySpeed, enemyobj));
        }

        turnOrderList = turnOrderList.OrderByDescending(enemy => enemy.speed).ToList();
    }

    //ゲームオブジェクトをスピードの上から順に並べる
    public List<GameObject> GetTurnOrderObjects()
    {
        return turnOrderList.Select(entry => entry.actor).ToList();
    }
}
