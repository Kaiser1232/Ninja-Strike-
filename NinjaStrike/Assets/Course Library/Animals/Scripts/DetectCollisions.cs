using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DetectCollisions : MonoBehaviour
{
    public ScoreManager score;
    public int value; 
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        score.score += value;
        Destroy(gameObject);
        Destroy(other.gameObject);
       

    }
    
}
