using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //パズルゲームのスコア
    public int pazzleScore;

    //ステージ数
    public int stagecount;

   // public GameObject playerobj;

    //ステージの終了フラグ
    public bool stagefinish;
    //ターンの終了フラグ
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
            var h = Physics.RaycastAll(ray, 100.0f);//衝突したゲームオブジェクトを検知
        }
    }
}
