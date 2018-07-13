using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPeople : MonoBehaviour {
    public Vector3 LeftElbowPos;

    public Vector3 LeftShoulderPos;

    public Vector3 RightElbowPos;

    public Vector3 RightShoulderPos;

    private Vector3 leftHandPos;
    public Vector3 LeftHandPos {
        get {
            return leftHandPos;
        }
        set {
            leftHandPos= value;
        }
    }

    private Vector3 rightHandPos;
    public Vector3 RightHandPos {
        get
        {
            return rightHandPos;
        }
        set
        {
            rightHandPos = value;
        }
    }

    public Vector3 CenterPos;
    public float xMaxValue=6, xMinValue=-6;
    public float yMaxValue = 6, yMinValue=-4;


    public Vector3 MappedLeftHandPos {

        get {
            float x = Mapping(LeftHandPos.x, xMinValue, xMaxValue, -1920F / 2F, 1920F / 2F);
            float y = Mapping(LeftHandPos.y, yMinValue, yMaxValue, -1200 / 2F, 1200 / 2F);
            return new Vector3(x, y, 0);
        }
    }

    public Vector3 MappedRightHandPos
    {

        get
        {
            float x = Mapping(RightHandPos.x, xMinValue, xMaxValue, -1920F / 2F, 1920F / 2F);
            float y = Mapping(RightHandPos.y, yMinValue, yMaxValue, -1200 / 2F, 1200 / 2F);
            return new Vector3(x, y, 0);
        }
    }

    public NPeople() {

    }


    float Mapping(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {

        float outVal = ((value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin);

        return outVal;
    }


   public void setMinAndMaxVal() {
        Vector2 LHandPos = new Vector2(leftHandPos.x, leftHandPos.y);
        Vector2 LElbowPos = new Vector2(LeftElbowPos.x, LeftElbowPos.y);
        Vector2 LShoulderPos = new Vector2(LeftShoulderPos.x, LeftShoulderPos.y);


        Vector2 RHandPos = new Vector2(rightHandPos.x, rightHandPos.y);
        Vector2 RElbowPos = new Vector2(RightElbowPos.x, RightElbowPos.y);
        Vector2 RShoulderPos = new Vector2(RightShoulderPos.x, RightShoulderPos.y);

        float leftX = (LHandPos - LElbowPos).magnitude + (LElbowPos - LShoulderPos).magnitude + Mathf.Abs(LShoulderPos.x-CenterPos.x);

        float rightX = (RHandPos - RElbowPos).magnitude + (RElbowPos - RShoulderPos).magnitude + Mathf.Abs(RShoulderPos.x - CenterPos.x);

      //  Debug.Log(LShoulderPos.x);

        xMinValue = CenterPos.x - leftX;

        xMaxValue = CenterPos.x + rightX;

 //       Debug.Log(RightShoulderPos.x);

        //Debug.Log("Min VALUE:" +xMinValue);

        //Debug.Log("MAX VALUE:" + xMaxValue);

    }
}
