using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class DoofusDiary : MonoBehaviour
{
    [Serializable]
    public class DiaryData
    {
        public playerdata player_data;
        public pulpitdata pulpit_data;
    }

    [Serializable]
    public class playerdata
    {
        public float speed;
    }

    [Serializable]
    public class pulpitdata
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }

    public DiaryData diaryData;

    private void Awake()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);

                // Setting Default Value if API Request Error
                diaryData.pulpit_data.pulpit_spawn_time = 2.5f;
                diaryData.pulpit_data.min_pulpit_destroy_time = 4;
                diaryData.pulpit_data.max_pulpit_destroy_time = 5;
                diaryData.player_data.speed = 8;
            }
            else
            {
                Debug.Log("Successfully downloaded data");

                var text = www.downloadHandler.text;
                diaryData = JsonUtility.FromJson<DiaryData>(text);
                GameManager.instance.doofusDiary = this;
            }
        }
    }
}
