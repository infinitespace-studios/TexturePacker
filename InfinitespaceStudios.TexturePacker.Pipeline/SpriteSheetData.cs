using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace InfinitespaceStudios.TexturePacker.Pipeline
{
	public class SpriteSheetData
	{
		public class SpriteFrameData {
			public Rectangle SourceRectangle { get; set; }

			public Vector2 Size { get; set; }

			public bool IsRotated { get; set; }

			public Vector2 Origin { get; set; }

			public string Name { get; set; }
		}

		public List<SpriteFrameData> Sprites = new List<SpriteFrameData>();
		public TextureReferenceDictionary Textures = new TextureReferenceDictionary ();
	}
}

