using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool isDead = false;

    [SerializeField] AudioSource deathSound;

    private void Update()
    {
        Fall();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyBody"))
        {
            Die();
        }
    }

    // Moholo sa pouzit aj Destroy(gameObject), ale neslo by to nasledne reloadnut
    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        deathSound.Play();
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Fall()
    {
        Vector3 playerPosition = transform.position;
        
        if(transform.position.y < -5f && !isDead)
        {
            isDead = true;
            deathSound.Play();
            Invoke(nameof(ReloadLevel), 1f);
        }
    }
}
