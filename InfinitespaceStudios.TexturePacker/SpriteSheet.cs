﻿using System;
using System.Collections.Generic;

namespace InfinitespaceStudios.TexturePacker
{
	public class SpriteSheet
	{
		private readonly IDictionary<string, SpriteFrame> spriteList;

		public SpriteSheet()
		{
			spriteList = new Dictionary<string, SpriteFrame>();
		}

		public void Add(string name, SpriteFrame sprite)
		{
			spriteList.Add(name, sprite);
		}

		public void Add(SpriteSheet otherSheet)
		{
			foreach (var sprite in otherSheet.spriteList)
			{
				spriteList.Add(sprite);
			}
		}

		public SpriteFrame Sprite(string sprite)
		{
			return this.spriteList[sprite];
		}
	}

}
