using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TorchObjScript : MonoBehaviour
{
    public bool CampWood = false;
    public playermovement plymvt;
    public GameObject BushBehind1;
    public GameObject Bush1;
    public GameObject Bush2;
    public GameObject Bush3;
    public GameObject Bush4;
    public GameObject Bush5;
    public GameObject Flamebehind;
    public GameObject Flamenormal;
    public Flowchart Flwchart;
    public bool DidEmptyFieldsEvent = false;
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
            Instantiate(Flamebehind, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
            if (CampWood && DidEmptyFieldsEvent == false)
            {
                EmptyFieldsEvent();
                DidEmptyFieldsEvent = true;
            }
        }
    }

    public void EmptyFieldsEvent()
    {
        StartCoroutine(EmptyFieldsStart());
    }

    IEnumerator EmptyFieldsStart()
    {
        plymvt.CanMove = false;
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Flamebehind, new Vector3(BushBehind1.transform.position.x, BushBehind1.transform.position.y + 1, BushBehind1.transform.position.z), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Flamenormal, new Vector3(Bush1.transform.position.x, Bush1.transform.position.y + 1, Bush1.transform.position.z), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Flamenormal, new Vector3(Bush2.transform.position.x, Bush2.transform.position.y + 1, Bush2.transform.position.z), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Flamenormal, new Vector3(Bush3.transform.position.x, Bush3.transform.position.y + 1, Bush3.transform.position.z), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Flamenormal, new Vector3(Bush4.transform.position.x, Bush4.transform.position.y + 1, Bush4.transform.position.z), Quaternion.identity);
        Flwchart.SendFungusMessage("FieldsReaction");
        plymvt.CanMove = true;

    }
}
