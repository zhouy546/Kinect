using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class UpdateUI : MonoBehaviour {
    public BodySourceView bodySourceView;

    public GameObject Cursor;
    public List<GameObject> cursors = new List<GameObject>();

    int num = 0;
    // Use this for initialization
    void Start () {

        bodySourceView = FindObjectOfType<BodySourceView>();

        CreateCurser();
    }
	
	// Update is called once per frame
	void Update () {

    }

   public void updateCursors(ulong[] id) {


        for (int i = 0; i<id.Length;  i++)
        {

            if (bodySourceView._Npeoples.ContainsKey(id[i])) {
                cursors[2 * i].transform.localPosition = bodySourceView._Npeoples[id[i]].MappedRightHandPos;


                cursors[2 * i + 1].transform.localPosition = bodySourceView._Npeoples[id[i]].MappedLeftHandPos;

            }
        }
    }


    void CreateCurser() {
        for (int i = 0; i < 14; i++)
        {
            GameObject _Cursor= Instantiate(Cursor);
            _Cursor.transform.SetParent(this.transform);
            _Cursor.transform.position = new Vector3(-10000, -10000, 0);
            cursors.Add(_Cursor);
        }
    }
}
