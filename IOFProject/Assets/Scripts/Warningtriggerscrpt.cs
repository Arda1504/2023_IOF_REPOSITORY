using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Warningtriggerscrpt : MonoBehaviour
{

    public GameObject Screen;
    public TextMeshProUGUI ScreenText;
    public playermovement plymvt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Screen.gameObject.SetActive(true);
            ScreenText.text = "You won't be able to return if you go to Floki. Make sure you have what you need";
            plymvt.moveSpeed = 0;
            Destroy(gameObject);
        }
    }
}
