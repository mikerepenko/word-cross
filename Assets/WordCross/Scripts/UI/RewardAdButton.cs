using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GoogleMobileAds.Api;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

using dotmob;
using System;

namespace WordCross
{
	[RequireComponent(typeof(Button))]
	public class RewardAdButton : MonoBehaviour
	{
		public void onRewardedVideoFinished()
		{
			CompleteMethod(true);
		}

		#region Inspector Variables

		[SerializeField] private int	coinsToReward;
		[SerializeField] private bool	testMode;


		//private RewardedAd rewardedAd;
		private string rewadedUnitId = "ca-app-pub-3033243931390124/8092781279";

		#endregion

		#region Properties

		public Button Button { get { return gameObject.GetComponent<Button>(); } }

		#endregion

		#region Unity Methods

		private void Awake()
		{
			//Appodeal.setRewardedVideoCallbacks(this);
			Button.onClick.AddListener(OnClick);


			if (testMode)
			{
				gameObject.SetActive(true);
			}

			//IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
		}

		//private void OnEnable()
		//{
		//	rewardedAd = new RewardedAd(rewadedUnitId);
		//	AdRequest adRequestRewarded = new AdRequest.Builder().Build();
		//	rewardedAd.LoadAd(adRequestRewarded);
		//	rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
		//}

		//private void HandleUserEarnedReward(object sender, Reward e)
		//{
		//	CompleteMethod(true);
		//}

		#endregion

		#region Private Methods

		private void OnClick()
		{
			if (testMode)
			{
				OnRewardAdGranted("", 0);

				return;
			}

			//if (Advertisements.Instance.IsRewardVideoAvailable())
			//{

			//	Debug.LogError("[RewardAdButton] The reward button was clicked but there is no ad loaded to show.");
			//}
			//         else
			//         {

			//Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
			//IronSource.Agent.showRewardedVideo();
			//if (rewardedAd.IsLoaded())
			//{
			//	rewardedAd.Show();
			//}
			//  }
			if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
			    Appodeal.show(Appodeal.REWARDED_VIDEO);
		}

		public void onRewardedVideoLoaded(bool isPrecache)
		{
			CompleteMethod(true);
		}

		private void CompleteMethod(bool completed)
		{
			//Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
			if (completed == true)
			{
				// Get the current amount of coins
				int animateFromCoins = GameController.Instance.Coins;

				// Give the amount of coins
				GameController.Instance.GiveCoins(coinsToReward, false);

				// Get the amount of coins now after giving them
				int animateToCoins = GameController.Instance.Coins;

				// Show the popup to the user so they know they got the coins
				PopupManager.Instance.Show("reward_ad_granted", new object[] { coinsToReward, animateFromCoins, animateToCoins });
			}
			else
			{
				Debug.Log("NO REWARD");
			}
		}


        private void OnRewardAdLoaded()
		{
			gameObject.SetActive(true);
		}

		private void OnRewardAdClosed()
		{
			gameObject.SetActive(false);
		}

		private void OnRewardAdGranted(string rewardId, double rewardAmount)
		{
			// Get the current amount of coins
			int animateFromCoins = GameController.Instance.Coins;

			// Give the amount of coins
			GameController.Instance.GiveCoins(coinsToReward, false);

			// Get the amount of coins now after giving them
			int animateToCoins = GameController.Instance.Coins;

			// Show the popup to the user so they know they got the coins
			PopupManager.Instance.Show("reward_ad_granted", new object[] { coinsToReward, animateFromCoins, animateToCoins } );
		}

		private void OnAdsRemoved()
		{
			//MobileAdsManager.Instance.OnRewardAdLoaded -= OnRewardAdLoaded;

			gameObject.SetActive(false);
		}

        public void onRewardedVideoFailedToLoad()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoShowFailed()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoShown()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoFinished(double amount, string name)
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoClosed(bool finished)
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoExpired()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoClicked()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
