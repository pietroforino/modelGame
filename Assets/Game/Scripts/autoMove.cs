using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour
{

  public float speedX, speedY, speedZ;
  private float deltaX, deltaY, deltaZ;

  public Vector3 delta;

  float countDown = 5.0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    deltaX = speedX * Time.deltaTime;
    deltaY = speedY * Time.deltaTime;
    deltaZ = speedZ * Time.deltaTime;

    //transform.Translate(deltaX, deltaY, deltaZ);

    countDown -= Time.deltaTime;

    if(countDown > 0)
        transform.position += Vector3.forward * Time.deltaTime;
    else if (countDown > -5.0f) // You don't want to move backwards too much!
        transform.position += Vector3.back * Time.deltaTime;

  }
}
