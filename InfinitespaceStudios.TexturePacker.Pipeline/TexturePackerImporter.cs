using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace InfinitespaceStudios.TexturePacker.Pipeline
{
	[ContentImporter(".xml", DefaultProcessor = "TexturePackerProcessor",
		DisplayName = "TexturePacker Importer")]
	public class TexturePackerImporter : ContentImporter<XDocument>
	{
		public override XDocument Import (string filename, ContentImporterContext context)
		{
			return XDocument.Load (filename);
		}
	}
		
}

