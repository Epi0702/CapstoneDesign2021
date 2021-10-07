using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    Item item;
    GameObject SelectedFrame;
    GameObject unactive;
    // Start is called before the first frame update
    void Start()
    {
        item = this.GetComponent<Item>();
        SelectedFrame = transform.Find("SelectedFrame").gameObject;
        unactive = transform.Find("UnActive").gameObject;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.playerSkillActive == true)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.SetSkillClickedFalse();
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.SetSkillSelectedFrameAllOff();

            SelectedFrameOnOff(true);
            //item.skillCancel = true;
            item.skillSelected = true;
            item.OnClickFunction();
        }
            
    }

    public void SelectedFrameOnOff(bool onoff)
    {
        SelectedFrame.SetActive(onoff);
    }
    public void UnActive(bool onoff)
    {
        unactive.SetActive(onoff);
    }
}
