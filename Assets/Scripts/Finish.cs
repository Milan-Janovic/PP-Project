using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    ItemCollector itemCollector;
    PlayerMovement playerMovement;

    [SerializeField] int coinsNeeded;

    void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(itemCollector.coinsCollected == coinsNeeded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
        }
        else
        {
            itemCollector.coinsText.text = "Missing Coins";
        }
    }
}
