using System.Collections;
using UnityEngine;

public class TestSpd : MonoBehaviour
{
    public float timeInterval = 1f;
    void Start()
    {
        StartCoroutine(StartMoving());
    }

    private void Update()
    {
        //여기가 timeInterval(시간)을 변경하는 신호를 주는 곳
        if(Input.GetKeyDown(KeyCode.W))
        {
            timeInterval -= 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            timeInterval += 0.1f;
        }
    }

    IEnumerator StartMoving()
    {
        //timeInterval초마다 0.4씩 오른쪽으로 움직인다
        while(true)
        {
            Vector3 translated = transform.right * 0.4f;
            transform.position += translated;
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
