using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> ballPrehab = new List<GameObject>();
    [SerializeField] Transform generatorTrans;

    [SerializeField] int maxball;

    [SerializeField] BallManager ballmanager;

    enum BallColor
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BallInstance());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ballgenerator()
    {
        int colortype = Random.Range(0, ballPrehab.Count);
        GameObject ballobj = Instantiate(ballPrehab[colortype], generatorTrans);
        ballobj.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, 0, UnityEngine.Random.Range(-60.0f, 60.0f)) * Vector3.down * 10f, ForceMode.Impulse);

    }

    IEnumerator BallInstance()
    {
        while (true)
        {
            if(ballmanager.existball < maxball)
            {
                Ballgenerator();
                ballmanager.existball++;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

}
