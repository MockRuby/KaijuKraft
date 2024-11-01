using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuStorage : MonoBehaviour
{
    private static KaijuStorage _instance;

    public static KaijuStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<KaijuStorage>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(KaijuStorage).Name);
                    _instance = singletonObject.AddComponent<KaijuStorage>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
