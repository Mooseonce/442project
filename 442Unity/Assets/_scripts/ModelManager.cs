using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public List<GameObject> modelMainPrefabs, modelPiecePrefabs;
    public GameObject activeMainModel;
    public Transform modelPieceParent, spawnLocationsForConstruction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) { ResetBuildTable(); }   
    }
    public void ResetBuildTable()
    {
        foreach (Transform go in modelPieceParent) { Destroy(go.gameObject); }
        GameObject clone2 = Instantiate(modelMainPrefabs[Random.Range(0, modelMainPrefabs.Count )], transform.position, transform.rotation);
        clone2.transform.parent = modelPieceParent;
        activeMainModel = clone2;
        foreach (Transform go in spawnLocationsForConstruction) {
            GameObject clone = Instantiate(modelPiecePrefabs[Random.Range(0, modelPiecePrefabs.Count )], go.position,go.rotation);
            clone.transform.parent = modelPieceParent;
        }
    }
    public void ActivatePieces(Color colorToActivate)
    {
        if (activeMainModel != null)
        {
            activeMainModel.GetComponent<ModelMainBody>().ActivatePieces(colorToActivate);
        }
    }
    public void returnparent()
    {
        if (activeMainModel != null)
        { activeMainModel.transform.position = transform.position; }
    }
}
