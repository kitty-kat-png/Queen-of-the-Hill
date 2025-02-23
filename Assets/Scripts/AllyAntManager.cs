using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyAntManager : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public int AntCount;
    public Text antAmountText;

    void Start()
    {

    }

    void Update()
    {
        antAmountText.text = "Ants: " + AntCount.ToString();

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
