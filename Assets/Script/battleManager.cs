using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class battleManager : MonoBehaviour
{
    [SerializeField] EnemyDataAsset enemyDataAsset;
    [SerializeField] PlayerDataAsset playerDataAsset;

    [SerializeField] StageManager stagemanager;

    [SerializeField] GManager gmanager;
    [SerializeField] TurnOrderManager turnOrderManager;
    [SerializeField] ActionManager actionManager;

    List<GameObject> speedList = new List<GameObject>();
    public List<bool> actionBool = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        OrderOfActions();

        //プレイヤーか敵かの判別
        for (int i = 0; i < speedList.Count; i++)
        {
            //Debug.Log(i);
            //Debug.Log(speedList[i]);
            actionManager.ActionSelect(speedList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gmanager.stagefinish || gmanager.turnfinish)
        {
            OrderOfActions();
        }

        if (gmanager.turnfinish)
        {
            //プレイヤーか敵かの判別
            for (int i = 0; i < speedList.Count; i++)
            {
                //Debug.Log(i);
                //Debug.Log(speedList[i]);
                actionManager.ActionSelect(speedList[i]);
            }
        }

    }
    //行動順に並べ替える
    void OrderOfActions()
    {
        speedList.Clear();
        turnOrderManager.TurnOrder();
        turnOrderManager.GetTurnOrderObjects();

        foreach (var obj in turnOrderManager.turnOrderList)
        {
            speedList.Add(obj.actor);
            //Debug.Log(obj.actor);
        }

        gmanager.stagefinish = false;
        gmanager.turnfinish = false;
    }
    /*
    //敵の行動
    public void EnemyAction(GameObject obj)
    {
        int playerAttack = Random.Range(0, 2);

        obj.GetComponent<EnemyManager>().Attack(enemyDataAsset.enemydataList[obj.GetComponent<EnemyManager>().enemytype].Atk, playerAttack);
        
        int actionRandom = Random.Range(1, 101);
        
        if(actionRandom > 60)
        {

        }
    }
    */
}
