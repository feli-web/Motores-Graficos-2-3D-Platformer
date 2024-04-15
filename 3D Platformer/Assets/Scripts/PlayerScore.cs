using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int fruits;
    public TextMeshProUGUI fruitText;
    void Start()
    {
        fruitText.text = fruits.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            fruits++;
            fruitText.text = fruits.ToString("D2");
        }
    }
}
