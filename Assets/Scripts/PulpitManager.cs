using System.Collections.Generic;
using UnityEngine;

public class PulpitManager : MonoBehaviour
{
    public static PulpitManager instance;

    [Header("Pulpit Prefab")]
    [SerializeField]
    private Pulpit pulpitPrefab;

    [HideInInspector]
    public List<Pulpit> pulpitList = new List<Pulpit>();

    #region HIDDEN OBJECTS

    private Vector3[] newPos = { new Vector3(9f, 0f, 0f), new Vector3(-9f, 0f, 0f), new Vector3(0f, 0f, 9f), new Vector3(0f, 0f, -9f) };
    private Pulpit newPulpit;
    private Vector3 prevPulpitPos;
    private Vector3 currPulpitPos;

    #endregion

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        currPulpitPos = new Vector3(0f, 0f, 0f);
        CreateNewPulpit();
    }

    public void SetNewPulpitPos(Vector3 pos)
    {
        prevPulpitPos = currPulpitPos;

        int randNum = Random.Range(0, newPos.Length);
        
        currPulpitPos = pos + newPos[randNum];
        CreateNewPulpit();
    }

    private void CreateNewPulpit()
    {
        Pulpit newPulpit = Instantiate(pulpitPrefab, currPulpitPos, Quaternion.identity);
        newPulpit.OnCreation();

        newPulpit = null;
    }
}