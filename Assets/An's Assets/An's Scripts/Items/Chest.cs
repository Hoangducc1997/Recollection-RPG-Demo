using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject appearNextScene; // Đối tượng kích hoạt khi mở rương
    [SerializeField] private Vector3 spawnOffset = new Vector3(0.5f, 2f, 0f); // Tùy chỉnh vị trí spawn
    [SerializeField] private string chestID; // ID của chest

    private Animator animator;
    private bool isOpened = false;

    public GameObject rewardPrefab; // Phần thưởng khi mở rương
    public string requiredKeyID; // ID của khóa cần thiết để mở rương này

    void Start()
    {
        animator = GetComponent<Animator>();
        if (appearNextScene != null)
        {
            appearNextScene.SetActive(false); // Đảm bảo đối tượng ẩn lúc đầu
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            // Kiểm tra xem người chơi có khóa hay không
            if (PlayerPrefs.GetInt(requiredKeyID, 0) == 1)
            {
                OpenChest();

                // Kiểm tra ID của chest
                if (chestID == "ChestOvercome1") // Thay "SpecificChestID" bằng ID bạn muốn kiểm tra
                {
                    MissionOvercomeMap.Instance?.ShowMissionComplete2(); // Hiển thị missionComplete6
                }
                // Kiểm tra ID của chest
                if (chestID == "Chest1Overcome2") // Thay "SpecificChestID" bằng ID bạn muốn kiểm tra
                {
                    MissionOvercomeMap.Instance?.ShowMissionComplete6(); // Hiển thị missionComplete6
                }
                // Kiểm tra ID của chest
                if (chestID == "Chest2Overcome2") // Thay "SpecificChestID" bằng ID bạn muốn kiểm tra
                {
                    MissionOvercomeMap.Instance?.ShowMissionComplete7(); // Hiển thị missionComplete6
                }
                AudioManager.Instance.PlayVFX("PlayerLevelUp");
            }
            else
            {
                Debug.Log($"You need the {requiredKeyID} to open this chest!");
                AudioManager.Instance.PlayVFX("Touch");
            }
        }
    }


    private void OpenChest()
    {
        isOpened = true;
        animator.SetTrigger("OpenChest");

        if (rewardPrefab != null)
        {
            Instantiate(rewardPrefab, transform.position + spawnOffset, Quaternion.identity);
        }

        if (appearNextScene != null)
        {
            appearNextScene.SetActive(true); // Kích hoạt đối tượng tiếp theo
        }

        Debug.Log("Chest opened!");
    }
}
