using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public float spawnRate = 1.0f;
    private float _timer;
    public GameObject pipe;
    public GameObject player;
    public float speed;

    public bool timerOn;

    // Array of predefined heights
    public float[] heights = { -3.0f, -2.0f, -1.0f, 0.0f, 1.0f, 2.0f, 3.0f };

    private int _lastHeightIndex = -1;
    private int _secondLastHeightIndex = -1;

    private void SpawnPipe()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, heights.Length);
        } while (randomIndex == _lastHeightIndex && randomIndex == _secondLastHeightIndex);

        _secondLastHeightIndex = _lastHeightIndex;
        _lastHeightIndex = randomIndex;

        float randomHeight = heights[randomIndex];
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, transform.position.z);

        Instantiate(pipe, spawnPosition, Quaternion.identity);
        SetSpeed(speed);
    }

    public void SetSpeed(float newSpeed)
    {
        foreach (PipeMovement pipe in FindObjectsOfType<PipeMovement>())
        {
            pipe.speed = newSpeed;
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
                SpawnPipe();
                _timer = spawnRate;
            }
        }
    }
}