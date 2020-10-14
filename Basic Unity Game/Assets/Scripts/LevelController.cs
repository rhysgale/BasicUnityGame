using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private EnemyScript[] _enemies;
    private static int _nextLevelIndex = 1;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<EnemyScript>();
    }

    void Update()
    {
        foreach(var enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        //All enemies have been killed

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
    }
}
