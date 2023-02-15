using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCanvasScript : MonoBehaviour
{
    public GameObject PopupLamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LampPopup()
    {
        PopupLamp.gameObject.SetActive(true);
    }
}
