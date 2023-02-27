using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterbattle : MonoBehaviour
{
    //in order to set the animation to walking right:
    //Vector2 Movement = Playermovement.movement;
    //Playermovement.animator.SetFloat("Horizontal", 1);

    private playermovement Playermovement;
    public combatmanager Combatmgr;
    public molehealth mlhealth;
    public molehealth mlhealth2;
    public molehealth mlhealth3;
    public GameObject player;
    public float punchvar;
    public float punchdamage;
    public float maxdamage = 10;
    public Animator anim;
    public battlehandler btlhand;
    public GameObject moleattack1holder;
    public GameObject moleattack1;
    public moleattack1combatmger mlatk1mger;
    private float saveddamagevar;
    public GameObject damagenumberprefab;
    private GameObject damagenumber;
    public bool CanEnemy1Attack = true;
    public GameObject CombtMenu;
    public AudioSource Audiosource;
    public AudioClip OkAudio;
    public AudioClip PerfectAudio;
    public AudioClip MissedAudio;
    public AudioClip EnemyMissed;
    public AudioClip Enemyweakhit;
    public int EnemyAmount = 3;
    int amountAttacked = 0;
    public float Enemypicked;
    public Button LeftSelect;
    public Button MidSelect;
    public Button RightSelect;

    public float playerhealth;

   


    private void Awake()
    {
        Playermovement = GetComponent<playermovement>();
        CombtMenu = GameObject.Find("CombatMenu");
        amountAttacked = 0;
        
    }

    private void Start()
    {
        mlhealth = btlhand.CloneMole.GetComponent<molehealth>();
        mlhealth2 = btlhand.CloneMoleTwo.GetComponent<molehealth>();
        mlhealth3 = btlhand.CloneMoleThree.GetComponent<molehealth>();
        //mlhealth.Molehealth = 2f;
        //Debug.Log(Combatmgr.punchdamage);
        //playerhealth = 10f;
        btlhand.playerhealth = 10f;
        CanEnemy1Attack = true;
        

    }

    private void Update()
    {


        /* if (mlhealth.Molehealth <= 0f)
         {
             //Destroy(mlhealth);
             mlhealth.Die();
         } */
        //Debug.Log(Combatmgr.punchdamage);
        //Debug.Log(mlhealth.Molehealth);
        

    }

    public void GetAttacked()
    {
        if(CanEnemy1Attack == true && EnemyAmount > 0 /*&& mlhealth.Molehealth > 0*/)
        {
            GameObject Moleattack1object = Instantiate(moleattack1, new Vector3(6.21f, 0.36f, 0), Quaternion.identity);
            mlatk1mger = Moleattack1object.GetComponent<moleattack1combatmger>();
            mlatk1mger.chrbtl = this;
            if(btlhand.FlokiFight == true)
            {
                mlatk1mger.FlokiFight = true;
            }

            GameObject Moleattack1holder = Instantiate(moleattack1holder, new Vector3(-3.5f, 0.36f, 0), Quaternion.identity);
            mlatk1mger.mlattackhlder = Moleattack1holder.gameObject;
            //btlhand.playerhealth -= 1f;
            Debug.Log("Attacked");
            //Debug.Log(btlhand.playerhealth);
            amountAttacked++;
            if (EnemyAmount != amountAttacked)
            {
                StartCoroutine(WaitingtimeTwo());
            }else
            {
                StartCoroutine(Combatmenuappear());
                amountAttacked = 0;
            }




        }
        else
        {
            if(EnemyAmount > 0)
            {
                CombtMenu.gameObject.SetActive(true);
            }

            

        }



    }

    public void Setup(bool isPlayer)
    {
    
        if(isPlayer)
        {
            Vector2 Movement = Playermovement.movement;
            Playermovement.animator.SetFloat("Horizontal", 1);
        }
        else
        {
            Playermovement.animator.SetFloat("Horizontal", -1);
        }

        
    }

    public void EnemyDowned()
    {
        EnemyAmount--;
    }

    

    public void LeftPicked()
    {
        SetEnemypicked1();
    }

    public void MidPicked()
    {
        SetEnemypicked2();
    }

    public void RightPicked()
    {
        SetEnemypicked3();
    }

    public void SetEnemypicked1()
    {
        Enemypicked = 1f;
        Debug.Log("enemy1");
    }

    public void SetEnemypicked2()
    {
        Enemypicked = 2f;
        Debug.Log("enemy2");
    }

    public void SetEnemypicked3()
    {
        Enemypicked = 3f;
        Debug.Log("enemy3");
    }

    public void OkPunch()
    {
        Audiosource.PlayOneShot(OkAudio);
        punchvar = maxdamage * 0.15f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        switch(Enemypicked)
        {
            case 1f:
                Punch();
                break;
            case 2f:
                PunchTwo();
                break;
            case 3f:
                PunchThree();
                break;
        }
        
    }
    public void GoodPunch()
    {
        Audiosource.PlayOneShot(OkAudio);
        punchvar = maxdamage * 0.3f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        switch (Enemypicked)
        {
            case 1f:
                Punch();
                break;
            case 2f:
                PunchTwo();
                break;
            case 3f:
                PunchThree();
                break;
        }
        //anim.Play("Player_walk_up", 0, 1f);

    }
    public void PerfectPunch()
    {
        Audiosource.PlayOneShot(PerfectAudio);
        punchvar = maxdamage * 0.4f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        switch (Enemypicked)
        {
            case 1f:
                Punch();
                break;
            case 2f:
                PunchTwo();
                break;
            case 3f:
                PunchThree();
                break;
        }
    }
    public void MissedPunch()
    {
        Audiosource.PlayOneShot(MissedAudio);
        punchvar = maxdamage * 0f;
        punchdamage = Mathf.Round(punchvar);
        Debug.Log(punchdamage);
        switch (Enemypicked)
        {
            case 1f:
                Punch();
                break;
            case 2f:
                PunchTwo();
                break;
            case 3f:
                PunchThree();
                break;
        }
    }

    IEnumerator Waitingtime()
    {
        yield return new WaitForSecondsRealtime(3);
        GetAttacked();
    }

    IEnumerator WaitingtimeTwo()
    {
        yield return new WaitForSecondsRealtime(3);
        GetAttacked();
    }

    IEnumerator Combatmenuappear()
    {
        yield return new WaitForSecondsRealtime(3);
        CombtMenu.SetActive(true);
    }

    public void Punch()
    {
        // Debug.Log("punched");
        mlhealth.recievedamage(punchdamage);
        Debug.Log(mlhealth.Molehealth);
        //Debug.Log(Combatmgr.punchdamage);

        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(105f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = punchdamage.ToString();
        StartCoroutine(Waitingtime());
        Debug.Log("hitone");

        

        if (mlhealth.Molehealth > 0)
        {
            damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }



    }

    public void PunchTwo()
    {
        // Debug.Log("punched");
        mlhealth2.recievedamage(punchdamage);
        Debug.Log(mlhealth2.Molehealth);
        //Debug.Log(Combatmgr.punchdamage);

        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(155f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = punchdamage.ToString();
        StartCoroutine(Waitingtime());
        Debug.Log("hittwo");

       

        if (mlhealth2.Molehealth > 0)
        {
            damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }



    }

    public void PunchThree()
    {
        // Debug.Log("punched");
        mlhealth3.recievedamage(punchdamage);
        Debug.Log(mlhealth3.Molehealth);
        //Debug.Log(Combatmgr.punchdamage);

        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(300f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = punchdamage.ToString();
        StartCoroutine(Waitingtime());
        Debug.Log("hitthree");

        

        if (mlhealth3.Molehealth > 0)
        {
            damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }



    }



    public void getmlattack1()
    {
        if(mlatk1mger.punchdamage <= 0)
        {
            Audiosource.PlayOneShot(EnemyMissed);
        }
        if (mlatk1mger.punchdamage <= 2 && mlatk1mger.punchdamage > 0)
        {
            Audiosource.PlayOneShot(Enemyweakhit);
        }
        btlhand.playerhealth -= mlatk1mger.punchdamage;
        Debug.Log(btlhand.playerhealth);
        Destroy(mlatk1mger.gameObject);
        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(-165f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = mlatk1mger.punchdamage.ToString();
        damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        //CombtMenu.gameObject.SetActive(true);
    }
}
