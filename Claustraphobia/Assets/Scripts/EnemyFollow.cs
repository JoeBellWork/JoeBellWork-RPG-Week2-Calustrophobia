using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyFollow : MonoBehaviour
{
    public Scriptable enemy;

    private float currentHealth;
    
    
    

    

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        currentHealth = enemy.maxHealth;
       



        this.GetComponent<SpriteRenderer>().sprite = enemy.image;
        this.GetComponent<SpriteRenderer>().color = enemy.color;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,target.position) > 0.5f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, enemy.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print(enemy.unitName);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
