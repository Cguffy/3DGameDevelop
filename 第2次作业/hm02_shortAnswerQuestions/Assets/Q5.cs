using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q5 : MonoBehaviour
{
    public Transform table;
    // Start is called before the first frame update
    void Start()
    {
        GameObject t1 = Instantiate<Transform> (table, this.transform).gameObject;
		t1.transform.position = new Vector3 (0, 0, 0);
    }
}
