using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private bool testMode = true;
    public static AdManager instance;
    private GameOverHandler gameOverHandler;

#if UNITY_ANDROID
    private string gameId = "5336577";
#elif UNITY_IOS
    private string gameId = "5336576";
#endif

    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.Initialize(gameId, testMode, this);
        }   
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;

        Advertisement.Show("rewardedVideo", this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ad Initialization Failed {error} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Unity Ad loaded: {placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Unity Ad Failed to Load: {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId){ }

    public void OnUnityAdsShowClick(string placementId){ }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch(showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
                gameOverHandler.ContinueGame();
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                Debug.Log("Ad was Skipped.");
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                Debug.LogWarning("Ad Failed.");
                break;
        }
    }
}
