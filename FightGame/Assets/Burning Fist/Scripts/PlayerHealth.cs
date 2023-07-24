using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 2000)] public int StartHealth = 100, currentHealth;

    public static bool isDead;

    public void Start()
    {
        currentHealth = StartHealth; 
    }

    private void Update()
    {
        if (currentHealth <= 0 )
        {
            Debug.Log("The Player Has Died");
            SceneManager.LoadScene("Lose");


        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

}
