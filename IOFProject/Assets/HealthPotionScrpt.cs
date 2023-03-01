using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotionScrpt : MonoBehaviour
{
    public Button HealthPotionButton;
    public GameManager Gamemger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        HealthPotionButton = this.gameObject.GetComponent<Button>();
        Gamemger = GameObject.Find("GameManager").GetComponent<GameManager>();
        HealthPotionButton.onClick.AddListener(HealthPotionTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HealthPotionTask()
    {
        Gamemger.HealthPotionCombat();
    }
}
