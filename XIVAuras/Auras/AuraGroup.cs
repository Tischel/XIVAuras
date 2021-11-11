﻿using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using XIVAuras.Config;

namespace XIVAuras.Auras
{
    public class AuraGroup : AuraListItem, IAuraGroup
    {
        public override AuraType Type => AuraType.Group;

        public AuraListConfig AuraList { get; set; }

        // Constructor for deserialization
        public AuraGroup() : this(string.Empty) { }

        public AuraGroup(string name) : base(name)
        {
            this.AuraList = new AuraListConfig();
        }

        public override IEnumerable<IConfigPage> GetConfigPages()
        {
            yield return this.AuraList;
        }

        public override void Draw(Vector2 pos, Vector2? parentSize = null)
        {
            foreach (AuraListItem aura in this.AuraList.Auras)
            {
                if (!this.Preview && this.LastFrameWasPreview)
                {
                    aura.Preview = false;
                }
                else
                {
                    aura.Preview |= this.Preview;
                }

                aura.Draw(pos);
            }

            this.LastFrameWasPreview = this.Preview;
        }
    }
}