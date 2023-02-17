using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBushScript : MonoBehaviour
{
    public GameObject FireObject;
    public bool HideoutBush;
    public GameObject Tohideout;
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
            
            StartCoroutine(BurnBush());
        }
    }

    IEnumerator BurnBush()
    {
        Debug.Log("burning");
        GameObject FireCurrent = Instantiate(FireObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        yield return new WaitForSecondsRealtime(2);
        if(HideoutBush)
        {
            Tohideout.gameObject.transform.position = gameObject.transform.position;
        }
        Destroy(FireCurrent.gameObject);
        Destroy(gameObject);
    }
}
