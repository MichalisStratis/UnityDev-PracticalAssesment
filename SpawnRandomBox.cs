using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnRandomBox : MonoBehaviour
{
    public GameObject[] Shape;
    public List<GameObject> ActiveShapes;
    public GameObject Score;
    public ScoreSystem ScoreBoard;
    public Vector3 center;
    public Vector3 size;
    public Vector3 RedBoxHalfExtends=new Vector3(3f, 1f, 3f);
    public Vector3 YellowHalfExtends = new Vector3(1f, 3f, 2f);
    public Vector3 SpawningOffset;
    public Vector3 position;
    public float timeLeft;
    public int numToSpawn;
    private int iType;


    void Start()
    {
        ScoreBoard = Score.GetComponent<ScoreSystem>();
        numToSpawn = ScoreBoard.GetNumToSpawn();
        timeLeft = ScoreBoard.RedSpawningTime();
        for (int i = 0; i < numToSpawn; i++)
        {
            Spawn(0);
            Spawn(1);
        }
    }

    public void Spawn( int ObjectToSpawn )
    {
        if (ObjectToSpawn==0)
        {
            SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
            position = center + SpawningOffset;
            while (Physics.CheckSphere(position, 0.5f))
            {
                SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
                position = center + SpawningOffset;
            }
            Instantiate(Shape[ObjectToSpawn], position, Quaternion.identity);
        }
        else if (ObjectToSpawn == 1)
        {
            SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
            position = center + SpawningOffset;
            while (Physics.CheckBox(position, YellowHalfExtends))
            {
                SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
                position = center + SpawningOffset;
            }
            Instantiate(Shape[ObjectToSpawn], position, Quaternion.identity);
        }
        else if (ObjectToSpawn == 2)
        {
            SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
            position = center + SpawningOffset;
            while (Physics.CheckBox(position, RedBoxHalfExtends))
            {
                SpawningOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(size.y / 2, size.y), Random.Range(-size.z / 2, size.z / 2));
                position = center + SpawningOffset;
            }
            Instantiate(Shape[ObjectToSpawn], position, Quaternion.identity);
        }

    }


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Spawn(2);
            }
            timeLeft = ScoreBoard.GetTimerCount(); ;
        } 
    }

    public int TypeOfShape( GameObject obj )
    {
        if (obj.layer==6)
        {
            iType = 0;
        }
        else if (obj.layer == 7)
        {
            iType = 1;
        }
        else if (obj.layer==8)
        {
            iType = 2;
        }
        return iType;
    }
    public void AddToActiveShape(GameObject shape)
    {
        ActiveShapes.Add(shape);  
    }
    public void DeductFromActiveShape(GameObject shape)
    {
        ActiveShapes.Remove(shape);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
