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
    public string username, email, password, passCode;

    private string characters = "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

    #region Recovery Code
    public InputField recoveryInput;
    #endregion

    #region
    public InputField emailSend;
    #endregion

    #endregion

    public GUIManager manager;
    #endregion

    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    public string finalString;
    char[] stringChars = new char[8];
    void RandomCode()
    {
        for (int i = 0; i < 6; i++)
        {
            stringChars[i] = chars[Random.Range(0, chars.Length)];
        }

        finalString = new string(stringChars);
    }
    private void Start()
    {

    }
    private void ClearString()
    {
        userInput.text = "";
        passInput.text = "";
        emailInput.text = "";
        passLoginUser.text = "";
        userLoginUser.text = "";
        emailSend.text = "";
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

    IEnumerator CheckEmail(string email)
    {
        string CheckEmailURL = "http://localhost/sqlsystem/login.php";
        WWWForm user = new WWWForm();

        //Grab data
        user.AddField("email_Post", email);

        WWW www = new WWW(CheckEmailURL, user);

        yield return www;
    }

    IEnumerator RecoveryEmail(string email)
    {

        string recoveryEmailURL = "http://localhost/sqlsystem/checkemail.php";
        WWWForm checkEmail = new WWWForm();
        checkEmail.AddField("email_post", email);
        WWW www = new WWW(recoveryEmailURL, checkEmail);
        yield return www;
        Debug.Log(www.text);
        if (www.text != "No Email Found")
        {
            username = www.text;
            mes = "Email Sending...";
        }
        else
        {
            mes = www.text;
        }
    }
    public void Create_User()
    {
        username = userInput.text;
        password = passInput.text;
        email = emailInput.text;
        if (username != "" || password != "" || email != "")
        {
            if (emailInput.text.Contains("@" + ".com"))
            {
                StartCoroutine(CreateLogin(username, password, email));
                manager.createUser.SetActive(false);
                manager.login.SetActive(true);
                print("User Successfully Created");
                ClearString();
            }
            else
            {
                print("Incorrect email");
            }

        }
        else
        {
            ClearString();
            print("Please Fill Out");
            Debug.Log("Need @");

        }
    }

    public void Login_Game(int loadLvl)
    {
        username = userLoginUser.text;
        password = passLoginUser.text;
        if (username != "" || password != "")
        {

            SceneManager.LoadScene(loadLvl);
            ClearString();
            print("Login Success");
        }
        else
        {
            print("Login Unsuccessful");
        }
    }

    public void SendEmail(Text email)
    {   /*
        
         
         sent to user

           create PHP that uses the email address to find and echo username
           grab user name with www.text and put into the Hello User space

           create a popup upon successful email sent to allow code input
           check to see if code matches
           if success popup new password box
           upon submittion of password update data base... UPDATE password WHERE user or email == user or email
           load to login
            */
        if (email.text != "")
        {
            if (email.text.Contains("@") || email.text.Contains(".com"))
            {
                //Generate Code
                RandomCode();


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
                mail.To.Add(email.text);
                mail.Subject = "Password Reset";
                mail.Body = "Hello " + username + "\nReset using this code: " + finalString;


                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 25;
                smtpServer.Credentials = new System.Net.NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
                smtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate
                    (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
                { return true; };
                smtpServer.Send(mail);
                Debug.Log("Sending Email");
                ClearString();

            }

        }

    }

    public void RecoverPass()
    {
        passCode = recoveryInput.text;
        if (passCode != "" && passCode == finalString)
        {

        }
    }


    #endregion
}
