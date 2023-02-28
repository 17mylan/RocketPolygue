using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supporter : MonoBehaviour
{
    public float speed = 2.0f;
    public float random;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool movingUp = true;
    public List<Material> supporterColor;

    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null && supporterColor.Count > 0) // Vérifier que le composant MeshRenderer et la liste de matériaux ne sont pas nuls
        {
            int randomIndex = Random.Range(0, supporterColor.Count); // Générer un index aléatoire dans la plage des indices de la liste de matériaux
            renderer.material = supporterColor[randomIndex];
        }
        random = Random.Range(0.01f,0.1F);
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, random, 0);
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingUp = true;
            }
        }
    }
}
