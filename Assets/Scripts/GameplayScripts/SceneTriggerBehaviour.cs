using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTriggerBehaviour : MonoBehaviour
{
    public string Scenename;
    public LevelManager levelmanager;
    void Awake()
    {
        levelmanager = FindObjectOfType<LevelManager>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<LevelManager>().LoadScene(Scenename);
        }
    }
}