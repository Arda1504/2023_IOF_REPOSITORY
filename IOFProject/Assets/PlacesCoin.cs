using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesCoin : MonoBehaviour
{

    Vector2 ColliderPosition;
    
    
    public GameObject SpawnCoin;
    public GameObject SpawnNewCoin;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(GameManager.instance.hasCoin)
            {
                
                
                ColliderPosition = GetComponent<BoxCollider2D>().transform.position;
                float Colliderx = ColliderPosition.x;
                float Collidery = ColliderPosition.y;

                Instantiate(SpawnNewCoin, new Vector2(Colliderx, Collidery * 0.30f), Quaternion.identity);

                
            }
        }
    }
}
