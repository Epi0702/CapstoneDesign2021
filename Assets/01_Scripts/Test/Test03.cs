using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test03 : MonoBehaviour
{
    RectTransform rectTrans;
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = this.GetComponent<RectTransform>();
        rectTrans.anchoredPosition = new Vector2(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
