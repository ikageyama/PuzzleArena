using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour,PDamageIF
{
    // [SerializeField] List<Button> enemybutton = new List<Button>();

    public List<bool> isAlive = new List<bool>();
    public bool isAction = false;

    [SerializeField] int playerInt;

    [SerializeField] Image hpGage;

    [SerializeField] PlayerDataAsset playerDataAsset;


    public void AddDamage(int damage,int playerindex)
    {
        int defence = (int)(playerDataAsset.playerdataList[playerindex].Def * 0.5f);
        playerDataAsset.playerdataList[playerindex].HP -= damage - defence;
        Debug.Log(damage);
        Debug.Log(playerindex);
        if (playerDataAsset.playerdataList[playerindex].HP < 0)
        {
            isAlive[playerindex] = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StatusValue(playerDataAsset.playerdataList[playerInt].MaxHP, playerDataAsset.playerdataList[playerInt].HP, hpGage));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(int enemyindex,int damage, int playerindex)
    {
        //stagemanagerから判定を取る
        GetComponent<StageManager>().enemyobj[enemyindex].gameObject.GetComponent<EDamageIF>().AddDamage(damage, playerindex);
    }

    //ステータスの値の変更を検知
    IEnumerator StatusValue(int maxvalue, int value, Image statusGage)
    {
        int beforeValue = value;
        //Debug.Log(beforeValue);
        //Debug.Log(value);
        yield return new WaitForSeconds(1f);
        if (beforeValue != value)
        {
            Debug.Log(value);
            float percent = value / maxvalue;

            statusGage.fillAmount = percent;

        }
    }
}
