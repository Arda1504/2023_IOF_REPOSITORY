using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    public GameObject TeleportTo;
    public AudioSource NewMusic;
    private AudioSource[] allAudioSources;
    public AudioClip musicStart;
    public bool intro;
    public Image black;
    public Animator anim;
    public Coroutine timer;
    public WaitForSeconds one;
    public bool Music = true;
    public GameObject Playerobject;
    public bool StopMusic = false;

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Playerobject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Fading());


            if (Music)
            {
                StopAllAudio();


                if (intro == true)
                {
                    NewMusic.PlayOneShot(musicStart);
                    NewMusic.PlayScheduled(AudioSettings.dspTime + musicStart.length);
                }
                else
                {
                    NewMusic.Play();
                }
            }

            if(StopMusic)
            {
                StopAllAudio();
            }
            other.transform.position = new Vector3(TeleportTo.transform.position.x, TeleportTo.transform.position.y, TeleportTo.transform.position.z);



        }
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);


        anim.SetBool("Fade", false);



    }

    public void Teloport()
        {
        StartCoroutine(Fading());


        if (Music)
        {
            StopAllAudio();


            if (intro == true)
            {
                NewMusic.PlayOneShot(musicStart);
                NewMusic.PlayScheduled(AudioSettings.dspTime + musicStart.length);
            }
            else
            {
                NewMusic.Play();
            }
        }

        if (StopMusic)
        {
            StopAllAudio();
        }
        Playerobject.transform.position = new Vector3(TeleportTo.transform.position.x, TeleportTo.transform.position.y, TeleportTo.transform.position.z);



    }
}
    



