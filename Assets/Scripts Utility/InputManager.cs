using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    public Camera cam;
    public Vector3 touchPos;
    [SerializeField] private bool canTouch = true;

    //public delegate void DelInputsManager();
    //public static event DelInputsManager OnTouch;

    public UnityEvent OnTouch;// for touching anything, no matter if correct or not

    public static InputManager instance;
    void AwakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Awake()
    {
        AwakeSingleton();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (!canTouch) return;
#if UNITY_EDITOR
        DetectMouse();
#elif UNITY_ANDROID
        DetectTouches();
#endif
    }

    void DetectTouches()
    {
        if (Input.touchCount <= 0) return;

        Vector3 p = Input.GetTouch(0).position;
        //p.z = 0f;

        touchPos = cam.ScreenToWorldPoint(p);
        touchPos.z = 0f;

        if (Input.GetTouch(0).phase == TouchPhase.Began && !IsTouchingOverUI())
        {
            ShootRaycast();
            OnTouch?.Invoke();
        }
    }

    void DetectMouse()
    {
        Vector3 p = Input.mousePosition;
        //p.z = 0f;

        // 2D
        //touchPos = cam.ScreenToWorldPoint(p);
        //touchPos.z = 0f;

        // 3D
        touchPos = cam.ScreenToWorldPoint(p);
        touchPos.y = 2f;

        if (Input.GetMouseButtonDown(0) && !IsTouchingOverUI())
        {
            ShootRaycast();
            OnTouch?.Invoke();
        }
    }

    void ShootRaycast()
    {
        //2D
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 50f);
        //if (hit.collider != null)
        //{
        //    print(hit.point + " Tocaste algo! "+ hit.collider.gameObject.name);

        //    var touchable = hit.collider.gameObject.GetComponentInParent<ITouchable>();
        //    if (touchable != null)
        //        touchable.OnTouch(touchPos);
        //}

        //3D
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hitting = Physics.Raycast(ray, out hit, 50f);
        if (hitting && hit.collider != null)
        {
            print(hit.point + " Tocaste algo! " + hit.collider.gameObject.name);

            var touchable = hit.collider.gameObject.GetComponent<ITouchable>();
            if (touchable != null)
                touchable.OnTouch(hit.point + new Vector3 (0,1f,0) );

        }
    }

    public void DisableTouchesFor(float time)
    {
        DisableTouch();
        StartCoroutine(WaitToEnableTouches(time));
    }

    IEnumerator WaitToEnableTouches(float time)
    {
        float t = 0f;
        while (t < time)
        {
            //if (!LvlManager.instance.isPaused)
            //    t += Time.deltaTime;
            yield return null;
        }
        EnableTouch();
        //if (LvlManager.instance.currLivesAmount >= 1)
        //{
        //    EnableTouch();
        //}
    }

    public void DisableTouch()
    {
        canTouch = false;
    }

    public void EnableTouch()
    {
        canTouch = true;
    }

    //OverUI
    public OverUI[] UIObjs;
	bool IsTouchingOverUI()
	{
		bool OverUIElement = false;

		for (int i = 0; i < UIObjs.Length; i++)
		{
			if (OverUIElement)
				continue;
			OverUIElement = UIObjs[i].IsOverUI();

		}

		return OverUIElement;
	}

}
