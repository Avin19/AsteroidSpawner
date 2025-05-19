using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button nextBtn, backBtn, startBtn;
    [SerializeField] private TextMeshProUGUI coinText, costText, startText;
    [SerializeField] private ShipList shipList;
    [SerializeField] private GameObject pfShip;
    private int shipCount = 0;
    private void Awake()
    {
        nextBtn.onClick.AddListener(OnNextButton);
        backBtn.onClick.AddListener(OnBackButton);
        startBtn.onClick.AddListener(OnStartButton);

    }

    private void Start()
    {
        pfShip = Instantiate(shipList.Ships[0].pfship, transform);
    }

    private void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    private void OnBackButton()
    {
        if (shipCount < 1)
        {
            shipCount = shipList.Ships.Count;
            return;
        }
        else
        {
            --shipCount;
        }
        UpdateShip(shipCount);
    }

    private void OnNextButton()
    {
        if (shipCount >= shipList.Ships.Count)
        {
            shipCount = 0;
            return;
        }
        else
        {
            ++shipCount;
        }
        UpdateShip(shipCount);
    }

    private void UpdateShip(int count)
    {
        Destroy(pfShip);
        pfShip = Instantiate(shipList.Ships[count].pfship, transform);


    }
}
