using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteobject : MonoBehaviour
{
    public bool canbepressed;

    public KeyCode keytopress;

    public GameObject Okeffect, Goodeffect, Perfecteffect, Missedeffect;

    public GameObject crosshair2;

    public aim2destroy a2d;

    public combatmanager combatmger;

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
                combatmanager.instance.Missedhit();
                Instantiate(Missedeffect, transform.position, Missedeffect.transform.rotation);
                //Destroy(this.combatmen.crsshairtwo);
                

            }
            if (canbepressed)
            {
                gameObject.SetActive(false);

                combatmanager.instance.Hit();

                if(Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("Hit");
                    combatmanager.instance.Normalhit();
                    Instantiate(Okeffect, transform.position, Okeffect.transform.rotation);
                    
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("good");
                    combatmanager.instance.Goodhit();
                    Instantiate(Goodeffect, transform.position, Goodeffect.transform.rotation);
                    
                }
                else
                {
                    Debug.Log("Perfect");
                    combatmanager.instance.Perfecthit();
                    Instantiate(Perfecteffect, transform.position, Perfecteffect.transform.rotation);
                    
                }
                
                
            }
            
        }
        if (transform.position.y < -1.23f)
        {
            canbepressed = false;

            combatmanager.instance.Missedhit();

            gameObject.SetActive(false);
            Instantiate(Missedeffect, transform.position, Missedeffect.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canbepressed = true;
        }
    }
    
   
    
}
