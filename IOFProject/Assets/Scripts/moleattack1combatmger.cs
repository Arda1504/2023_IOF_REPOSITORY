using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleattack1combatmger : MonoBehaviour
{
    public static combatmanager instance;
    public float maxdamage = 1;
    public characterbattle Characterbattle;
    public float punchvar;
    public molehealth mllhealth;
    public GameObject holder;
    public GameObject mlattackhlder;
    public characterbattle chrbtl;

    public float punchdamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    

   

    public void Perfecthit()
    {
        Debug.Log("Perfect boi");
        punchvar = maxdamage * 0.3f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);

        Destroy(mlattackhlder.gameObject);
        //Characterbattle.PerfectPunch();
        chrbtl.getmlattack1();
    }

    public void Missedhit()
    {
        punchvar = maxdamage;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);

        Destroy(mlattackhlder.gameObject);

        //Characterbattle.MissedPunch();
        chrbtl.getmlattack1();
    }

    public void Hit()
    {
        Debug.Log("Hit on time");
        //Characterbattle.Punch();

    }
}
