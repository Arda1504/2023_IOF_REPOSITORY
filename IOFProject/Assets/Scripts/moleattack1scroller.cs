using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleattack1scroller : MonoBehaviour
{
    public float tempomoleattack1;

    public bool hasstartedmoleattack1;

    // Start is called before the first frame update
    void Start()
    {
        tempomoleattack1 = tempomoleattack1 / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasstartedmoleattack1)
        {

        }
        else
        {
            transform.position -= new Vector3(tempomoleattack1 * Time.deltaTime, 0f, 0f);
        }
    }
}
