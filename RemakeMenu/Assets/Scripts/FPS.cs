using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class FPS : MonoBehaviour
{
    public Text fpsText;
    public int targetFPS = 145;
    private float deltaTime = 0.0f;
    public TMP_Dropdown dropdownFPS;
    private string selectedFPS;

    private void Start()
    {
        dropdownFPS.onValueChanged.AddListener(OnDropdownValueChangedFPS);
        targetFPS = PlayerPrefs.GetInt("FPS");
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        int roundedFPS = Mathf.RoundToInt(fps);
        if(GameObject.Find("FPS-Display") == true)
        {
            fpsText.text =  roundedFPS.ToString();
            if (roundedFPS <= 30)
            {
                fpsText.color = Color.red;
            }
            else if (roundedFPS > 31 && roundedFPS <= 59)
            {
                fpsText.color = Color.yellow;
            }
            else if (roundedFPS >= 60)
            {
                fpsText.color = Color.green;
            }
        }
        if (targetFPS > 0)
        {
            Application.targetFrameRate = targetFPS;
        }
        else
        {
            Application.targetFrameRate = -1;
        }
    }
    private void OnDropdownValueChangedFPS(int value)
    {
        string selectedFPS = dropdownFPS.options[value].text;
        targetFPS = int.Parse(selectedFPS);
        PlayerPrefs.SetInt("FPS", int.Parse(selectedFPS));
    }
}