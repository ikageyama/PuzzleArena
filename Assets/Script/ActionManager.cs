using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    [SerializeField] EnemyDataAsset enemyDataAsset;

    [SerializeField] List<Button> selectButton = new List<Button>();

    [SerializeField] List<GameObject> actionCanvas = new List<GameObject>();

    [SerializeField] battleManager battleManager;
    enum ActionName
    {
        attack,
        skill,
        defence,
        selectbutton,
        close
    }

    void Start()
    {
        selectButton[(int)ActionName.attack].onClick.AddListener(() => battleManager.actionBool[(int)ActionName.attack] = true);

        selectButton[(int)ActionName.skill].onClick.AddListener(() => battleManager.actionBool[(int)ActionName.skill] = true);

        selectButton[(int)ActionName.defence].onClick.AddListener(() => battleManager.actionBool[(int)ActionName.defence] = true);

        selectButton[(int)ActionName.close - 1].onClick.AddListener(() => {
            actionCanvas[(int)ActionName.attack].SetActive(false);
            actionCanvas[(int)ActionName.skill].SetActive(false);
            actionCanvas[(int)ActionName.defence].SetActive(false);
        });
    }

    //行動選択
    public void ActionSelect(GameObject obj)
    {
        for(int i = 0;i < 3; i++)
        {
            if (battleManager.actionBool[i])
            {
                actionCanvas[i].SetActive(true);
                battleManager.actionBool[i] = false;
            }
        }

        if (obj.CompareTag("Player") && !obj.GetComponent<PlayerManager>().isAction)
        {
            actionCanvas[(int)ActionName.selectbutton].SetActive(true);
            obj.GetComponent<PlayerManager>().isAction = true;
        }

        if (obj.CompareTag("Enemy") && !obj.GetComponent<EnemyManager>().isAction)
        {
            actionCanvas[(int)ActionName.selectbutton].SetActive(false);
            //どちらに攻撃するか
            int playerAttack = Random.Range(0, 2);
            Debug.Log(obj);
            obj.GetComponent<EnemyManager>().isAction = true;
            Debug.Log(obj.GetComponent<EnemyManager>().enemytype);
            var enemyManager = obj.GetComponent<EnemyManager>();
            if (enemyManager == null) Debug.Log("EnemyManger is Null");
            if (enemyDataAsset == null) Debug.Log("EnemyDataAsset is Null");
            obj.GetComponent<EnemyManager>().Attack(enemyDataAsset.enemydataList[obj.GetComponent<EnemyManager>().enemytype].Atk, playerAttack);
        }
    }


    //昼まで　味方の攻撃すべて（スキル含めて）
    //17時まで　タイトル画面作成、全てのUI作成
    //21時まで　音の追加、取り敢えず完成
}
