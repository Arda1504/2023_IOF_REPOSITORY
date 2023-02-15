using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackScreenTransScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }
}
