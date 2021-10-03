using System.Collections;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField IDText;
    public TMP_InputField PWText;
    public GameObject error;
    public GameObject LoginPanel;
    public GameObject SignUpPanel;
    public GameObject StartButton;

    string LoginURL = "http://capston.dothome.co.kr/login.php";
    int result = -1;
    string[] data;

    public void Update()
    {
        StartCoroutine(LoginToDB(IDText.text, PWText.text)); //php에서 로그인 체크
    }

    public void ClickLoginButton()
    {
        if (result == 0) //로그인 성공 & 캐릭터 없음 -> 커스터마이징 씬
        {
            SystemManager.Instance.GetCurrentSceneMain<TitleSceneMain>().MoveToCustomizingScene();
        }
        else if (result == 1) //로그인 성공 & 캐릭터 있음 -> 메인로비 씬
        {
            SystemManager.Instance.GetCurrentSceneMain<TitleSceneMain>().MoveToMainLobbyScene();
            GameManager.updateUserInfo(int.Parse(data[1]), int.Parse(data[2]), data[3], short.Parse(data[4]), int.Parse(data[5]), short.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]));
        }
        else if (result == 2) //비밀번호 틀림
        {
            error.SetActive(true);
            IDText.text = "";
            PWText.text = "";
        }
        else //계정 없음
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

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", username);
        form.AddField("pw", password);

        WWW www = new WWW(LoginURL, form);

        yield return www;

        data = www.text.Split(','); //받아온 로그인정보, 유저정보 구분

        result = int.Parse(data[0]);
    }
}