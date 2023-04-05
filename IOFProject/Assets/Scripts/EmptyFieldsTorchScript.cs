using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFieldsTorchScript : MonoBehaviour
{
    public GameObject FlameBehind;
    public SpawnerScript Spawnscrpt;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireObject")
        {
            Instantiate(FlameBehind, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), Quaternion.identity);
            Spawnscrpt.TorchLit();

        }
    }
}

