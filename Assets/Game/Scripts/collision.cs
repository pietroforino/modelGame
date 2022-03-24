using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    public GameObject rootObj;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );

        rootObj.GetComponent<Renderer>().material.color = newColor;
    }


    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)) {
          GameObject duplicate = Instantiate(rootObj);
        }
    }

}
