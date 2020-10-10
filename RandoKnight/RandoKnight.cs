using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Language;
using Modding;
using UnityEngine;
using UnityEngine.SceneManagement;
using GlobalEnums;
using ModCommon;
using ModCommon.Util;
using tk2dRuntime;
using IL.tk2dRuntime.TileMap;
using Vasi;

namespace RandoKnight
{
	// Token: 0x02000010 RID: 16
	[UsedImplicitly]
	public class RandoKnight : Mod, IMod, Modding.ILogger
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000022A1 File Offset: 0x000004A1
		// (set) Token: 0x06000044 RID: 68 RVA: 0x000022A8 File Offset: 0x000004A8
		[PublicAPI]
		public static RandoKnight Instance { get; private set; }

		// Token: 0x06000045 RID: 69 RVA: 0x000022B0 File Offset: 0x000004B0
		public override string GetVersion()
		{
			return Assembly.GetAssembly(typeof(RandoKnight)).GetName().Version.ToString();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000022D0 File Offset: 0x000004D0
		public RandoKnight() : base(RandomVersion())
		{
		}
		public static string RandomVersion()
		{
			int i = UnityEngine.Random.Range(1, 5);
			string r = "";
			if (i == 1)
				r += "R";
			r += "A";
			if (i == 2)
				r += "R";
			r += "N";
			if (i == 3)
				r += "R";
			r += "D";
			if (i == 4)
				r += "R";
			r += "O";
			if (i == 5)
				r += "R";
			r += "M KNIGHT";
			return r;
		}
		// Token: 0x06000052 RID: 82 RVA: 0x0000358C File Offset: 0x0000178C
		public override void Initialize()
		{
			RandoKnight.Instance = this;
			On.HeroController.Start += HeroController_Start;
			On.NailSlash.OnTriggerEnter2D += NailSlash_OnTriggerEnter2D;
		}

		private void HeroController_Start(On.HeroController.orig_Start orig, HeroController self)
		{
			orig(self);
			foreach (tk2dSpriteAnimationClip clip in self.GetComponent<tk2dSpriteAnimator>().Library.clips)
			{
				foreach (tk2dSpriteAnimationFrame frame in clip.frames)
				{
					frame.spriteId = UnityEngine.Random.Range(0, 890);
				}
			}
		}

		private void NailSlash_OnTriggerEnter2D(On.NailSlash.orig_OnTriggerEnter2D orig, NailSlash self, Collider2D otherCollider)
		{
			orig(self, otherCollider);
			foreach (tk2dSpriteAnimationClip clip in HeroController.instance.GetComponent<tk2dSpriteAnimator>().Library.clips)
			{
				foreach (tk2dSpriteAnimationFrame frame in clip.frames)
				{
					frame.spriteId = UnityEngine.Random.Range(0, 890);
				}
			}
		}
	}
}
