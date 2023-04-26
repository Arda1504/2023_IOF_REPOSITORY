using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlokiSpriteScrpt : MonoBehaviour
{
    public playermovement plymvt;
    // Start is called before the first frame update
    void Start()
    {
        plymvt = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void StopMoving ()
    {
        plymvt.StopMoving();
    }

    public void Moveagain()
    {
        plymvt.MoveAgain();
    }


}
