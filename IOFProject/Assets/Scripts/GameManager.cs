using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;
    public GameObject AleCombatText;
    public characterbattle Charbtl;
    public bool hasAle = false;
    public bool hasCoin = false;
    public Item Cheese;
    public Item Ale;
    public Item Mouse;
    public Item HealthPotion;
    public playermovement plymvt;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
        hasAle = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayItems();
    }

    // Update is called once per frame
    void Update()
    {
        Charbtl = GameObject.Find("playerCombat(Clone)").GetComponent<characterbattle>();
    }
    private void DisplayItems()
    {
 

        for(int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
            //Update slots item image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //Update slots count text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //Update close/throw button
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
            //Update slots item image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

            //Update slots count text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

            //Update close/throw button
            slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        if(!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("You already have this one!");
            for(int i = 0; i< items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItems();
    }
    public void RemoveItem(Item _item)
    {
        if(items.Contains(_item))
        {

            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }

                }
            }
        }
        else{
            Debug.Log("There is no" + _item + " in my bags");
        }
        DisplayItems();



    }
    public void AleInteractCombat()
    {
        if(hasAle)
        {
            Debug.Log("Aletime");
            StartCoroutine(AleInteractCom());
            hasAle = false;
            instance.RemoveItem(Ale);
        }
        
    }

    IEnumerator AleInteractCom()
    {
        AleCombatText.SetActive(true);
        Charbtl.CanEnemy1Attack = false;
        yield return new WaitForSecondsRealtime(2);
        AleCombatText.SetActive(false);
    }

    public void GiveMouseCheese()
    {
        instance.RemoveItem(Cheese);
        instance.AddItem(Mouse);
    }

    public void UseMouse()
    {
        instance.RemoveItem(Mouse);
    }

    public void HealthPotionCombat()
    {
        if (instance.items.Contains(HealthPotion))
        {
            Debug.Log("HealthTime");
            Charbtl.FindItemsUI();
            instance.RemoveItem(HealthPotion);
            plymvt.playerhealth += 8f;
            Charbtl.WaitingTimeStartItemUse();
            
        }

    }
}
