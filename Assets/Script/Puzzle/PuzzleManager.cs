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
    //�v���C����
    public int time;
    //�R���{�p������
    int comboLimitTime = 0;
    //�A��
    public int combo;
    //�Z��
    public string techniqueName;
    //�X�g���[�g���̔���
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
            var h = Physics.RaycastAll(ray, 100.0f);//�Փ˂����Q�[���I�u�W�F�N�g�����m

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
                var h = Physics.RaycastAll(ray, 100.0f);//�Փ˂����Q�[���I�u�W�F�N�g�����m

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
            // �ŏ��̃{�[���� Y ���W���擾���āA���̃{�[���Ɣ�r
            float yPos = touchBallList[0].transform.position.y;
            // �ŏ��̃{�[���� X ���W���擾���āA���̃{�[���Ɣ�r
            float xPos = touchBallList[0].transform.position.x;

            // Y ���W�̍����m�F����t���O
            straightX = true;
            // Y ���W�̍����m�F����t���O
            straightY = true;

            foreach (GameObject destroyball in touchBallList)
            {
                // �e�{�[���� X,Y ���W�̍��� 0.1 �𒴂��Ă���ꍇ�A�t���O�� false �ɂ���
                if (Mathf.Abs(destroyball.transform.position.x - xPos) > 2f)
                {
                    straightX = false;
                    break; // �����ɍ���Ȃ��ꍇ�̓��[�v���I��
                }
            }

            foreach (GameObject destroyball in touchBallList)
            {
                // �e�{�[���� X,Y ���W�̍��� 0.1 �𒴂��Ă���ꍇ�A�t���O�� false �ɂ���
                if (Mathf.Abs(destroyball.transform.position.y - yPos) > 2f)
                {
                    straightY = false;
                    break; // �����ɍ���Ȃ��ꍇ�̓��[�v���I��
                }
            }

            if (straightX)
            {
                //��������}�e���A��������
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
                //��������}�e���A��������
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
            //��������}�e���A��������
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
