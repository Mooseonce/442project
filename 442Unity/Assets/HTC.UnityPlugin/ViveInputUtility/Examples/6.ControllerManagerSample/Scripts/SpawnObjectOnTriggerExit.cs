using UnityEngine;
using System.Collections;

public class SpawnObjectOnTriggerExit : MonoBehaviour
{
    public GameObject effectTarget,prefabObj;
    public float delay = 1.0f;

    private Vector3 originPosition;
    private Quaternion originRotation;

    private GameObject clonedTarget;

    private void Start()
    {
       // clonedTarget = effectTarget;
       // originPosition = effectTarget.transform.localPosition;
      //  originRotation = effectTarget.transform.localRotation;
    }
    public void Update()
    {
        if (delay != -1)
        {
            if (delay  > 0 )
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    effectTarget = Instantiate(prefabObj,transform.position,transform.rotation) as GameObject;
                    effectTarget.active = true;
                    delay = -1;
                    GetComponent<Collider>().enabled = true;
                }
            }
        }
        else { }
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject == effectTarget)
        {
            delay = 1.0f;
            GetComponent<Collider>().enabled = false;
            // StopAllCoroutines();
            // StartCoroutine(CopyTarget());
        }
    }

   // private IEnumerator CopyTarget()
   // {
        //yield return new WaitForSeconds(delay);

        //var copy = Instantiate(effectTarget);
        //copy.transform.SetParent(effectTarget.transform.parent);
        //copy.transform.localPosition = originPosition;
        //copy.transform.localRotation = originRotation;
        //copy.name = effectTarget.name;

        //clonedTarget = copy;
    //}
}
