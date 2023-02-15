using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;
     void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
     void Update()
    {
        InventoryControl();
    }
     public void InventoryControl()
     {
    if(Input.GetKeyDown(KeyCode.I))
    {
        if(GameManager.instance.isPaused)
        {
            ResumeInventory();
        }
        else{
            PauseInventory();
        }
    }
     }
     public void ResumeInventory()
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }
     public void PauseInventory()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }
    
}
