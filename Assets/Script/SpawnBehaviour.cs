using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnBehaviour : MonoBehaviour
{
    public float spawnRate = 1.0f;
    private float _timer;
    public GameObject[] pipes;

    public bool timerOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerOn = true;
        _timer = spawnRate;
    }

    private void SpawnRandomPipe()
    {
        int index = Random.Range(0, pipes.Length);
        GameObject pipe = pipes[index];
        Instantiate(pipe, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Spawning pipe");
                _timer = 0;
                timerOn = false;
                SpawnRandomPipe();

                // Reset timer
                _timer = spawnRate;
                timerOn = true;
            }
        }
    }
}