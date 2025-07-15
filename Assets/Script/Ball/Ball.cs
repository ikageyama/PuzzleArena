using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isTouch = false;

    [SerializeField] Material touchColor;
    Material ballColor;
    // Start is called before the first frame update
    void Start()
    {
        ballColor = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            gameObject.GetComponent<Renderer>().material = touchColor;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = ballColor;
        }
    }
}
