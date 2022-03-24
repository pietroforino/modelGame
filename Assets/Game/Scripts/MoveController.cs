using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Transform objContainerRotX, objContainerRotY;
    public float rotMult;

    float rotXTarget, rotYTarget;
    float rotXSmoothed, rotYSmoothed;
    public float rotSmoothTime;
    float rotXSmoothVel, rotYSmoothVel;
    public float  rotXMax;

    float scaleTarget;
    float scaleSmoothed;
    public float scaleSmoothTime;
    float scaleSmoothVel;
    public float scaleMin, scaleMax;
    public float scaleMult;

    Vector3 mousePosOld;
    float mouseRightYOld;
    void Start()
    {
        rotXTarget = 0;
        rotXSmoothed = 0;
        rotXSmoothVel = 0;
        rotYTarget = 0;
        rotYSmoothed = 0;
        rotYSmoothVel = 0;

        scaleTarget = objContainerRotX.localScale.x;
        scaleSmoothed = scaleTarget;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosOld = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            float deltaMouseX = -(Input.mousePosition.x- mousePosOld.x) * rotMult;
            float deltaMouseY = (Input.mousePosition.y - mousePosOld.y) * rotMult;
            mousePosOld = Input.mousePosition;

            rotXTarget += deltaMouseY;
            if (rotXTarget > rotXMax)
            {
                rotXTarget = rotXMax;
            }
            else if (rotXTarget < -rotXMax)
            {
                rotXTarget = -rotXMax;
            }
            rotYTarget += deltaMouseX;

        }
        if (Input.GetMouseButtonDown(1))
        {
            mouseRightYOld = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(1))
        {
            float deltaMouseY = (Input.mousePosition.y - mouseRightYOld) * scaleMult;
            mouseRightYOld = Input.mousePosition.y;
            float absDeltaMouseY = Mathf.Abs(deltaMouseY);
            if (deltaMouseY>0)
            {
                //print("positive");
                scaleTarget /= 1 + absDeltaMouseY;
            }
            else if (deltaMouseY < 0)
            {
                //print("negative");
                scaleTarget *= 1+ absDeltaMouseY;
            }
            if (scaleTarget > scaleMax)
            {
                scaleTarget = scaleMax;
            }
            if (scaleTarget < scaleMin)
            {
                scaleTarget = scaleMin;
            }
        }

        rotXSmoothed = Mathf.SmoothDamp(rotXSmoothed, rotXTarget, ref rotXSmoothVel, rotSmoothTime);
        objContainerRotX.localEulerAngles = new Vector3(rotXSmoothed, 0, 0);

        rotYSmoothed = Mathf.SmoothDamp(rotYSmoothed, rotYTarget, ref rotYSmoothVel, rotSmoothTime);
        objContainerRotY.localEulerAngles = new Vector3(0, rotYSmoothed, 0);

        scaleSmoothed = Mathf.SmoothDamp(scaleSmoothed, scaleTarget, ref scaleSmoothVel, scaleSmoothTime);
        objContainerRotX.localScale = new Vector3(scaleSmoothed, scaleSmoothed, scaleSmoothed);

    }
}
