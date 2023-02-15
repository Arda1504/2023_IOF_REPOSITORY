using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ShedDialogueScript : MonoBehaviour
{
    
    public Flowchart Flwchrt;
    public playermovement plymvt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Oncollionenter2D(Collider2D collision)
    {
       /* if(collision.tag == "Player")
        {
            plymvt.ToggleMove();
            Flwchrt.SendFungusMessage("ShedDialogue");
        } */
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //plymvt.ToggleMove();
            Flwchrt.SendFungusMessage("ShedDialogue");
        }
    }

    public void destroyitself()
    {
        Destroy(gameObject);
    }
}
