using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public Transform point1;
    public List<GameObject> items;
    float timer = 0;
    public float timeBtwSpawn = 10;

    public Transform ObjetivoPlayer;

    public static SpawnerEnemy instance;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBtwSpawn)
        {
            timer = 0;
            float x = Random.Range(point1.position.x, point1.position.x);
            float z = Random.Range(point1.position.z, point1.position.z);
            Vector3 pos = new Vector3(x, transform.position.y, transform.position.z);
            Instantiate(items[Random.Range(0, items.Count)], pos, Quaternion.identity);

        }
    }

    public void SeguirEnemyPlayer()
    {
      transform.LookAt(ObjetivoPlayer.position);
    }
}
