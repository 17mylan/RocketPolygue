using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetCarName : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI carName;
    private void Start()
    {
        carName.text = PlayerPrefs.GetString("SavedCarName");
    }

    void Update()
    {
        carName.text = PlayerPrefs.GetString("SavedCarName");
        if(!PlayerPrefs.HasKey("SavedCarName"))
        {
            carName.text = "NISSAN GTR R35".ToString();
        }
    }
}
