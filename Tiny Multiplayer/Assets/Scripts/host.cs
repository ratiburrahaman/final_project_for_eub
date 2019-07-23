using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class host : MonoBehaviour
{
    NetworkManager networkManager;
    public InputField roomNamefield;
    public string roomName;

    // Start is called before the first frame update
    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createHost()
    {
        roomName = roomNamefield.text;

        roomName = roomNamefield.text;

        networkManager.matchMaker.CreateMatch(roomName, 4, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
    }

}
