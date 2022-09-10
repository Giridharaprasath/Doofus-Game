using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Pulpit : MonoBehaviour
{
    [SerializeField]
    private float currPulpitTime;
    [SerializeField]
    private bool canCreateNewPulpit = true;

    [SerializeField]
    private TMP_Text pulpitTimer;

    #region HIDDEN DATA

    private float minPulpitDT = 4f;
    private float maxPulpitDT = 5f;
    private float spawnPulpitTime = 2.5f;
    private bool isFalling = false;
    #endregion

    public void OnCreation()
    {
        PulpitManager.instance.pulpitList.Add(this);
        minPulpitDT = GameManager.instance.doofusDiary.diaryData.pulpit_data.min_pulpit_destroy_time;
        maxPulpitDT = GameManager.instance.doofusDiary.diaryData.pulpit_data.max_pulpit_destroy_time;
        spawnPulpitTime = GameManager.instance.doofusDiary.diaryData.pulpit_data.pulpit_spawn_time;
        currPulpitTime = Random.Range(minPulpitDT, maxPulpitDT);
    }

    private void Update()
    {
        if (currPulpitTime > 0)
        {
            currPulpitTime -= Time.deltaTime;
            pulpitTimer.text = currPulpitTime.ToString("F2");
        }
        if (currPulpitTime < 0)
        {
            //Destroy(this.gameObject);
            if (!isFalling)
            {
                this.AddComponent<Rigidbody>();
                isFalling = true;
            }
            PulpitManager.instance.pulpitList.Remove(this);
            if (transform.position.y < -10f) Destroy(this.gameObject);
        }
        if (currPulpitTime < spawnPulpitTime && canCreateNewPulpit && PulpitManager.instance.pulpitList.Count < 2)
        {
            PulpitManager.instance.SetNewPulpitPos(this.transform.position);
            canCreateNewPulpit = false;
        }
    }
}