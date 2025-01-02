using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private GameObject _floor1;
    private GameObject _floor2;
    private GameObject _floor3;

    private float _floorY;
    private float _floorWidth;
    
    // Ensures that floors are together
    private float _offset = 0.11f;

    void Start()
    {
        // Find floors by name
        _floor1 = GameObject.Find("Floor1");
        _floor2 = GameObject.Find("Floor2");
        _floor3 = GameObject.Find("Floor3");

        _floorWidth = _floor1.GetComponent<SpriteRenderer>().bounds.size.x;
        _floorY = _floor1.transform.position.y;
    }

    void Update()
    {
        MoveFloor(_floor1);
        MoveFloor(_floor2);
        MoveFloor(_floor3);
    }

    private void MoveFloor(GameObject floor)
    {
        floor.transform.position += Vector3.left * (speed * Time.deltaTime);

        if (floor.transform.position.x < -_floorWidth - 0.5f)
        {
            float rightmostX = Mathf.Max(_floor1.transform.position.x, _floor2.transform.position.x, _floor3.transform.position.x);
            floor.transform.position = new Vector3(rightmostX + _floorWidth - _offset, _floorY, floor.transform.position.z);
        }
    }
}