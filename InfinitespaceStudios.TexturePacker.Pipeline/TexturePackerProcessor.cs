using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.ComponentModel;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.IO;
using Microsoft.Xna.Framework;


namespace InfinitespaceStudios.TexturePacker.Pipeline
{
	[ContentProcessor(DisplayName="TexturePacker Processor")]
	public class TexturePackerProcessor : ContentProcessor<XDocument, SpriteSheetData>
	{

		[DefaultValue(typeof(TextureProcessorOutputFormat), "Compressed")]
		public virtual TextureProcessorOutputFormat TextureFormat { get; set; }

		[DefaultValue(typeof(bool), "false")]
		public virtual bool PremultiplyAlpha { get; set; }

		[DefaultValue (typeof(string), "_Texture")]
		public virtual string TextureSuffix { get; set; }

		public TexturePackerProcessor ()
		{
			this.TextureFormat = TextureProcessorOutputFormat.Compressed;
			this.PremultiplyAlpha = false;
			this.TextureSuffix = "_Texture";
		}

		public override SpriteSheetData Process (XDocument input, ContentProcessorContext context)
		{
			OpaqueDataDictionary data = new OpaqueDataDictionary();  
			data.Add("PremultiplyAlpha", PremultiplyAlpha); 
			data.Add ("TextureFormat", TextureFormat);

			var result = new SpriteSheetData ();
			var atlas = input.Element ("TextureAtlas");
			var texture = atlas.Attribute ("imagePath").Value;
			var e = new ExternalReference<TextureContent>(texture);
			var textureReference = context.BuildAsset<TextureContent,TextureContent>(e, "TextureProcessor",
				data,"TextureImporter",Path.GetFileNameWithoutExtension(texture)+TextureSuffix); 

			result.Textures.Add (Path.GetFileNameWithoutExtension(texture),textureReference);

			var sprites = atlas.Elements ("sprite");
			foreach (var sprite in sprites) {
				var frame = new SpriteSheetData.SpriteFrameData ();
				var name = sprite.Attribute ("n").Value;
				frame.Name = Path.GetFileNameWithoutExtension (name);
				frame.SourceRectangle = new Rectangle(int.Parse (sprite.Attribute ("x").Value),
					int.Parse (sprite.Attribute ("y").Value),
					int.Parse (sprite.Attribute ("w").Value),
					int.Parse (sprite.Attribute ("h").Value));
				frame.Origin = new Vector2 (float.Parse (sprite.Attribute ("pX").Value),
					float.Parse (sprite.Attribute ("pY").Value));
				frame.IsRotated = sprite.Attribute ("r") != null && sprite.Attribute ("r").Value == "y";
				var ow = sprite.Attribute ("oW") != null ? int.Parse(sprite.Attribute ("oW").Value) : frame.SourceRectangle.Width ;
				var oh = sprite.Attribute ("oH") != null ? int.Parse(sprite.Attribute ("oH").Value) : frame.SourceRectangle.Height ;
				frame.Size = new Vector2 (ow, oh);
				result.Sprites.Add (frame);
			}
			return result;
		}
	}
}

