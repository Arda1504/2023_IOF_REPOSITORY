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
    public GameObject ItemUi;

    public GameObject Healthnumberprefab;
    private GameObject Healthnumber;
    public bool HammerAttack = false;
    public bool FlameHammerAttack = false;
    public CameraShakeScript Camshake;
    public GameObject FlameEffect;



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

    public void FindItemsUI()
    {
        ItemUi = GameObject.Find("Items Options");
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
        Camshake = GameObject.Find("combatcam").gameObject.GetComponent<CameraShakeScript>();

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

            //play animation here
            

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
        if (HammerAttack)
        {
            punchdamage = 1f;
            //HammerAttackTime();
            this.anim.Play("HammerFightAnim");
            HammerAttack = false;
        }
        if (FlameHammerAttack)
        {
            punchdamage = 2f;
            //FlameHammerAttackTime();
            this.anim.Play("FireHammerFightAnim");
            FlameHammerAttack = false;
        }
        else
        {
            punchvar = maxdamage * 0.15f;
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
        
    }
    public void GoodPunch()
    {
        Audiosource.PlayOneShot(OkAudio);
        if (HammerAttack)
        {
            punchdamage = 2f;
            //HammerAttackTime();
            this.anim.Play("HammerFightAnim");

            HammerAttack = false;
        }
        if (FlameHammerAttack)
        {
            punchdamage = 3f;
            //FlameHammerAttackTime();
            this.anim.Play("FireHammerFightAnim");

            FlameHammerAttack = false;
        }
        else
        {
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
        }
        //anim.Play("Player_walk_up", 0, 1f);

    }
    public void PerfectPunch()
    {
        Audiosource.PlayOneShot(PerfectAudio);
        if (HammerAttack)
        {
            punchdamage = 3f;
            //HammerAttackTime();
            this.anim.Play("HammerFightAnim");

            HammerAttack = false;
        }
        if (FlameHammerAttack)
        {
            punchdamage = 5f;
            //FlameHammerAttackTime();
            this.anim.Play("FireHammerFightAnim");

            FlameHammerAttack = false;
        }
        else
        {
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
    }
    public void MissedPunch()
    {
        Audiosource.PlayOneShot(MissedAudio);
        if (HammerAttack)
        {
            punchdamage = 0f;
            //HammerAttackTime();
            this.anim.Play("HammerFightAnim");

            HammerAttack = false;
        }
        if (FlameHammerAttack)
        {
            punchdamage = 0f;
            //FlameHammerAttackTime();
            this.anim.Play("FireHammerFightAnim");

            FlameHammerAttack = false;
        }
        else
        {
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
        this.anim.Play("Occam_Attack");
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
        this.anim.Play("Occam_Attack");
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
        this.anim.Play("Occam_Attack");
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

    public void HammerAttackTime()
    {
        if(mlhealth != null)
        {
            mlhealth.recievedamage(punchdamage);
        }
        if (mlhealth2 != null)
        {
            mlhealth2.recievedamage(punchdamage);
        }
        if (mlhealth3 != null)
        {
            mlhealth3.recievedamage(punchdamage);
        }

       
       
        //Debug.Log(Combatmgr.punchdamage);

        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(300f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = punchdamage.ToString();
        GameObject damagenumber2 = Instantiate(damagenumberprefab, new Vector3(155f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext2 = damagenumber2.GetComponent<TextMeshProUGUI>();
        damagenumbertext2.text = punchdamage.ToString();
        GameObject damagenumber3 = Instantiate(damagenumberprefab, new Vector3(105f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext3 = damagenumber3.GetComponent<TextMeshProUGUI>();
        damagenumbertext3.text = punchdamage.ToString();
        btlhand.Plymvt.playerhealth -= 1f;
        GameObject damagenumber4 = Instantiate(damagenumberprefab, new Vector3(-165f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext4 = damagenumber4.GetComponent<TextMeshProUGUI>();
        damagenumbertext4.text = "1";
        damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Camshake.ShakeEvent();

        StartCoroutine(Waitingtime());
        



        if (mlhealth3.Molehealth > 0)
        {
            damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        if (mlhealth2.Molehealth > 0)
        {
            damagenumber2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        if (mlhealth.Molehealth > 0)
        {
            damagenumber3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }

    public void FlameHammerAttackTime()
    {
        if (mlhealth != null)
        {
            mlhealth.recievedamage(punchdamage);
        }
        if (mlhealth2 != null)
        {
            mlhealth2.recievedamage(punchdamage);
        }
        if (mlhealth3 != null)
        {
            mlhealth3.recievedamage(punchdamage);
        }



        //Debug.Log(Combatmgr.punchdamage);

        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(300f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = punchdamage.ToString();
        GameObject damagenumber2 = Instantiate(damagenumberprefab, new Vector3(155f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext2 = damagenumber2.GetComponent<TextMeshProUGUI>();
        damagenumbertext2.text = punchdamage.ToString();
        GameObject damagenumber3 = Instantiate(damagenumberprefab, new Vector3(105f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext3 = damagenumber3.GetComponent<TextMeshProUGUI>();
        damagenumbertext3.text = punchdamage.ToString();
        btlhand.Plymvt.playerhealth -= 2f;
        GameObject damagenumber4 = Instantiate(damagenumberprefab, new Vector3(-165f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext4 = damagenumber4.GetComponent<TextMeshProUGUI>();
        damagenumbertext4.text = "2";
        damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Camshake.ShakeEvent();
        Instantiate(FlameEffect, new Vector3(0f, 0f, -10f), Quaternion.identity);

        StartCoroutine(Waitingtime());
        



        if (mlhealth3.Molehealth > 0)
        {
            damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        if (mlhealth2.Molehealth > 0)
        {
            damagenumber2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        if (mlhealth.Molehealth > 0)
        {
            damagenumber3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
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
        btlhand.Plymvt.playerhealth -= mlatk1mger.punchdamage;
        Debug.Log(btlhand.playerhealth);
        Destroy(mlatk1mger.gameObject);
        GameObject damagenumber = Instantiate(damagenumberprefab, new Vector3(-165f, 50f), Quaternion.identity);
        TextMeshProUGUI damagenumbertext = damagenumber.GetComponent<TextMeshProUGUI>();
        damagenumbertext.text = mlatk1mger.punchdamage.ToString();
        damagenumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        if(btlhand.Plymvt.playerhealth <= 0)
        {
            if(btlhand.FlokiFight)
            {
                btlhand.StartLostFloki();
                //btlhand.Plymvt.Restart();
            }
            else
            {
                btlhand.StartLostTutorial();
            }
            
        }
        //CombtMenu.gameObject.SetActive(true);
    }

    public void WaitingTimeStartItemUse()
    {
        StartCoroutine(Waitingtime());
        ItemUi.SetActive(false);
        GameObject Healthnumber = Instantiate(Healthnumberprefab, new Vector3(-165f, 50f), Quaternion.identity);
        Healthnumber.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    public void ToggleHammerAttack()
    {
        if(HammerAttack == false)
        {
            HammerAttack = true;
        }
        else
        {
            HammerAttack = false;
        }
    }

    public void ToggleFlameHammerAttack()
    {
        if (FlameHammerAttack == false)
        {
            FlameHammerAttack = true;
        }
        else
        {
            FlameHammerAttack = false;
        }
    }
}
