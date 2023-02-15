using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncombatoverworld : MonoBehaviour
{
    public GameObject player;
    public triggercombat trigcombt;
    public GameObject enemy;
    public bool isenemydead = false;
    public float playerx = 10f;
    public float playery = 10f;


    // Start is called before the first frame update
    void Start()
    {
        

        Instantiate(player, new Vector3(playerx, playery, 0), Quaternion.identity);

        if(!isenemydead)
        {
            Instantiate(enemy, new Vector3(2, 2, 0), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
    }
}
