using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteraction : MonoBehaviour
{

    public float pushForce = 10;
    public Transform protagonist;

    public Vector3 rot;

    private float checker = 0;

    private float valSmoothed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.rigidbody != null && checker == 0)  {
          hit.rigidbody.AddForce(new Vector3(rot.x, rot.y, rot.z), ForceMode.Impulse);
          checker = 1;
        } else if (hit.rigidbody == null) {
          checker = 0;
        }

        }
}
