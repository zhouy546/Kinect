using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPeople : MonoBehaviour {

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
}
