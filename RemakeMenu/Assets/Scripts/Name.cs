using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Name : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TMP_InputField displayName;

    private void Start()
    {
        if(PlayerPrefs.GetString("userName").Length >= 0)
            userName.text = PlayerPrefs.GetString("username");
        else
            userName.text = "New Player";
    }
    public void Create()
    {
        if(displayName.text.Length >= 2 && displayName.text.Length <= 10)
        {
            userName.text = displayName.text;
            PlayerPrefs.SetString("username", userName.text);
        }
    }
}
