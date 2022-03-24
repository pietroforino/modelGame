using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{

    public Vector3 delta;
    float countDown = 5.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      countDown -= Time.deltaTime;

      GetComponent<Rigidbody>().AddForce(delta);

      if(countDown < 0) {// You don't want to move backwards too much!
          delta *= -1;
          countDown = 5.0f;
        }
    }

  }
