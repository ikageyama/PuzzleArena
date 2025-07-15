using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] List<Button> selectButton = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        //ゲームプレイを開始する
        selectButton[0].onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));

        //ゲームを終了する
        selectButton[1].onClick.AddListener(() =>
        {
             #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
             #else
                        Application.Quit();
             #endif
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
