using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform obj;
    public float MaxDistance = 10;
    public float MoveSpeed = 20;
    public float UpdatedSpeed = 10;
    [Range(0,10)]
    public float currDistance = 5;
    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    private MeshRenderer _renderer;
    private float hideDistance = 1.5f;

    private void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = obj.gameObject.GetComponent<MeshRenderer>();
    }
    void Awake()
    {
        SceneManager.sceneLoaded += LoadScene;
    }

    void LoadScene(Scene scene, LoadSceneMode mode)
    {

    }

    void Update()
    {
        ahead.transform.position = obj.position + obj.forward * (MaxDistance * 0.25f);
        currDistance += Input.GetAxisRaw(moveAxis) * MoveSpeed * Time.deltaTime;
        currDistance = Mathf.Clamp(currDistance,0,MaxDistance);
        transform.position = Vector3.MoveTowards(transform.position, obj.position + Vector3.up * currDistance - obj.forward * (currDistance + MaxDistance * 0.5f), UpdatedSpeed * Time.deltaTime);
        transform.LookAt(ahead.transform);
        _renderer.enabled = (currDistance > hideDistance);
    }

}
