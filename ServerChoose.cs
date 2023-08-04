using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerChoose : MonoBehaviour
{
    public bool AppIsServer = false;
    private NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {
        networkManager = gameObject.GetComponent<NetworkManager>();
        if (AppIsServer == true)
        {
            networkManager.StartServer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
