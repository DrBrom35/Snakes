
using UnityEngine;
using TMPro;

public class BlockText : MonoBehaviour
{
    public TMP_Text Text ;
    public TMP_Text Text1;
    public Block Block;

    // Update is called once per frame
    void Update()
    {
        Text.text = Block.PointsBlock.ToString();
        Text1.text = Block.PointsBlock.ToString();
    }
}
