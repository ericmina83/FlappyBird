using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public Transform bird;
    public Pipe pipePrefab;

    public float mapRange;
    public int pipeInMap
    {
        get
        {
            return (int)(mapRange * 2 / pipeDistance);
        }
    }
    public float startPoint;
    public float pipeDistance = 0.75f;
    public float mapSpeed = 0.5f;
    public float mapHeight;
    public float timer;
    public List<Pipe> pipes;
    public float holeMinRatio;
    public float holeMaxRatio;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < pipeInMap; i++)
        {
            Pipe newPipe = Instantiate(pipePrefab);
            newPipe.transform.position = new Vector3(startPoint + i * pipeDistance, 0, 0);
            pipes.Add(newPipe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= mapSpeed * Time.deltaTime;
        if (timer < 0)
        {
            GenerateOrReusePipe();
            timer = pipeDistance;
        }
    }

    void GenerateOrReusePipe()
    {
        if (pipes.Count < pipeInMap)
        {
        }
    }
}
