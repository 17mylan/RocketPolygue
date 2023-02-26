using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Title : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI playerTitle;
    private string selectedOption;
    
    private void Start()
    {
        // Ajouter un listener à l'événement OnValueChanged du dropdown
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        StartCoroutine("Wait");
    }

    // Fonction appelée lorsque la valeur du dropdown est changée
    private void OnDropdownValueChanged(int value)
    {
        // Récupérer le texte de l'option sélectionnée
        string selectedOption = dropdown.options[value].text;
        
        playerTitle.text = selectedOption;
        PlayerPrefs.SetString("playerTitle", selectedOption);
        if(selectedOption == "Developer" || selectedOption == "Rocket Polygue Team" || selectedOption == "Beta Tester" || selectedOption == "Moderator")
        {
            playerTitle.color = Color.green;
        }
        else if(selectedOption == "RPCS World Champion")
        {
            playerTitle.color = Color.cyan;
        }
        else
        {
            playerTitle.color = Color.white;
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        if(PlayerPrefs.GetString("playerTitle").Length <= 1)
        {
            playerTitle.text = "Casual Player";
        }
        else
        {
            playerTitle.text = PlayerPrefs.GetString("playerTitle");
            string title = PlayerPrefs.GetString("playerTitle");
            if(title == "Developer" || title == "Rocket Polygue Team" || title == "Beta Tester" || title == "Moderator")
            {
                playerTitle.color = Color.green;
            }
            else if(title == "RPCS World Champion")
            {
                playerTitle.color = Color.cyan;
            }
            else
            {
                playerTitle.color = Color.white;
            }
        }
    }


}
