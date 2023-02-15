using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippickupScript : MonoBehaviour
{
    public bool Hammer = false;
    public bool Lamp = false;
    public GameObject PlayerObject;
    public playermovement playmovmt;
    public GameObject Boulder;
    public GameObject BoulderSpawn;
    public GameObject HammerPopup;
    // Start is called before the first frame update
    void Start()
    {
        playmovmt = PlayerObject.GetComponent<playermovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(Hammer)
            {
                playmovmt.HasHammer = true;
                HammerPopup.gameObject.SetActive(true);
                Instantiate(Boulder, BoulderSpawn.transform.position, Quaternion.identity);
            }
            if(Lamp)
            {
                playmovmt.HasLamp = true;
            }
            Destroy(gameObject);
        }

    }
}
