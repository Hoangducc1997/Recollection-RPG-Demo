using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID = "Key1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioManager.Instance.PlayVFX("PickupItem2");
            PlayerPrefs.SetInt(keyID, 1);
            Debug.Log("Key collected: " + keyID);
            AudioManager.Instance.PlayVFX("PickupItem2");

            // Kiểm tra ID của chest
            if (keyID == "Key1") // Thay "SpecificChestID" bằng ID bạn muốn kiểm tra
            {
                MissionOvercomeMap.Instance?.ShowMissionComplete1(); // Hiển thị missionComplete6
            }
            if (keyID == "KeyForKey") // Thay "SpecificChestID" bằng ID bạn muốn kiểm tra
            {
                MissionOvercomeMap.Instance?.ShowMissionComplete5(); // Hiển thị missionComplete6
            }
           
            Destroy(gameObject);
        }
    }

    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All saves deleted!");
    }

    public void DeleteKeySave()
    {
        if (PlayerPrefs.HasKey(keyID))
        {
            PlayerPrefs.DeleteKey(keyID);
            Debug.Log("Key save deleted: " + keyID);
        }
        else
        {
            Debug.Log("No save found for key: " + keyID);
        }
    }
}
