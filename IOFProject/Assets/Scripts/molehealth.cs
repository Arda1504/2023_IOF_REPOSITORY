using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molehealth : MonoBehaviour
{
    public float Molehealth = 2f;
    public static molehealth instance;
    public battlehandler batlehan;
    GameObject CloneMole;
    public characterbattle Chbtl;
    public GameObject PlayerCombatobject;
    public Sprite FlokiGruntSprite;
    public bool IsFloki = false;


    // Start is called before the first frame update
    void Start()
    {
        Molehealth = 2f;
        //instance = this;
        PlayerCombatobject = GameObject.Find("playerCombat(Clone)");
        Chbtl = PlayerCombatobject.GetComponent<characterbattle>();
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Die()
    {
        
            //batlehan.KillMole();
            if(Chbtl.EnemyAmount != 1)
        {
            StartCoroutine(Dying());
           
        }
            else
        {
            if(IsFloki)
            {
                Chbtl.EnemyDowned();
                batlehan.KillFinalFloki();
            }
            else
            {
                Chbtl.EnemyDowned();
                batlehan.KillFinal();
                //batlehan.KillMole();
            }

        }
            //Debug.Log("dead");
        
    }

    public void recievedamage(float damage)
    {
        Molehealth = Molehealth - damage;
        if (Molehealth <= 0f)
        {
            //Destroy(mlhealth);
            Die();
            //Debug.Log("dead");
        }
    }

    IEnumerator Dying()
    {
        Chbtl.EnemyDowned();
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

        yield return new WaitForSecondsRealtime(2);
        Destroy(this.gameObject);
    }

    public void FlokiGrunt()
    {
        Molehealth = 4f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = FlokiGruntSprite;
    }

    public void FlokiHimself()
    {
        Molehealth = 8f;
        IsFloki = true;
    }
}
