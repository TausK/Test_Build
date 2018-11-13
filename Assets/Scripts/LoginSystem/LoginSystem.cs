using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class LoginSystem : MonoBehaviour
{
    #region Variables

    [Header("Login Variables")]
    #region Login Variables
    //Popup Message
    public string mes;
    //String for login system
    public string username, email, password;

    #endregion

    #region Bools

    #endregion

    #region GameObjects

    #endregion

    #region UI
    #region Create User InputFields
    public InputField userInput;
    public InputField passInput;
    public InputField emailInput;
    #endregion

    #region Login User InputFields
    public InputField userLoginUser;
    public InputField passLoginUser;
    #endregion

    #endregion

    #endregion

    private void ClearString()
    {
        username = "";
        password = "";
        email = "";
    }
    public void LoginGame()
    {

    }

    #region Login System Setup
    //Login Game Setup
    IEnumerator CreateLogin(string username, string password, string email)
    {
        string CreateUserURL = "http://localhost/sqlsystem/createuser.php";
        WWWForm user = new WWWForm();

        //Grab data from php to check 
        user.AddField("username_Post", username);
        user.AddField("password_Post", password);
        user.AddField("email_Post", email);

        //Send data to web data
        WWW www = new WWW(CreateUserURL, user);
        //End process by returning data process
        yield return www;

        Debug.Log(www.text);
    }

    IEnumerator Login(string username, string password)
    {
        string LoginURL = "http://localhost/sqlsystem/login.php";
        WWWForm user = new WWWForm();

        //Grab data
        user.AddField("username_Post", username);
        user.AddField("password_Post", password);

        WWW www = new WWW(LoginURL, user);

        yield return www;
    }

    public void Create_User()
    {
        username = userInput.text;
        password = passInput.text;
        email = emailInput.text;
        if (username != "" || password != "" || email != "")
        {
            StartCoroutine(CreateLogin(username, password, email));
            ClearString();
            print("User Successfully Created");

        }
        else
        {
            ClearString();
            print("Please Fill Out");

        }
    }

    public void Login_Game()
    {
        username = userLoginUser.text;
        password = passLoginUser.text;
        if(username != "" || password != "")
        {
            SceneManager.LoadScene(1);
            print("Login Success");
        }
        else
        {
            print("Login Unsuccessful");
        }
    }
    #endregion
}
