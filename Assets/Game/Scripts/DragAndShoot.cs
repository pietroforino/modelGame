
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(Collider))]

public class DragAndShoot : MonoBehaviour
  {
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;
    private bool isShoot;

    public float forceMultiplier = 3;

    void Start()
      {
        rb = GetComponent<Rigidbody>();
      }
    private void OnMouseDown()
      {
        mousePressDownPos = Input.mousePosition;
      }

    private void OnMouseUp()
      {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
      }



    void Shoot(Vector3 Force)
    {
      if(isShoot)
      return;
      rb.AddForce(new Vector3(-Force.x,-Force.y,-Force.y) * forceMultiplier);
      isShoot = false;
    }
}
