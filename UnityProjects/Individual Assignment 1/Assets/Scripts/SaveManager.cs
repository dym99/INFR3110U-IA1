using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            SaveLoadWrapper.savePositionFile("playerposition.txt", m_player.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            Vector3 pos = SaveLoadWrapper.loadPositionFile("playerposition.txt");
            m_player.transform.position = pos;
        }
    }
}
