using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //�p�Y���Q�[���̃X�R�A
    public int pazzleScore;

    //�X�e�[�W��
    public int stagecount;

   // public GameObject playerobj;

    //�X�e�[�W�̏I���t���O
    public bool stagefinish;
    //�^�[���̏I���t���O
    public bool turnfinish;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }

    void Click()
    {
        var mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            var h = Physics.RaycastAll(ray, 100.0f);//�Փ˂����Q�[���I�u�W�F�N�g�����m
        }
    }
}
