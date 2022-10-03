
using UnityEngine;
using TMPro;

public class BlockText : MonoBehaviour
{
    public TMP_Text Text ;
    public Block Block;

    // Update is called once per frame
    void Update()
    {
        Text.text = Block.PointsBlock.ToString();
    }
}
