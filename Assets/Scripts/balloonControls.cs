using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class balloonControls : MonoBehaviour
{
    GameObject player;
    private InterstitialAd interstitial;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float t;
    private float timeToReachTarget=3.0f;



    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        player = GameObject.Find("Player");
        // Invoke("SlideSpaceShipToBottom", 3);
        startPosition = gameObject.transform.localPosition;
        targetPosition = new Vector3(startPosition.x, startPosition.y -3.0f, startPosition.z);
    }
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget; // spaceship 3 sn sonra tabana hizalanmasını sağlıyor
        gameObject.transform.localPosition = Vector3.MoveTowards(startPosition, targetPosition, t);

    }

    private void SlideSpaceShipToBottom()
    {
        //  gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-3.0f, gameObject.transform.position.z));
        gameObject.transform.localPosition= Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 300.0f, gameObject.transform.position.z),Time.deltaTime*100);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            DontDestroyOnLoad(player);
            player.GetComponent<PlayerControl>().enabled = false;
            SceneManager.LoadScene("GameOverMenu");
            Debug.Log("Game Over!");
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
        else if (collision.tag == "LevelEnd")
        {
            collision.tag = "Untagged";
        }
    }
  

    private void RequestInterstitial()
{
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";//"ca-app-pub-4802128076914608/7186158011"; //"ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);

        print("Interstitial failed to load: " + args.Message);

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

}
