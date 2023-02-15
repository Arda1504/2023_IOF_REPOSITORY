using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVolume : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SliderVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
