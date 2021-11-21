using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    [SerializeField] public Image img_transition;
    private float radiuscurtain;
    private float curtain;
    //pruebas
    [SerializeField] private bool op_world_2;
    [SerializeField] private bool op_world_1;
    public bool change = false;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            change = true;
            
        }
        if (change)
        {
            img_transition.material.SetFloat("_Cutoff", curtain);
            curtain = Mathf.Clamp(radiuscurtain, 0, 1);
            radiuscurtain += Time.deltaTime;
        }
         if(radiuscurtain > 1f || Full == true)
        {
            Full = true;
            change = false;
            img_transition.material.SetFloat("_Cutoff", curtain);
            curtain = Mathf.Clamp(radiuscurtain, 0, 1);
            radiuscurtain -= Time.deltaTime;
            if(radiuscurtain == 0)
            {
                Full = false;
                radiuscurtain = 0;
            }
        }
    }

    private void initialize()
    {
        if (change)
        {
            if(op_world_1 && !op_world_2)
            {
                Debug.Log("change");
                radiuscurtain = 0;
                img_transition.material.SetFloat("_Cutoff", radiuscurtain);
            }
        }
    }

    private void end()
    {
        if (!change)
        {
            radiuscurtain = 1;
            img_transition.material.SetFloat("_Cutoff", radiuscurtain);
        }
    }
}
