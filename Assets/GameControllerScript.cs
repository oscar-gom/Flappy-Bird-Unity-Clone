using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject player;

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
    }
}
