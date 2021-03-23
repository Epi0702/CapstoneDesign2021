using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class Passage : MonoBehaviour
{
    RectTransform rectTrans;
    public PassageData passageinfo;
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
