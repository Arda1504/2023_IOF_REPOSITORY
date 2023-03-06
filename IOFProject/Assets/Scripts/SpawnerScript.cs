using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject SpawnObject;
    public float TorchesLit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TorchLit()
    {
        TorchesLit++;

        if(TorchesLit == 3)
        {
            Instantiate(SpawnObject, gameObject.transform.position, Quaternion.identity);
        }
    }
}
