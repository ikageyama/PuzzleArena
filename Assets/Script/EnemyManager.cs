using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour,EDamageIF
{
    [SerializeField] EnemyDataAsset enemyDataAsset;

    [SerializeField] int hp;

    [SerializeField] int mp;

    [SerializeField] Image hpGage;

    public int enemytype;

    public bool isAlive = true;
    public bool isAction = false;

    public void AddDamage(int damage,int enemyindex)
    {
        int defence = (int)(enemyDataAsset.enemydataList[enemyindex].Def * 0.5f);
        hp -= damage - defence;

        if(hp < 0)
        {
            isAlive = false;
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StatusValue(enemyDataAsset.enemydataList[enemytype].MaxHP,hp,hpGage));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(int playerindex,int damage)
    {
        //var stageManager = GetComponent<StageManager>();
       // if (stageManager == null) Debug.Log("StageManger is null");
        //var player = stageManager.playerobj[playerindex];
       // if (player == null) Debug.Log("Player is null");
       // var playerManager = player.GetComponent<PlayerManager>();
       // if (playerManager == null) Debug.Log("playerMnager is null");
        GetComponent<StageManager>().playerobj[playerindex].GetComponent<PlayerManager>().AddDamage(damage, playerindex);
    }

    //ステータスの値の変更を検知
    IEnumerator StatusValue(int maxvalue,int value, Image statusGage)
    {
        int beforeValue = value;
        yield return new WaitForSeconds(1f);
        if(beforeValue != value)
        {

            float percent = value / maxvalue;

            statusGage.fillAmount = percent;
            
        }
    }
}
 