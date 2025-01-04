using UnityEngine;
using UnityEngine.Serialization;

public class DisplayMedal : MonoBehaviour
{
    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;
    public GameObject diamondMedal;
    public GameObject gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<GameControllerScript>().playerFlap.dead)
        {
            if (gameController.GetComponent<GameControllerScript>().score >= 50)
            {
                diamondMedal.SetActive(true);
            }
            else if (gameController.GetComponent<GameControllerScript>().score >= 30)
            {
                goldMedal.SetActive(true);
            }
            else if (gameController.GetComponent<GameControllerScript>().score >= 20)
            {
                silverMedal.SetActive(true);
            }
            else if (gameController.GetComponent<GameControllerScript>().score >= 10)
            {
                bronzeMedal.SetActive(true);
            }
        }
    }
}
