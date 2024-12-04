using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 사격 점수 계산 스크립트
public class TargetAreaCollision : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float areaLength = 0.12f;

    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        private set
        {
            _score = value;
            scoreText.text = "Score:\n" + value.ToString();
        }
    }
    Vector3 centerPos;

    private void Awake()
    {
        centerPos = transform.position;
        Score = 0;
    }

    public void AddScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(centerPos, hitPoint);

        if (distance < areaLength) Score += 10;
        else if (distance < 2 * areaLength) Score += 9;
        else if (distance < 3 * areaLength) Score += 8;
        else if (distance < 4 * areaLength) Score += 7;
        else return;
    }
}
