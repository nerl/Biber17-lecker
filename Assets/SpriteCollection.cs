using UnityEngine;
using System.Collections;

public class SpriteCollection {
	public Sprite[] sprites;
	private string[] names;

	public SpriteCollection(string spritesheet) {
		sprites = Resources.LoadAll<Sprite>(spritesheet);
		names = new string[sprites.Length];

		for (var i = 0; i < names.Length; i++) {
			names[i] = sprites[i].name;
			//UtilFunctions.Alert("" + i + " " + names[i]);
		}
	}

	public Sprite GetSprite(string name) {
		return sprites[System.Array.IndexOf(names, name)];
	}

	public string GetSpriteName(int i) {
		return sprites[i].name;
	}
}
