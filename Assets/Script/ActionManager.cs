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

    //�s���I��
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
            //�ǂ���ɍU�����邩
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


    //���܂Ł@�����̍U�����ׂāi�X�L���܂߂āj
    //17���܂Ł@�^�C�g����ʍ쐬�A�S�Ă�UI�쐬
    //21���܂Ł@���̒ǉ��A��芸��������
}
