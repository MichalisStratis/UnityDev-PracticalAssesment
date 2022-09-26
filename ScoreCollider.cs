using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    public GameObject SpawnArea;
    public GameObject Score;
    public GameObject time;
    public List<float> BoxCheck;
    private int Layer;
    public ScoreSystem ScoreBoard;
    public SpawnRandomBox SpawnStation;
    public DisplayTime TimeUI;

    private void Start()
    {
        ScoreBoard = Score.GetComponent<ScoreSystem>();
        SpawnStation = SpawnArea.GetComponent<SpawnRandomBox>();
        TimeUI=time.GetComponent<DisplayTime>();
    }

    void Awake()
    {
        SceneManager.sceneLoaded += LoadScene;
    }

    void LoadScene(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("THE NEXT SCENE IS: " + SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerEnter(Collider collision)
    {
        Layer = collision.gameObject.layer;
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (Layer == 6 || Layer == 7)
        {
            if (BoxCheck.Count < 1)
            {
                ScoreBoard.AddScore(Layer);
                ScoreBoard.CheckForWinner();
                ScoreBoard.AddThrownObject();
                BoxCheck.Insert(0, Layer);
                SpawnStation.Spawn(SpawnStation.TypeOfShape(collision.gameObject));
                Destroy(collision.gameObject);
            }
            else
            {
                BoxCheck.Insert(1, Layer);
                if (BoxCheck[0] == BoxCheck[1])
                {
                    ScoreBoard.DeductScore(Layer);
                    BoxCheck[0] = BoxCheck[1];
                    ScoreBoard.AddThrownObject();
                    BoxCheck.Remove(BoxCheck[1]);
                    SpawnStation.Spawn(SpawnStation.TypeOfShape(collision.gameObject));
                    Destroy(collision.gameObject);

                }
                else
                {
                    ScoreBoard.AddScore(Layer);
                    ScoreBoard.CheckForWinner();
                    ScoreBoard.AddThrownObject();
                    BoxCheck[0] = BoxCheck[1];
                    BoxCheck.Remove(BoxCheck[1]);
                    SpawnStation.Spawn(SpawnStation.TypeOfShape(collision.gameObject));
                    Destroy(collision.gameObject);
                }
            }
        }

        else if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Destroy(collision.gameObject);
            TimeUI.GameOver();
        }
    }

}
