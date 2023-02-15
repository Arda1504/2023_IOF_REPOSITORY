using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterbtl : MonoBehaviour
{
    public characterbattle Chbtl;
    public Button thisbutton;
    public int ButtonNumber;
    // Start is called before the first frame update
    void Start()
    {
        thisbutton.onClick.AddListener(Clicked);
        Chbtl = GameObject.Find("playerCombat(Clone)").GetComponent<characterbattle>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clicked()
    {
        switch (ButtonNumber)
        {
            case 1:
                Chbtl.SetEnemypicked1();
                break;
            case 2:
                Chbtl.SetEnemypicked2();
                break;
            case 3:
                Chbtl.SetEnemypicked3();
                break;
        }
            
    }
    
    
}
