using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public bool canclick;
    private object clickable2D;
    

    public class Clickable2D
    {
        public interaction clickable2d;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        clickable2D = gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
