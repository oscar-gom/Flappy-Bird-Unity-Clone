using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject spawner;
    
    private static int _score = 0;
    private PlayerFlap _playerFlap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerFlap = player.GetComponent<PlayerFlap>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _playerFlap.score.ToString();
        _score = _playerFlap.score;
        
        switch (_score)
        {
            case >= 20:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 2f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(2.5f);
                break;
            case >= 15:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 3f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(2f);
                break;
            case >= 10:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 4f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(1.5f);
                break;
            case >= 5:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 4.5f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(1f);
                break;
            default:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 5f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(1f);
                break;
        }
    }
}
