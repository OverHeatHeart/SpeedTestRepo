using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSpd2 : MonoBehaviour
{
    public Text distanceText;
    public Text elapsedTimeText;
    public Text distPerSecText;
    public Text timePerZeroDotFourText;
    public Text curSpdText;

    public float spd = 1;
    public float spdFactor = 1;

    [Header("누적용")]
    private float elapsedTime = 0;
    private Vector3 originPos;
    [Header("스위치")]
    public bool isRunning = true;
    private void Start()
    {
        InitializeSpd();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isRunning = !isRunning;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            isRunning = false;
            InitializeSpd();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            spd += 0.1f;
            InitializeSpd();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            spd -= 0.1f;
            InitializeSpd();
        }

        if (isRunning == false) return;

        Vector3 translated = transform.right * 0.4f;
        transform.position += translated * Time.deltaTime * spd;

        elapsedTime += Time.deltaTime;
        elapsedTimeText.text = "경과 시간: " + string.Format("{0:0.00}", elapsedTime);

        float dist = Vector3.Distance(transform.position, originPos);
        distanceText.text = "이동 거리: " + string.Format("{0:0.00}", dist);

        //1초당 움직이는 거리
        float distPerSec = dist / elapsedTime;
        distPerSecText.text = "1초당 움직이는 거리: " + string.Format("{0:0.00}", distPerSec);

        curSpdText.text = "현재 속도 값: " + string.Format("{0:0.00}", spd);

        //0.4 움직이는데 걸리는 시간은 원래 1초다. 근데 이게 이게 2가 되면?
        float timePerZeroDot4 = 1/spd;
        timePerZeroDotFourText.text = "0.4를 움직이는데 걸린 시간: " + string.Format("{0:0.00}", timePerZeroDot4) + "초";
    }

    private void InitializeSpd()
    {
        originPos = transform.position;
        elapsedTime = 0;
        elapsedTimeText.text = "경과 시간: " + string.Format("{0:0.00}", elapsedTime);
        distanceText.text = "이동 거리: 0";
    }
}