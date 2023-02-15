using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatmanager : MonoBehaviour
{

    public static combatmanager instance;
    public float maxdamage = 10;
    public characterbattle Characterbattle;
    public float punchvar;
    public molehealth mllhealth;

    public float punchdamage;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mllhealth = GameObject.Find("mole enemy(Clone)").GetComponent<molehealth>();
        Characterbattle = GameObject.Find("playerCombat(Clone)").GetComponent<characterbattle>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.mllhealth.Molehealth);
        //Debug.Log(punchdamage);
    }

    

    public void Missed()
    {
        Debug.Log("Missed");
        

    }

    public void Normalhit()
    {
        punchvar = maxdamage * 0.15f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        Destroy(gameObject);
        Characterbattle.OkPunch();

    }

    public void Goodhit()
    {
        Debug.Log("Good my dude");
        punchvar = maxdamage * 0.3f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        Destroy(gameObject);
        Characterbattle.GoodPunch();
        

    }

    public void Perfecthit()
    {
        Debug.Log("Perfect boi");
        punchvar = maxdamage * 0.4f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        Destroy(gameObject);
        Characterbattle.PerfectPunch();
    }

    public void Missedhit()
    {
        punchvar = maxdamage * 0f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        Destroy(gameObject);
        Characterbattle.MissedPunch();
    }

    public void Hit()
    {
        Debug.Log("Hit on time");
        //Characterbattle.Punch();


    }
}
