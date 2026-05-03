using UnityEngine;

public class Politic_Face_Renderer : MonoBehaviour
{
	public SpriteRenderer[] parts;

	public Sprite[] s_0;

	public Sprite[] s_1;

	public Sprite[] s_2;

	public Sprite[] s_3;

	public Sprite[] s_4;

	public Sprite[] s_5;

	public Sprite[] s_6;

	public Sprite[] s_7;

	public Sprite[] jacket;

	public void Draw(byte[] types, byte jack)
	{
		parts[0].sprite = s_0[types[0]];
		parts[1].sprite = s_1[types[1]];
		parts[2].sprite = s_2[types[2]];
		parts[3].sprite = s_3[types[3]];
		parts[4].sprite = s_4[types[4]];
		parts[5].sprite = s_5[types[5]];
		parts[6].sprite = s_6[types[6]];
		parts[7].sprite = s_7[types[7]];
		parts[8].sprite = jacket[jack];
	}
}
