using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public float spawnRate = 1.0f;
    private float _timer;
    public GameObject[] pipes;
    public GameObject player;
    public float speed;

    public bool timerOn;

    private void SpawnRandomPipe()
    {
        int index = Random.Range(0, pipes.Length);
        GameObject pipe = pipes[index];
        Instantiate(pipe, transform.position, Quaternion.identity);
        setSpeed(speed);
    }

    public void setSpeed(float speed)
    {
        foreach (PipeMovement pipe in FindObjectsOfType<PipeMovement>())
        {
            pipe.speed = speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerFlap>().started && !timerOn)
        {
            Debug.Log("Player started moving!");
            timerOn = true;
            _timer = spawnRate;
        }

        if (timerOn)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Spawning pipe");
                SpawnRandomPipe();
                _timer = spawnRate;
            }
        }
    }
}