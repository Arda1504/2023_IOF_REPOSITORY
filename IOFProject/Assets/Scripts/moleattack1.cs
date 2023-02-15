using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleattack1 : MonoBehaviour
{
    public bool canbepressed;

    public KeyCode keytopress;

    public GameObject Okeffect, Goodeffect, Perfecteffect, Missedeffect;

    public GameObject crosshair2;

    public aim2destroy a2d;

    public moleattack1combatmger combatmger;

    public float punchvar;

    public float punchdamage;

    public combatmenuu combatmen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keytopress))
        {
            if (!canbepressed)
            {
                Destroy(gameObject);
                Debug.Log("Missed boi");
                combatmger.Missedhit();
                Instantiate(Missedeffect, transform.position, Missedeffect.transform.rotation);
                //Destroy(this.combatmen.crsshairtwo);
                combatmger.Hit();


            }
            if (canbepressed)
            {
                //gameObject.SetActive(false);

                combatmger.Hit();

                if (transform.position.x < -4.5f || transform.position.x > -3f)
                {
                    Debug.Log("Hit");
                    combatmger.Missedhit();
                    Instantiate(Missedeffect, transform.position, Missedeffect.transform.rotation);

                }
                else if (transform.position.x < -3.55f)
                {
                    Debug.Log("good");
                    //combatmger.Goodhit();
                    combatmger.Perfecthit();
                    Instantiate(Goodeffect, transform.position, Goodeffect.transform.rotation);

                }
                else  
                {
                    Debug.Log("Perfect");
                    combatmger.Perfecthit();
                    Instantiate(Perfecteffect, transform.position, Perfecteffect.transform.rotation);

                }


            }

        }
        if (transform.position.x < -8f)
        {
            canbepressed = false;
            combatmger.Missedhit();

            //combatmger.Missed();

            //gameObject.SetActive(false);
            Instantiate(Missedeffect, transform.position, Missedeffect.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canbepressed = true;
        }
    }

}
