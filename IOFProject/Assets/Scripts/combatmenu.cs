using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatmenuu : MonoBehaviour
{
    public scroller scrler;
    public GameObject crosshairone;
    public GameObject crosshairtwo;
    public Object crsshairtwo;
    public static combatmenuu Instance;

    private void Start()
    {
        Instance = this;
    }

    public void Startpunch()
    {
        this.crsshairtwo = Instantiate(crosshairtwo, new Vector3(0, 0, 0), Quaternion.identity);
        scrler.hasstarted = true;
        Instantiate(crosshairone, new Vector3(0,0,0), Quaternion.identity);
        
    }
}
