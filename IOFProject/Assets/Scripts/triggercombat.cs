using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class triggercombat : MonoBehaviour
{
    public GameObject player;
    public float playerx;
    public float playery;
    public Camera CombatCam;
    public Camera PlayeroverCam;
    public GameObject battleui;
    public GameObject TransSpawn;
    public GameObject BlackScreenObject;
    public AudioSource CombatMusic;
    private AudioSource[] allAudioSources;
    public Canvas Healthui;
    public AudioClip EncounterMusic;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null || player == !isActiveAndEnabled)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            StartCoroutine(CombatTransition());
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        Debug.Log("entered");

        PlayeroverCam.enabled = false;
        CombatCam.enabled = true;
        Debug.Log(CombatCam.gameObject.name);
        battleui.SetActive(true);
        //Destroy(this.gameObject);

        //SceneManager.LoadScene("Combat");
        //DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(player.gameObject);
    }

    public void StartCombat()
    {
        
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        Debug.Log("entered");

        PlayeroverCam.enabled = false;
        CombatCam.enabled = true;
        Debug.Log(CombatCam.gameObject.name);
        battleui.SetActive(true);
        //Destroy(this.gameObject);

        //SceneManager.LoadScene("Combat");
        //DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(player.gameObject);
    }

    IEnumerator CombatTransition()
    {
        Healthui.gameObject.SetActive(false);
        Instantiate(BlackScreenObject, TransSpawn.transform.position, Quaternion.identity);
        StopAllAudio();
        CombatMusic.PlayOneShot(EncounterMusic);
        yield return new WaitForSecondsRealtime(3);
        StartCombat();
        StopAllAudio();
        CombatMusic.Play();
        Healthui.gameObject.SetActive(true);
    }

    public void StartCombatTrans()
    {
        StartCoroutine(CombatTransition());
    }


}
