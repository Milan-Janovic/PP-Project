using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int coinsCollected = 0;

    [SerializeField] public Text coinsText;
    [SerializeField] AudioSource collectionSound;
    [SerializeField] public int coinsNeeded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
            coinsText.text = "Coins: " + coinsCollected + " / " + coinsNeeded;
            collectionSound.Play();
        }
    }
}
