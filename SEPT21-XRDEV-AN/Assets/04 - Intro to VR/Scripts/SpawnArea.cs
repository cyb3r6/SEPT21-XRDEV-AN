using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnArea : MonoBehaviour
{
    public BoxCollider spawnBox;
    public Target targetPrefab;
    public float score = 0;
    public Text playerScoreText;

    void Start()
    {
        SpawnTarget();
        PrintToText();

    }

    public void SpawnTarget()
    {
        var newTarget = Instantiate(targetPrefab, GetRandomTargetPosition(), targetPrefab.transform.rotation);

        newTarget.game = this;
    }

    private Vector3 GetRandomTargetPosition()
    {
        var x = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x);
        var y = Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y);
        var z = Random.Range(spawnBox.bounds.min.z, spawnBox.bounds.max.z);

        return new Vector3(x, y, z);
    }
    public void AddToScore(float value)
    {
        score += value;
        PrintToText();
    }

    public void PrintToText()
    {
        playerScoreText.text = $"Player Score: {score}";
    }
}
