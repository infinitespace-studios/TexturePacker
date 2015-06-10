using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace InfinitespaceStudios.TexturePacker.Pipeline
{
	[ContentImporter(".xml", DefaultProcessor = "TexturePackerProcessor",
		DisplayName = "TexturePacker Generic Xml Importer")]
	public class TexturePackerImporter : ContentImporter<XDocument>
	{
		public override XDocument Import (string filename, ContentImporterContext context)
		{
			var doc = XDocument.Load (filename);
			return doc;
		}
	}
		
}

