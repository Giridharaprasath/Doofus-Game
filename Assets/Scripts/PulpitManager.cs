using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulpitManager : MonoBehaviour
{
    public static PulpitManager instance;

    [SerializeField]
    private Vector3[] newPos = {new Vector3(9f, 0f, 0f), new Vector3(-9f, 0f, 0f), new Vector3(0f, 0f, 9f), new Vector3(0f, 0f, -9f)};

    [Header("Pulpit Prefab")]
    [SerializeField]
    private Pulpit pulpitPrefab;

    public List<Pulpit> pulpitList = new List<Pulpit>();

    [Header("Pulpit Data")]
    [SerializeField]
    private float minPulpitDTime = 4f;
    [SerializeField]
    private float maxPulpitDTime = 5f;
    [SerializeField]
    private float pulpitSpawnTime = 2.5f;

    #region HIDDEN OBJECTS

    [SerializeField]
    private Pulpit newPulpit;
    [SerializeField]
    private Vector3 prevPulpitPos;
    [SerializeField]
    private Vector3 currPulpitPos;
    [SerializeField]
    private float currPulpitTime;

    [SerializeField]


    #endregion

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        currPulpitPos = new Vector3(0f, 0f, 0f);
        CreateNewPulpit();
    }

    public void SetNewPulpitPos(Vector3 pos)
    {
        int randNum = Random.Range(0, newPos.Length);
        prevPulpitPos = currPulpitPos;
        currPulpitPos = pos + newPos[randNum];
        CreateNewPulpit();

        //10 MIN BREAK
    }

    private void CreateNewPulpit()
    {
        Pulpit newPulpit = Instantiate(pulpitPrefab, currPulpitPos, Quaternion.identity);
        newPulpit.OnCreation();

        newPulpit = null;
    }
}