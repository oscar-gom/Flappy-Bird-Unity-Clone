using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject spawner;
    
    private static int _score;
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
        
        if (_playerFlap.dead)
        {
            Debug.Log("Restarting game");
            StartCoroutine(RestartGame());
            spawner.GetComponent<SpawnBehaviour>().timerOn = false;
        }
        
        switch (_score)
        {
            case >= 20:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 1.5f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(3.5f);
                break;
            case >= 15:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 2f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(3f);
                break;
            case >= 10:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 3.5f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(2.5f);
                break;
            case >= 5:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 4f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(2f);
                break;
            default:
                spawner.GetComponent<SpawnBehaviour>().spawnRate = 5f;
                spawner.GetComponent<SpawnBehaviour>().setSpeed(1f);
                break;
        }
    }

    private IEnumerator RestartGame()
    {
        spawner.GetComponent<SpawnBehaviour>().setSpeed(0f);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
