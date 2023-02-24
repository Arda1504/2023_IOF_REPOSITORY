using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public Flowchart Flowchart;
    public GameObject Popup;
    public playermovement Plymvmt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Destroy(gameObject);
            GameManager.instance.AddItem(itemData);
            if(itemData.itemName == "Ragged Shirt")
            {
                Flowchart.SetBooleanVariable("Shirt", true);
                Popup.gameObject.SetActive(true);
                Plymvmt.HasTunic = true;
            }

            if (itemData.itemName == "Cold Ale")
            {
                Flowchart.SetBooleanVariable("Beer", true);
            }

            if (itemData.itemName == "Cold Ale")
            {
                GameManager.instance.hasAle = true;
            }

            if(itemData.itemName == "Coin")
            {
                GameManager.instance.hasCoin = true;
            }

            if(itemData.itemName == "Cheese")
            {
                Flowchart.SetBooleanVariable("Cheese", true);
            }

            if(itemData.itemName == "Mouse")
            {
                Flowchart.SetBooleanVariable("Mouse", true);
            }
            
        }
    }

}
