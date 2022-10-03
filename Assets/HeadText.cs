
using UnityEngine;
using TMPro;

public class HeadText : MonoBehaviour
{
    
    public TMP_Text Text;
    public SnakeGenerator SnakeGenerator;

    // Update is called once per frame
    void Update()
    {
        Text.text=SnakeGenerator.PointsSnake.ToString();
    }
}
