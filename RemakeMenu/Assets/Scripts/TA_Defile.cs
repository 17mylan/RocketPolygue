using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TA_Defile : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Référence au composant TextMeshProUGUI de l'objet
    public float scrollSpeed; // Vitesse de défilement du texte
    public float startOffset; // Distance en dehors de l'écran où le texte doit commencer

    private RectTransform rectTransform;
    private float textWidth;
    private float startX;

    public float interval = 10f; // Intervalle de temps entre chaque message
    private float timeSinceLastMessage = 0f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textWidth = textComponent.preferredWidth;
        startX = rectTransform.localPosition.x + startOffset;
    }

    void Update()
    {
        // Fait défiler le texte vers la gauche
        rectTransform.localPosition += Vector3.left * scrollSpeed * Time.deltaTime;
        timeSinceLastMessage += Time.deltaTime;

        // Si l'intervalle de temps est écoulé, envoie un message dans la console et réinitialise le temps écoulé
        if (timeSinceLastMessage >= interval)
        {
            timeSinceLastMessage = 0f;
            rectTransform.localPosition = new Vector3(startX, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
    }
}
