using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealManager : MonoBehaviour
{
    void Awake()
    {
        Appodeal.setLogLevel(Appodeal.LogLevel.Verbose);
        Appodeal.initialize("dc1ab5342b50f2e9f9cbc3a71323a090cbe373a64326131d", Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO, true);
        //Appodeal.setTesting(true);
    }
     
    public void ReclamShow()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }
}