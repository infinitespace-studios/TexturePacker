using System;
using System.Linq;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;
using Microsoft.Xna.Framework;

namespace InfinitespaceStudios.TexturePacker.Pipeline
{
	[ContentTypeWriter]
	public class SpriteSheetWriter : ContentTypeWriter<SpriteSheetData>
	{
		protected override void Write(ContentWriter output, SpriteSheetData value)
		{
			output.WriteExternalReference (value.Textures.First ().Value);
			output.Write ((Int32)value.Sprites.Count);
			foreach (var frame in value.Sprites) {
				output.Write (frame.Name);
				output.Write (frame.IsRotated);
				output.Write (frame.Origin);
				var v = new Vector4 (frame.SourceRectangle.X, frame.SourceRectangle.Y,
					frame.SourceRectangle.Width, frame.SourceRectangle.Height);
				output.Write (v);
				output.Write (frame.Size);
			}
		}
		public override string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return typeof(SpriteSheet).AssemblyQualifiedName;
		}
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return "InfinitespaceStudios.TexturePacker.SpriteSheetReader, InfinitespaceStudios.TexturePacker," + 
				" Version=1.0.0.0, Culture=neutral";
		}
	}
}

