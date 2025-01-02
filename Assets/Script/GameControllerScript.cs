using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        _score = _playerFlap.score;
        scoreText.text = _score.ToString();
        
        if (_playerFlap.dead)
        {
            Debug.Log("Restarting game");
            StartCoroutine(RestartGame());
            spawner.GetComponent<SpawnBehaviour>().timerOn = false;
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
