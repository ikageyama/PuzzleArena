using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> touchBallList;

    [SerializeField] Material touchColor;
    Material ballColor;
    //プレイ時間
    public int time;
    //コンボ継続時間
    int comboLimitTime = 0;
    //連鎖
    public int combo;
    //技名
    public string techniqueName;
    //ストレートかの判定
    [SerializeField] bool straightX = false;
    [SerializeField] bool straightY = false;
    [SerializeField] bool straight = false;

    [SerializeField] GManager gm;
    [SerializeField] BallManager ballmanager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Time());
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
            touchBallList = new List<GameObject>();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            var h = Physics.RaycastAll(ray, 100.0f);//衝突したゲームオブジェクトを検知

            for(int i = 0; i < h.Length; i++)
            {
                    if (h[i].collider.tag == "ball" && !h[i].collider.GetComponent<Ball>().isTouch)
                    {
                        h[i].collider.GetComponent<Ball>().isTouch = true;
                        touchBallList.Add(h[i].collider.gameObject);
                    }
            }
 
        }

        if (Input.GetMouseButton(0))
        {
            if(touchBallList.Count != 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(mousePos);
                var h = Physics.RaycastAll(ray, 100.0f);//衝突したゲームオブジェクトを検知

                for (int i = 0; i < h.Length; i++)
                {
                        if (h[i].collider.tag == "ball" && !h[i].collider.GetComponent<Ball>().isTouch
                           && touchBallList[0].name == h[i].collider.name)
                        {
                            h[i].collider.GetComponent<Ball>().isTouch = true;
                            touchBallList.Add(h[i].collider.gameObject);
                        }
                        else if (h[i].collider.tag == "ball" && touchBallList[0].name != h[i].collider.name)
                        {
                            DestroyObject();
                        }

                }

                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        var count = touchBallList.Count;

        if (count >= 5)
        {
            // 最初のボールの Y 座標を取得して、他のボールと比較
            float yPos = touchBallList[0].transform.position.y;
            // 最初のボールの X 座標を取得して、他のボールと比較
            float xPos = touchBallList[0].transform.position.x;

            // Y 座標の差を確認するフラグ
            straightX = true;
            // Y 座標の差を確認するフラグ
            straightY = true;

            foreach (GameObject destroyball in touchBallList)
            {
                // 各ボールの X,Y 座標の差が 0.1 を超えている場合、フラグを false にする
                if (Mathf.Abs(destroyball.transform.position.x - xPos) > 2f)
                {
                    straightX = false;
                    break; // 条件に合わない場合はループを終了
                }
            }

            foreach (GameObject destroyball in touchBallList)
            {
                // 各ボールの X,Y 座標の差が 0.1 を超えている場合、フラグを false にする
                if (Mathf.Abs(destroyball.transform.position.y - yPos) > 2f)
                {
                    straightY = false;
                    break; // 条件に合わない場合はループを終了
                }
            }

            if (straightX)
            {
                //離したらマテリアルを消す
                foreach (GameObject destroyball in touchBallList)
                {
                    destroyball.GetComponent<Ball>().isTouch = false;
                    Destroy(destroyball);
                }
                gm.pazzleScore += count * 15;
                ballmanager.existball -= count;
                combo++;
                comboLimitTime = 0;
                straightX = false;
                straightY = false;
                straight = true;
            }

            if (straightY)
            {
                //離したらマテリアルを消す
                foreach (GameObject destroyball in touchBallList)
                {
                    destroyball.GetComponent<Ball>().isTouch = false;
                    Destroy(destroyball);
                }
                gm.pazzleScore += count * 15;
                ballmanager.existball -= count;
                combo++;
                comboLimitTime = 0;
                straightX = false;
                straightY = false;
                straight = true;
            }
            
        }


        if (count >= 3 && !straight)
        {
            //離したらマテリアルを消す
            foreach (GameObject destroyball in touchBallList)
            {
                 destroyball.GetComponent<Ball>().isTouch = false;
                 Destroy(destroyball);
            }
            gm.pazzleScore += count * 10;
            ballmanager.existball -= count;
            combo++;
            comboLimitTime = 0;
        }
        else
        {
            foreach (GameObject destroyball in touchBallList)
            {
                destroyball.GetComponent<Ball>().isTouch = false;
            }
        }
        straight = false;
        touchBallList.Clear();
    }
    
    IEnumerator Time()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            comboLimitTime++;
            time--;

            if(comboLimitTime > 5)
            {
                combo = 0;
            }
        }

        SceneManager.LoadScene("titleScene");
    }
}
