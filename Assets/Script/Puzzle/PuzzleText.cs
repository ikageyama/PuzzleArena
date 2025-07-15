using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleText : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> puzzle_text = new List<TextMeshProUGUI>();  

    [SerializeField] GManager gm;
    [SerializeField] PuzzleManager pm;
    enum TextName
    {
        score,
        combo,
        time,
        technique,//ÉXÉLÉãÅAãZ
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puzzle_text[(int)TextName.score].text = "Score: " + gm.pazzleScore;
        puzzle_text[(int)TextName.combo].text = "Combo: " + pm.combo;
        puzzle_text[(int)TextName.time].text = "Time: " + pm.time;
        puzzle_text[(int)TextName.technique].text = "" + pm.techniqueName;
    }
}
