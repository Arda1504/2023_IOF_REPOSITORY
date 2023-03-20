using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCanvasScript : MonoBehaviour
{
    public GameObject HammerButton;
    public GameObject FlameHammerButton;
    public playermovement plymvt;
    // Start is called before the first frame update
    void Start()
    {
        plymvt = GameObject.Find("player 1").GetComponent<playermovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAttacks()
    {
        if(plymvt.HasHammer == false)
        {
            HammerButton.gameObject.SetActive(false);

            FlameHammerButton.gameObject.SetActive(false);
        }
        else
        {
            HammerButton.gameObject.SetActive(true);

            FlameHammerButton.gameObject.SetActive(true);
        }

        if(plymvt.HasLamp == false)
        {
            
            FlameHammerButton.gameObject.SetActive(false);
        }
        else if(plymvt.HasLamp == true && plymvt.HasHammer == true)
        {
            FlameHammerButton.gameObject.SetActive(true);
        }

    }

}
