using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMainBody : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 currentVelocity;
    public float timer, speed;
    public List<GameObject> actionPieces,staticPieces,engines, lasers;
    public List<Material> colorList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { ActivatePieces(colorList[0].color); }
        if (Input.GetKeyDown(KeyCode.W)) { ActivatePieces(colorList[1].color); }
        if (Input.GetKeyDown(KeyCode.E)) { ActivatePieces(colorList[2].color); }
        if (Input.GetKeyDown(KeyCode.R)) { ActivatePieces(colorList[3].color); }

        if (timer > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + currentVelocity, speed * 1 * Time.deltaTime);
            timer -= Time.deltaTime;
            Quaternion tempQuat = Quaternion.LookRotation(currentVelocity, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, tempQuat, Time.deltaTime);

        }
        else { currentVelocity = Vector3.zero; }

    }
    public void AddPiece(int type, GameObject newpiece)
    {
        if (type == 0) { actionPieces.Add(newpiece); } else if (type == 1) {} else { staticPieces.Add(newpiece); }
    }
    public void RemovePiece(int type, GameObject newpiece)
    {
        if (type == 0) { actionPieces.Remove(newpiece); } else if (type == 1) { } else { staticPieces.Remove(newpiece); }
    }
    public void ActivatePieces(Color colorToActivate)
    {
        foreach (GameObject go in actionPieces)
        { if (go.GetComponent<Model_Piece>().GetColorId() == colorToActivate) { go.GetComponent<Model_Actions>().ActionList(); }  }

    }
    //set objects to loop their action

    public void ActivatePiecesToggleOn(Color colorToActivate)
    {
        foreach (GameObject go in actionPieces)
        { if (go.GetComponent<Model_Piece>().GetColorId() == colorToActivate) { go.GetComponent<Model_Actions>().ToggleOnOff(); } }

    }
    public void ActivatePiecesToggleOnWithValue(Color colorToActivate,float currentLevel)
    {
        foreach (GameObject go in actionPieces)
        { if (go.GetComponent<Model_Piece>().GetColorId() == colorToActivate) { go.GetComponent<Model_Actions>().settogglepower(currentLevel); go.GetComponent<Model_Actions>().TurnOn(); } }

    }

}