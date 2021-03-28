using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField IDText;
    public TMP_InputField PWText;
    public GameObject error;
    public GameObject LoginPanel;
    public GameObject SignUpPanel;
    public GameObject StartButton;

    //private string AdminID = "test";
    //private string AdminPW = "1234";

    private bool idCheck;
    private bool pwCheck;

    public void ClickLoginButton()
    {
        idCheck = SystemManager.Instance.GetCurrentSceneMain<TitleSceneMain>().CheckUserID(IDText.text);
        pwCheck = SystemManager.Instance.GetCurrentSceneMain<TitleSceneMain>().CheckUserPW(PWText.text);
        //if (IDText.text.Equals(AdminID) && PWText.text.Equals(AdminPW))
        if (idCheck && pwCheck)
        {
            //SceneManager.LoadScene("CustomizingScene");
            SystemManager.Instance.GetCurrentSceneMain<TitleSceneMain>().MoveToCustomizingScene();
        }
        else
        {
            error.SetActive(true);
            IDText.text = "";
            PWText.text = "";
        }
    }

    public void ClickErrorPopup()
    {
        error.SetActive(false);
    }

    public void ClickSignUp()
    {
        SignUpPanel.SetActive(true);
    }

    public void ClickLoginX()
    {
        LoginPanel.SetActive(false);
        StartButton.SetActive(true);
    }

    public void ClickSignUpX()
    {
        SignUpPanel.SetActive(false);
    }
}
