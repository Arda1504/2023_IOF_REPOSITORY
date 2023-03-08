using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerAttackScrpt : MonoBehaviour
{
    public Button HammerButton;
    public characterbattle chrbtl;
    public bool flame = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        HammerButton = this.gameObject.GetComponent<Button>();
        chrbtl = GameObject.Find("playerCombat(Clone)").GetComponent<characterbattle>();
        HammerButton.onClick.AddListener(HammerTask);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HammerTask()
    {
        if(flame == false)
        {
            chrbtl.HammerAttack = true;
        }
        else
        {
            chrbtl.FlameHammerAttack = true;
        }
    }
}
