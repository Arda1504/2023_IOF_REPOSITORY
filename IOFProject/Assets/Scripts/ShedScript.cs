using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShedScript : MonoBehaviour
{
    public GameObject HammerPickup;
    public GameObject SmokeEffect;
    public GameObject SmokeSpawn;
    public GameObject ExitSpawn;
    public GameObject ExitTeloport;
    public GameObject StoneExTelo;
    public GameObject StoneEX;
    public Sprite StoneInt2;
    public Sprite StoneEX2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UsedHammer()
    {
        StartCoroutine(HammerTime());
    }

    IEnumerator HammerTime()
    {
        Instantiate(SmokeEffect, SmokeSpawn.transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = StoneInt2;
        StoneEX.gameObject.GetComponent<SpriteRenderer>().sprite = StoneEX2;
        ExitTeloport.gameObject.transform.position = new Vector3(ExitSpawn.transform.position.x, ExitSpawn.transform.position.y, ExitSpawn.transform.position.z);
        Destroy(StoneExTelo.gameObject);
    }
}
