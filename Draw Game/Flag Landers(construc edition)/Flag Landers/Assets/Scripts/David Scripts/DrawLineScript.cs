using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
    
public class DrawLineScript : MonoBehaviour, IPointerDownHandler,  IPointerUpHandler
{

    GameObject LineGo;
    bool startDrawing;
    Vector3 MousePos;
    LineRenderer _LR;

    [SerializeField]
    Material LineMat;

    int CurrentIndex;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Transform Collider_Prefab;
    Transform LastInstantiate_Collider;

    public void OnPointerDown(PointerEventData eventData)
    {
        startDrawing = true;
        MousePos = Input.mousePosition;

        _LR = LineGo.AddComponent<LineRenderer>();
        _LR.startWidth = .2f;
        _LR.material = LineMat;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startDrawing = false;
        Rigidbody rb = LineGo.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        _LR.useWorldSpace = false;
        Destroy(LastInstantiate_Collider.gameObject);
        Start();
        CurrentIndex = 0;

        /*foreach(Rigidbody SphereRB in rb)
        {
            SphereRB.useGravity = true;
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        LineGo = new GameObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startDrawing)
        {
            Vector3 Dist = MousePos - Input.mousePosition;
            float Distance_SqrMag = Dist.sqrMagnitude;

            if(Dist.sqrMagnitude > 1000f)
            {
                _LR.SetPosition(CurrentIndex, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f)));

                if(LastInstantiate_Collider != null)
                {
                    Vector3 CurrLinePos = _LR.GetPosition(CurrentIndex);
                    LastInstantiate_Collider.gameObject.SetActive(true);
                    LastInstantiate_Collider.LookAt(CurrLinePos);

                    if(LastInstantiate_Collider.rotation.y == 0)
                    {
                        LastInstantiate_Collider.eulerAngles = new Vector3(LastInstantiate_Collider.rotation.eulerAngles.x, 90, LastInstantiate_Collider.rotation.eulerAngles.z);
                    }

                    LastInstantiate_Collider.localScale = new Vector3(LastInstantiate_Collider.localScale.x, LastInstantiate_Collider.localScale.y, Vector3.Distance(LastInstantiate_Collider.position, CurrLinePos) * 60f);
                }

                LastInstantiate_Collider = Instantiate(Collider_Prefab, _LR.GetPosition(CurrentIndex), Quaternion.identity, LineGo.transform);

                LastInstantiate_Collider.gameObject.SetActive(false);

                MousePos = Input.mousePosition;

                CurrentIndex++;

                _LR.positionCount = CurrentIndex + 1;

                _LR.SetPosition(CurrentIndex, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f)));
            }
        }
    }
}
