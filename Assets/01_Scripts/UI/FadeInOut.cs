using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    float time = 0;

    void Update()
    {
        if (time < 0.7f)
        {
            GetComponent<Text>().color = new Color(1, 1, 1, 0.7f - time);
        } else
        {
            time = 0;
        }
        time += Time.deltaTime;
    }

    public void resetAnim()
    {
        GetComponent<Text>().color = new Color(1, 1, 1, 0);
        this.gameObject.SetActive(true);
    }
 }
