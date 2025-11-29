using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            Time.deltaTime * 2.0f
        );

    }
}
