using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundEnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject enemy;
    Vector3 enemyPos;
    public float speed;
    float enemyRotation = -90;
    public float lowestx = 9;
    public float highestx = 21;

    // Update is called once per frame
    void Update()
    {
        enemyPos = new Vector3(enemy.transform.position.x - speed, enemy.transform.position.y, enemy.transform.position.z);
        enemy.transform.SetPositionAndRotation(enemyPos, Quaternion.Euler(0, enemyRotation, 0));

        if (enemy.transform.position.x <= lowestx || enemy.transform.position.x >= highestx)
        {
            speed = speed * - 1;
            enemyRotation = enemyRotation + 180f;
            enemy.transform.SetPositionAndRotation(enemyPos, Quaternion.Euler(0, enemyRotation, 0));
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Level1");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(enemy);
    }
}
