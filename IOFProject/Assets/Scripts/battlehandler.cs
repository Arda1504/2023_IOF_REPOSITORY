using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class battlehandler : MonoBehaviour
{
    [SerializeField] private Transform PlayerBattle;
    //[SerializeField] private Transform MoleBattle;
    public GameObject MoleBtl;
    public GameObject playeroverworld;
    public GameObject CloneMole;
    public GameObject CloneMoleTwo;
    public GameObject CloneMoleThree;
    public spawncombatoverworld spwncmbtow;
    public Camera CombatCam;
    public Camera PlayeroverCam;
    public GameObject battleui;
    public triggercombat trigcmbt;
    public float playerhealth = 10f;
    private AudioSource[] allAudioSources;
    public AudioSource Music;
    public GameObject  healthObject;
    public TextMeshProUGUI healthNumber;
    public GameObject VictoryText;
    public GameObject BlackTrans;
    public GameObject Transspawnpnt;
    public Canvas healthcanvas;
    public AudioClip VictorySound;
    public GameObject LastEnemy;
    public characterbattle Chbtl;
    public GameObject PlayerCombatobject;
    public Button LeftSelect;
    public Button MidSelect;
    public Button RightSelect;



    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    private void Start()
    {
        //PlayeroverCam = playeroverworld.GetComponentInChildren<Camera>();
        SpawnCharacter(true);
        PlayeroverCam.enabled = true;
        CombatCam.enabled = false;
        battleui.SetActive(false);

        Debug.Log("combat cam is" + CombatCam.gameObject.name);
        healthNumber = healthObject.gameObject.GetComponent<TextMeshProUGUI>();

        PlayerCombatobject = GameObject.Find("playerCombat(Clone)");
        Chbtl = PlayerCombatobject.GetComponent<characterbattle>();
    }

    private void Update()
    {
        healthNumber.SetText(playerhealth.ToString());
    }

    public void KillFinal()
    {
        //PlayeroverCam = playeroverworld.GetComponentInChildren<Camera>();
        //StartCoroutine(Victory()); uncomment this plz

        LastEnemy = GameObject.Find("mole enemy(Clone)");
        StartCoroutine(Victory());

    }

   



    private void SpawnCharacter(bool isPlayer)
    {
        Vector3 position;
        if(isPlayer)
        {
            position = new Vector3(-3.5f, 1);
        }else
        {
            position = new Vector3(2f, 1);
        }
      
        //Instantiate(MoleBattle, new Vector3(3.5f, 1), Quaternion.identity);
        CloneMole = Instantiate(MoleBtl, new Vector3(2f, 1), Quaternion.identity);
        CloneMole.GetComponent<molehealth>().batlehan = this;
        CloneMoleTwo = Instantiate(MoleBtl, new Vector3(4f, 1), Quaternion.identity);
        CloneMoleTwo.GetComponent<molehealth>().batlehan = this;
        CloneMoleThree = Instantiate(MoleBtl, new Vector3(6f, 1), Quaternion.identity);
        CloneMoleThree.GetComponent<molehealth>().batlehan = this;
        GameObject playerbattle = Instantiate(PlayerBattle, position, Quaternion.identity).gameObject;
        playerbattle.GetComponent<characterbattle>().mlhealth = CloneMole.GetComponent<molehealth>();
        playerbattle.GetComponent<characterbattle>().btlhand = this;

    }

    public void ShowTargets()
    {
        if(CloneMole != null)
        {
            LeftSelect.gameObject.SetActive(true);
        }

        if (CloneMoleTwo != null)
        {
            MidSelect.gameObject.SetActive(true);
        }

        if (CloneMoleThree != null)
        {
            RightSelect.gameObject.SetActive(true);
        }

    }

    IEnumerator Victory()
    {
        yield return new WaitForSecondsRealtime(2);
        VictoryText.gameObject.SetActive(true);
        LastEnemy.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        StopAllAudio();
        Music.PlayOneShot(VictorySound);

        yield return new WaitForSecondsRealtime(2);
        Instantiate(BlackTrans, Transspawnpnt.transform.position, Quaternion.identity);
        healthcanvas.gameObject.SetActive(false);


        yield return new WaitForSecondsRealtime(3);
        Destroy(LastEnemy);
        VictoryText.SetActive(false);
        healthcanvas.gameObject.SetActive(true);
        //Debug.Log("dead");
        //spwncmbtow.isenemydead = true;
        //SceneManager.LoadScene("combatoverworld");


        CombatCam.enabled = false;
        PlayeroverCam.enabled = true;
        battleui.SetActive(false);
        StopAllAudio();
        Music.Play();
        Debug.Log("musicplaty");
    }
}
