using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InfinitespaceStudios.TexturePacker
{
	public class SpriteSheetReader : ContentTypeReader<SpriteSheet>
	{
		protected override SpriteSheet Read (ContentReader input, SpriteSheet existingInstance)
		{
			var spriteSheet = new SpriteSheet ();

			var texture = input.ReadExternalReference<Texture2D> ();
			var frames = input.ReadInt32 ();
			for (int i = 0; i < frames; i++) {
				var name = input.ReadString ();
				var isRotated = input.ReadBoolean ();
				var origin  = input.ReadVector2();
				var r = input.ReadVector4 ();
				var rect = new Rectangle ((int)r.X, (int)r.Y, (int)r.Z, (int)r.W);
				var size = input.ReadVector2();
				spriteSheet.Add (name, new SpriteFrame (texture, rect, size, origin, isRotated));
			}
			return spriteSheet;
		}
	}
}

