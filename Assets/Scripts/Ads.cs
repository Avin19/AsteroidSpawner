using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : MonoBehaviour
{   
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOver;
    string app_Key ="166afeb95";
    bool check =true;
  
    private void Start() {
        IronSource.Agent.init (app_Key, IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);

    }
    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.activeSelf == true || gameOver.activeSelf ==true && check == true)
        {   check =false;
            IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
            IronSource.Agent.displayBanner();

        }
    }
}
