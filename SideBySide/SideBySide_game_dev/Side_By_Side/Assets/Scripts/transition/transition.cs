using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    [Header("Material Settings")]
    [SerializeField] private Image img_transition;
    private float radiuscurtain;
    private float curtain;

    [Header("functioning")]
    [SerializeField] private GameObject World_1;
    [SerializeField] private GameObject World_2;
    public bool cam_1, cam_2, change;
    bool Full = false;
    private void Start()
    {
        Material mat = Instantiate(img_transition.material);
        mat.SetFloat("_Cutoff", 0f);
        img_transition.material = mat;
    }
    private void Update()
    {
        Debug.Log(radiuscurtain);
        if (Input.GetKeyDown(KeyCode.F))
        {
            change = true;            
        }

        if(change)
        opencurtine();
        
        if (radiuscurtain > 1f)
        {
            StartCoroutine(change_world());
        }

        closeCurtine();
    }

    IEnumerator change_world()
    {
        if(cam_1 && !cam_2)
        {

            World_1.SetActive(false);
            World_2.SetActive(true);
        }
        else
        {
            World_1.SetActive(true);
            World_2.SetActive(false);
        }
            yield return new WaitForSeconds(.5f);
        Full = true;
    }

    public void opencurtine()
    {
        img_transition.material.SetFloat("_Cutoff", curtain);
        curtain = Mathf.Clamp(radiuscurtain, 0, 1);
        radiuscurtain += Time.deltaTime;
    }

    public void closeCurtine()
    {
        if (Full)
        {
            change = false;
            img_transition.material.SetFloat("_Cutoff", curtain);
            curtain = Mathf.Clamp(radiuscurtain, 0, 1);
            radiuscurtain -= Time.deltaTime;
            if (radiuscurtain < -0.01)
            {
                Full = false;
                Debug.Log("reset");
                StopAllCoroutines();
                radiuscurtain = 0;
                cam_1 = !cam_1;
                cam_2 = !cam_2;
            }
        }
    }
}
