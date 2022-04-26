using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public Transform finishLine;

    public GameObject whiteCar;
    public GameObject blackCar;
    public GameObject yellowCar;
    public GameObject redCar;
    public GameObject blueCar;
    
    public void List()
    {
        List <float> distance = new List<float>();
        distance.Add(Vector3.Distance(whiteCar.transform.position, finishLine.position));
        distance.Add(Vector3.Distance(blackCar.transform.position, finishLine.position));
        distance.Add(Vector3.Distance(yellowCar.transform.position, finishLine.position));
        distance.Add(Vector3.Distance(redCar.transform.position, finishLine.position));
        distance.Add(Vector3.Distance(blueCar.transform.position, finishLine.position));

        float firstPosition = distance.AsQueryable().Min();
        float lastPosition = distance.AsQueryable().Max();
        Debug.Log (firstPosition);
    }
    private void Dictionary()
    {
        Dictionary<Transform, string> cars = new Dictionary<Transform, string>();

        cars.Add(whiteCar.transform, "white");
        cars.Add(blackCar.transform, "black");
        cars.Add(yellowCar.transform, "yellow");
        cars.Add(redCar.transform, "red");
        cars.Add(blueCar.transform, "blue");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List();
        }
        
    }


}
