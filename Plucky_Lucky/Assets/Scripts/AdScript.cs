using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdScript : MonoBehaviour {
    // this is copy pasted from site
    private BannerView bannerView;
   
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        #if UNITY_ANDROID
            string appId = "ca-app-pub-9756156849896096~6189799136";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        if(sceneName == "Menu")
        {
            this.RequestBanner();
        }
        else if (sceneName == "MainGame")
        {
            bannerView.Destroy();
        }
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-9756156849896096/6080976167";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the bottom left screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, -190, 27);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);

    }



}