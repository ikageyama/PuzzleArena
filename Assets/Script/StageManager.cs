using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    //�G�̃f�[�^
    public List<GameObject> enemyPrehab = new List<GameObject>();

    //�o�Ă���G�̃I�u�W�F�N�g
    public List<GameObject> enemyobj = new List<GameObject>();
    //�o�Ă���v���C���[�̃I�u�W�F�N�g
    public List<GameObject> playerobj = new List<GameObject>();

    [SerializeField] List<Transform> enemytrans = new List<Transform>();
    [SerializeField] List<Transform> playertrans = new List<Transform>();

    [SerializeField] GManager gm; 
    public enum EnemyName
    {
        goblin,
        metbird,
        firebird,
        flamemage,
        demonking
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyGenerate(gm.stagecount);
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W���X�V���邲�ƂɓG���o��������
        if (gm.stagefinish)
        {
            enemyobj.Clear();
            EnemyGenerate(gm.stagecount);
            gm.stagefinish = false;
        }
    }

    void EnemyGenerate(int index)
    {
        if(index == 1)
        {
            enemyobj.Add(enemyPrehab[(int)EnemyName.goblin]);
            enemyobj.Add(enemyPrehab[(int)EnemyName.goblin]);
        }
        else if(index == 2)
        {
            enemyobj.Add(enemyPrehab[(int)EnemyName.goblin]);
            enemyobj.Add(enemyPrehab[(int)EnemyName.metbird]);
        }
        else if (index == 3)
        {
            enemyobj.Add(enemyPrehab[(int)EnemyName.metbird]);
            enemyobj.Add(enemyPrehab[(int)EnemyName.firebird]);
        }
        else if (index == 4)
        {
            enemyobj.Add(enemyPrehab[(int)EnemyName.goblin]);
            enemyobj.Add(enemyPrehab[(int)EnemyName.flamemage]);
        }
        else
        {
            enemyobj.Add(enemyPrehab[(int)EnemyName.firebird]);
            enemyobj.Add(enemyPrehab[(int)EnemyName.demonking]);
        }
        
        for(int i = 0; i < 2; i++)
        {
            Instantiate(enemyobj[i], enemytrans[i]);
        }

        for (int i = 0; i < 2; i++)
        {
            Instantiate(playerobj[i], playertrans[i]);
        }
    }
}
