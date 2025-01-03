using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartUIAnimation : MonoBehaviour
{
    public float duration;
    
    private Image _tapImage;
    private PlayerFlap _playerFlap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerFlap = GameObject.Find("Player").GetComponent<PlayerFlap>();
        _tapImage = GameObject.Find("Finger").GetComponent<Image>();
        StartCoroutine(TapAnimation());
    }

    private IEnumerator TapAnimation()
    {
        while (!_playerFlap.started)
        {
            yield return new WaitForSeconds(duration);
            _tapImage.enabled = false;
            yield return new WaitForSeconds(duration);
            _tapImage.enabled = true;
        }
    }
}